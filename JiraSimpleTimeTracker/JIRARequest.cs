using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace JiraSimpleTimeTracker
{
    class JiraRequest
    {
        private String Login;
        private String Password;
        private String JiraUrl;

        WebRequest request;
        
        public JiraRequest()
        {
            Login = Properties.Settings.Default.login;
            Password = Properties.Settings.Default.password;
            JiraUrl = Properties.Settings.Default.JiraUrl;
        }

        public JiraRequest(String url, String login, String password)
        {
            Login = login;
            Password = password;
            JiraUrl = url;
        }


        public JiraRequest create(String path)
        {
            request = WebRequest.Create(JiraUrl+"rest/api/2/"+path);
            String authHash = Convert.ToBase64String(
                Encoding.UTF8.GetBytes(Login + ":" + Password)
            );
            request.Headers.Add("Authorization", "Basic " + authHash);

            return this;
        }

        public JiraRequest create(String path, String json)
        {
            this.create(path);
            request.Method = "POST";
            request.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            return this;
        }

        public String getResponse()
        {
            WebResponse response = null;
            StreamReader reader = null;

            try
            {
                response = request.GetResponse();
                Console.WriteLine( request.RequestUri.ToString() +": "+ ((HttpWebResponse)response).StatusDescription);

                reader = new StreamReader(response.GetResponseStream());
                String responseFromServer = reader.ReadToEnd();
                return responseFromServer;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    reader = new StreamReader(e.Response.GetResponseStream());
                    String responseFromServer = reader.ReadToEnd();

                    throw new Exception(
                        "JIRA Request error:" + extraxtResponseErrorMessage(responseFromServer)
                    );
                }
                else
                {
                    Console.Write("Error: {0}", e.Status);
                    throw e;
                }
            }
            finally
            {
                // Clean up the streams and the response.
                if(reader != null) reader.Close();
                if(response != null) response.Close();
            }
        }


        public JArray getResponseAsJArray()
        {
            return JArray.Parse(getResponse());
        }

        public JObject getResponseAsJObject()
        {
            return JObject.Parse(getResponse());
        }

        private String extraxtResponseErrorMessage(String response)
        {
            String errMsg = "Unknown.";
            try
            {
                JObject result = JObject.Parse(response);
                errMsg = (string) result.GetValue("errorMessages").ToString();
            }
            catch (Exception e) { }

            return errMsg;
        }

        public void JSONToLog(String jsonString)
        {
            JsonTextReader jsonReader = new JsonTextReader(new StringReader(jsonString));

            String[] startMarkers = { "StartArray", "StartObject" };
            int depth = 0;

            while (jsonReader.Read())
            {
                if (jsonReader.Value != null)
                    Console.WriteLine(new String('\t', depth) + "{0}: {1}", jsonReader.TokenType, jsonReader.Value);
                else
                {
                    Console.WriteLine(jsonReader.TokenType.ToString());
                    if (startMarkers.Contains(jsonReader.TokenType.ToString()))
                        depth++;
                    else
                        depth--;
                }
            }
        }
    }
}
