using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraSimpleTimeTracker
{
    public partial class MainForm : Form
    {
        private int lbCurIssueMaxLenght = 21;
        public bool isFormMinimized = false;
        private bool isGridOpened = false;
        private bool isTimerControlsEnabled = false;
        private bool lastConnectSuccess = Properties.Settings.Default.LastConnectionSuccessful;


        private Timer timer;
        public CancellationTokenSource cancelMouseout = new CancellationTokenSource();
        private BindingSource issuesSource = new BindingSource();
        private BindingSource issuesFilterSource = new BindingSource();
        private JiraIssue currentIssue;
        private JiraIssueFilter currentIssuesFilter;

        private MouseMoveMessageFilter mouseMessageFilter;
        class MouseMoveMessageFilter : IMessageFilter
        {
            public MainForm TargetForm { get; set; }
            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x0200 /*WM_MOUSEMOVE || m.Msg == 0xA0 /*WM_NCMOUSEMOVE*/)
                {
                    TargetForm.MainForm_MouseMove();
                } 
                else if (m.Msg == 0x2A3 /*WM_MOUSELEAVE || m.Msg == 0x2A2 /*WM_NCMOUSELEAVE*/)
                {
                    TargetForm.MainForm_MouseLeave();
                }

                return false;
            }

        }


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.setTickHandler(new EventHandler(tickHandler));

            this.mouseMessageFilter = new MouseMoveMessageFilter();
            this.mouseMessageFilter.TargetForm = this;
            Application.AddMessageFilter(this.mouseMessageFilter);


            issuesFilterSource.Add(new JiraIssueFilter {
                title = "My Open Issues",
                ID = -1,
                jql = "assignee = currentUser() AND resolution = Unresolved ORDER BY updatedDate DESC"
            });
            issuesFilterSource.Add( new JiraIssueFilter {
                title = "Reported By Me",
                ID = -2,
                jql = "reporter = currentUser() ORDER BY createdDate DESC"
            });
            cbIssueFilters.DataSource = issuesFilterSource;

            currentIssue = new JiraIssue
            {
                ID = 0,
                title = "No Issue selected",
                code = "0"
            };
            issuesSource.Add(currentIssue);
            issueDataGrid.DataSource = issuesSource;


            if (lastConnectSuccess)
            {
                updateIssuesFilters();
                updateIssues();
            }
        }

        private void updateIssuesFilters()
        {
            try
            {
                JiraRequest req = new JiraRequest();
                JArray result = req.create("filter/favourite").getResponseAsJArray();

                foreach (JObject child in result)
                {
                    issuesFilterSource.Add( new JiraIssueFilter {
                            title = child.GetValue("name").ToString(),
                            ID = int.Parse(child.GetValue("id").ToString()),
                            jql = child.GetValue("jql").ToString()
                    });
                }
            }
            catch (Exception ex) { }
        }


        private void updateIssues()
        {
            toggleLoader(true);
            // imgLoading.Show();
            issuesSource.Clear();

            bool issuesFound = false;

            try
            {
                JiraRequest req = new JiraRequest();
                JObject result = req.create(
                        "search?jql=" + 
                        Uri.EscapeUriString(currentIssuesFilter.jql).Replace("%20", "+") + "&fields=id,key,summary")
                    .getResponseAsJObject();
                

                foreach (JObject issue in result.Children<JProperty>()
                    .FirstOrDefault(x => x.Name == "issues").Value.Children())
                {
                    if (!issuesFound) issuesFound = true;

                    issuesSource.Add(new JiraIssue {
                        ID = int.Parse( issue.GetValue("id").ToString() ),
                        title = ((JObject)issue.GetValue("fields")).GetValue("summary").ToString(),
                        code = issue.GetValue("key").ToString(),
                    });
                }
            }
            catch (Exception ex) { }

            if (!issuesFound)
                issuesSource.Add(new JiraIssue
                {
                    ID = 0,
                    title = "No Issue selected",
                    code = "0"
                });

            toggleLoader(false);
            //imgLoading.Hide();
        }

        private void toggleLoader(bool state)
        {
            if (state)
                imgLoading.BringToFront();
            else
                imgLoading.SendToBack();

        }

        private void closeBtn_Click(object sender, System.EventArgs e) { Close(); }

        public void MainForm_MouseMove(/*object sender, EventArgs e*/)
        {

            cancelMouseout.Cancel();

            if (!isFormMinimized) return;

            this.Opacity = 1D;
            this.MaximumSize = 
            this.MinimumSize = 
            this.Size = new System.Drawing.Size(155, isGridOpened ? 168 : 48);
            isFormMinimized = false;
            
        }

        private async void MainForm_MouseLeave(/*object sender, EventArgs e*/)
        { 
            if (isFormMinimized) return;

            try
            {
                if (cancelMouseout.IsCancellationRequested)
                {
                    cancelMouseout.Dispose();
                    cancelMouseout = new CancellationTokenSource();
                }
                await Task.Delay(300, cancelMouseout.Token);

                this.Opacity = 0.8D;
                this.MaximumSize = 
                this.MinimumSize = 
                this.Size = new System.Drawing.Size(155, 33);

                isFormMinimized = true;
            }
            catch (TaskCanceledException ex) { }
        }

        private void btnPrefs_Click(object sender, EventArgs e)
        {
            Form prefsForm = new PreferencesForm();
            prefsForm.ShowDialog(this);
        }


        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public void MainForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        public void tickHandler(object sender, EventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds(timer.secondsPassed);

            lbTimer.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);
        }

        private void btnStartPause_Click(object sender, EventArgs e)
        {
            if (!isTimerControlsEnabled) return;

            if (timer.isRunning)
            {
                btnStartPause.Image = global::JiraSimpleTimeTracker.Properties.Resources.Play_32;
                timer.pause();
            }
            else
            {
                btnStartPause.Image = global::JiraSimpleTimeTracker.Properties.Resources.Pause_32;
                timer.start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!isTimerControlsEnabled || !timer.isRunning) return;
            
            timer.pause();

            try
            {
                TimeSpan t = TimeSpan.FromSeconds(timer.secondsPassed);
                string worklog = JsonConvert.SerializeObject(new JiraIssueWorkLog {
                    timeSpentSeconds = timer.secondsPassed,
                    //timeSpent = t.Hours + "h " + t.Minutes + "m",
                    started = new DateTimeOffset(DateTime.UtcNow).Subtract(t).ToString("yyyy-MM-ddTHH:mm:ss.fff+0000")
                }, Formatting.Indented);
                Console.WriteLine(worklog);

                JiraRequest req = new JiraRequest();
                req.create("issue/" + currentIssue.ID.ToString() + "/worklog", worklog);
                Console.WriteLine(req.getResponse());

                btnStartPause.Image = global::JiraSimpleTimeTracker.Properties.Resources.Play_32;
                timer.stop();
                lbTimer.Text = "00:00:00";
            }
            catch(Exception ex)
            {
                btnStartPause.Image = global::JiraSimpleTimeTracker.Properties.Resources.Pause_32;
            }
        }

        private void toggleTimerControls(bool state)
        {
            if (state)
            {
                btnStartPause.Image = global::JiraSimpleTimeTracker.Properties.Resources.Play_32;
                btnStop.Image = global::JiraSimpleTimeTracker.Properties.Resources.Stop_32;
            }
            else
            {
                btnStartPause.Image = global::JiraSimpleTimeTracker.Properties.Resources.Play_Disabled_32;
                btnStop.Image = global::JiraSimpleTimeTracker.Properties.Resources.Stop_Disabled_32;
            }
            isTimerControlsEnabled = state;
        }

        private void lbCurIssue_TextChanged(object sender, EventArgs e)
        {
            if (lbCurIssue.Text.Length > lbCurIssueMaxLenght)
                lbCurIssue.Text = lbCurIssue.Text.Substring(0, lbCurIssueMaxLenght).Trim()+"…";
        }

        private void bntIssueList_Click(object sender, EventArgs e)
        {
            bntIssueList.BackgroundImage =
                isGridOpened ?
                global::JiraSimpleTimeTracker.Properties.Resources.Expand_Arrow_26 :
                global::JiraSimpleTimeTracker.Properties.Resources.Expand_Arrow_Up_26;

            this.MaximumSize =
            this.MinimumSize =
            this.Size = new System.Drawing.Size(155, isGridOpened ? 48 : 168);

            isGridOpened = !isGridOpened;
        }

        private void issueDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            JiraIssue selectedIssue;

            foreach (DataGridViewRow row in issueDataGrid.SelectedRows)
            {
                selectedIssue = row.DataBoundItem as JiraIssue;

                if(selectedIssue != null)
                {
                    toggleTimerControls(selectedIssue.ID != 0);
                    lbCurIssue.Text = selectedIssue.title;
                    
                    currentIssue.secondsElapsed = timer.secondsPassed;
                    timer.secondsPassed = selectedIssue.secondsElapsed;

                    currentIssue = selectedIssue;

                    if (timer.isRunning)
                        timer.stop();

                    tickHandler(sender, e);

                    break;
                }
            }
        }

        private void cbIssueFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentIssuesFilter = (JiraIssueFilter)cbIssueFilters.SelectedItem;
            updateIssues();
        }
    }
}
