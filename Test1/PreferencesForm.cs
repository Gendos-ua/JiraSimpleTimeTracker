using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraSimpleTimeTracker
{
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkConnection())
            {
                Properties.Settings.Default.login = tbLogin.Text;
                Properties.Settings.Default.password = tbPassword.Text;
                Properties.Settings.Default.JiraUrl = tbJiraUrl.Text;
                Properties.Settings.Default.LastConnectionSuccessful = true;
                Properties.Settings.Default.Save();
            }
        }

        private bool checkConnection()
        {
            String login = tbLogin.Text;
            String password = tbPassword.Text;
            String jiraUrl = tbJiraUrl.Text;
            PreferencesForm.ActiveForm.Cursor = Cursors.WaitCursor;

            try
            {
                JiraRequest req = new JiraRequest(jiraUrl, login, password);
                String res = req.create("mypermissions"/*"search?jql=filter=-2"*/).getResponse();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Connection error: " + e.Message, "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
            finally
            {
                PreferencesForm.ActiveForm.Cursor = Cursors.Arrow;
            }
        }

        private void checkConnection(object sender, EventArgs e)
        {
            if(checkConnection())
                MessageBox.Show( "Connection successful!","",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void PreferencesForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MainForm.ReleaseCapture();
                MainForm.SendMessage(Handle, MainForm.WM_NCLBUTTONDOWN, MainForm.HT_CAPTION, 0);
            }
        }
    }
}
