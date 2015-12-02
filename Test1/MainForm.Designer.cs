using System;

namespace JiraSimpleTimeTracker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbTimer = new System.Windows.Forms.Label();
            this.lbCurIssue = new System.Windows.Forms.Label();
            this.issueDataGrid = new System.Windows.Forms.DataGridView();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jiraIssueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbIssueFilters = new System.Windows.Forms.ComboBox();
            this.jiraIssueFilterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bntIssueList = new System.Windows.Forms.Button();
            this.btnStartPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.imgLoading = new System.Windows.Forms.PictureBox();
            this.mainContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.issueDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiraIssueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiraIssueFilterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // mainContextMenu
            // 
            this.mainContextMenu.AllowMerge = false;
            this.mainContextMenu.BackColor = System.Drawing.Color.White;
            this.mainContextMenu.DropShadowEnabled = false;
            this.mainContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mainContextMenu.Name = "mainContextMenu";
            this.mainContextMenu.ShowImageMargin = false;
            this.mainContextMenu.Size = new System.Drawing.Size(92, 48);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.btnPrefs_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // lbTimer
            // 
            this.lbTimer.BackColor = System.Drawing.Color.Transparent;
            this.lbTimer.Enabled = false;
            this.lbTimer.Font = new System.Drawing.Font("Digital-7 Mono", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimer.ForeColor = System.Drawing.Color.Black;
            this.lbTimer.Location = new System.Drawing.Point(3, -1);
            this.lbTimer.Name = "lbTimer";
            this.lbTimer.Size = new System.Drawing.Size(90, 35);
            this.lbTimer.TabIndex = 0;
            this.lbTimer.Text = "00:00:00";
            this.lbTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCurIssue
            // 
            this.lbCurIssue.BackColor = System.Drawing.Color.Transparent;
            this.lbCurIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCurIssue.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCurIssue.ForeColor = System.Drawing.Color.DimGray;
            this.lbCurIssue.Location = new System.Drawing.Point(1, 32);
            this.lbCurIssue.Margin = new System.Windows.Forms.Padding(0);
            this.lbCurIssue.Name = "lbCurIssue";
            this.lbCurIssue.Size = new System.Drawing.Size(131, 15);
            this.lbCurIssue.TabIndex = 0;
            this.lbCurIssue.Text = "No issue selected";
            this.lbCurIssue.TextChanged += new System.EventHandler(this.lbCurIssue_TextChanged);
            // 
            // issueDataGrid
            // 
            this.issueDataGrid.AllowUserToAddRows = false;
            this.issueDataGrid.AllowUserToDeleteRows = false;
            this.issueDataGrid.AllowUserToResizeColumns = false;
            this.issueDataGrid.AllowUserToResizeRows = false;
            this.issueDataGrid.AutoGenerateColumns = false;
            this.issueDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.issueDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.issueDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.issueDataGrid.ColumnHeadersVisible = false;
            this.issueDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn});
            this.issueDataGrid.DataSource = this.jiraIssueBindingSource;
            this.issueDataGrid.EnableHeadersVisualStyles = false;
            this.issueDataGrid.GridColor = System.Drawing.Color.DodgerBlue;
            this.issueDataGrid.Location = new System.Drawing.Point(-1, 72);
            this.issueDataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.issueDataGrid.MultiSelect = false;
            this.issueDataGrid.Name = "issueDataGrid";
            this.issueDataGrid.ReadOnly = true;
            this.issueDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.issueDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.issueDataGrid.RowTemplate.Height = 20;
            this.issueDataGrid.RowTemplate.ReadOnly = true;
            this.issueDataGrid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.issueDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.issueDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.issueDataGrid.Size = new System.Drawing.Size(157, 95);
            this.issueDataGrid.TabIndex = 5;
            this.issueDataGrid.TabStop = false;
            this.issueDataGrid.SelectionChanged += new System.EventHandler(this.issueDataGrid_SelectionChanged);
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.titleDataGridViewTextBoxColumn.ToolTipText = "title";
            this.titleDataGridViewTextBoxColumn.Width = 153;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Visible = false;
            // 
            // jiraIssueBindingSource
            // 
            this.jiraIssueBindingSource.DataSource = typeof(JiraSimpleTimeTracker.JiraIssue);
            // 
            // cbIssueFilters
            // 
            this.cbIssueFilters.DataSource = this.jiraIssueFilterBindingSource;
            this.cbIssueFilters.DisplayMember = "Title";
            this.cbIssueFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIssueFilters.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbIssueFilters.ForeColor = System.Drawing.Color.Black;
            this.cbIssueFilters.FormattingEnabled = true;
            this.cbIssueFilters.ItemHeight = 15;
            this.cbIssueFilters.Location = new System.Drawing.Point(0, 50);
            this.cbIssueFilters.Margin = new System.Windows.Forms.Padding(0);
            this.cbIssueFilters.MaxDropDownItems = 5;
            this.cbIssueFilters.MaximumSize = new System.Drawing.Size(155, 0);
            this.cbIssueFilters.Name = "cbIssueFilters";
            this.cbIssueFilters.Size = new System.Drawing.Size(155, 23);
            this.cbIssueFilters.TabIndex = 7;
            this.cbIssueFilters.TabStop = false;
            this.cbIssueFilters.ValueMember = "ID";
            this.cbIssueFilters.SelectedIndexChanged += new System.EventHandler(this.cbIssueFilters_SelectedIndexChanged);
            // 
            // jiraIssueFilterBindingSource
            // 
            this.jiraIssueFilterBindingSource.DataSource = typeof(JiraSimpleTimeTracker.JiraIssueFilter);
            // 
            // bntIssueList
            // 
            this.bntIssueList.BackColor = System.Drawing.Color.Transparent;
            this.bntIssueList.BackgroundImage = global::JiraSimpleTimeTracker.Properties.Resources.Expand_Arrow_26;
            this.bntIssueList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntIssueList.FlatAppearance.BorderSize = 0;
            this.bntIssueList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntIssueList.ForeColor = System.Drawing.Color.Black;
            this.bntIssueList.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bntIssueList.Location = new System.Drawing.Point(123, 32);
            this.bntIssueList.Margin = new System.Windows.Forms.Padding(0);
            this.bntIssueList.Name = "bntIssueList";
            this.bntIssueList.Size = new System.Drawing.Size(33, 17);
            this.bntIssueList.TabIndex = 4;
            this.bntIssueList.TabStop = false;
            this.bntIssueList.UseVisualStyleBackColor = false;
            this.bntIssueList.Click += new System.EventHandler(this.bntIssueList_Click);
            // 
            // btnStartPause
            // 
            this.btnStartPause.BackColor = System.Drawing.Color.Transparent;
            this.btnStartPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartPause.ForeColor = System.Drawing.Color.Transparent;
            this.btnStartPause.Image = global::JiraSimpleTimeTracker.Properties.Resources.Play_Disabled_32;
            this.btnStartPause.Location = new System.Drawing.Point(90, -1);
            this.btnStartPause.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartPause.Name = "btnStartPause";
            this.btnStartPause.Size = new System.Drawing.Size(33, 35);
            this.btnStartPause.TabIndex = 2;
            this.btnStartPause.TabStop = false;
            this.btnStartPause.UseVisualStyleBackColor = false;
            this.btnStartPause.Click += new System.EventHandler(this.btnStartPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.ForeColor = System.Drawing.SystemColors.Window;
            this.btnStop.Image = global::JiraSimpleTimeTracker.Properties.Resources.Stop_Disabled_32;
            this.btnStop.Location = new System.Drawing.Point(122, -1);
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(33, 35);
            this.btnStop.TabIndex = 1;
            this.btnStop.TabStop = false;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // imgLoading
            // 
            this.imgLoading.Image = global::JiraSimpleTimeTracker.Properties.Resources._6;
            this.imgLoading.InitialImage = global::JiraSimpleTimeTracker.Properties.Resources._294;
            this.imgLoading.Location = new System.Drawing.Point(0, 72);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(155, 90);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLoading.TabIndex = 8;
            this.imgLoading.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(155, 168);
            this.ContextMenuStrip = this.mainContextMenu;
            this.ControlBox = false;
            this.Controls.Add(this.imgLoading);
            this.Controls.Add(this.cbIssueFilters);
            this.Controls.Add(this.issueDataGrid);
            this.Controls.Add(this.bntIssueList);
            this.Controls.Add(this.lbCurIssue);
            this.Controls.Add(this.lbTimer);
            this.Controls.Add(this.btnStartPause);
            this.Controls.Add(this.btnStop);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(155, 168);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(155, 168);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "App";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.mainContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.issueDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiraIssueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiraIssueFilterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.ContextMenuStrip mainContextMenu;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnStartPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lbTimer;
        private System.Windows.Forms.Label lbCurIssue;
        private System.Windows.Forms.Button bntIssueList;
        private System.Windows.Forms.ComboBox cbIssueFilters;
        private System.Windows.Forms.BindingSource jiraIssueBindingSource;
        private System.Windows.Forms.BindingSource jiraIssueFilterBindingSource;
        private System.Windows.Forms.DataGridView issueDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox imgLoading;
    }
}

