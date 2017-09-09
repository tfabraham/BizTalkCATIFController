namespace BizTalkCatInstrumentationController
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Business Activity Tracking Components",
            "5CBD8BA0-60F8-401b-8FF5-C7F3D5FABE41"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Business Rules Components",
            "78E2D466-590F-4991-9287-3F00BA62793D"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Data Access Components",
            "2E5D65D8-71F9-43e9-B477-733EF6212895"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Orchestration/Workflow Components",
            "D2316AFB-414B-42e4-BB7F-3AA92B96A98A"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Pipeline Components",
            "691CB4CB-D20C-408e-8CFF-FD8A01CD2F75"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Transform Components",
            "226445A8-5AF3-4dbe-86D2-73E9B965378E"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Web/WCF Services",
            "E67E8346-90F1-408b-AF40-222B6E3C5ED6"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Custom Components",
            "6A223DEA-F806-4523-BAD0-312DCC4F63F9"}, -1);
            this.filterListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.detailLevelComboBox = new System.Windows.Forms.ComboBox();
            this.traceNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startStopButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.logToFileCheckBox = new System.Windows.Forms.CheckBox();
            this.logToDebugViewCheckBox = new System.Windows.Forms.CheckBox();
            this.toggleSelectionButton = new System.Windows.Forms.Button();
            this.launchDebugViewButton = new System.Windows.Forms.Button();
            this.launchTextEditorButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.customComponentGuidTextBox = new System.Windows.Forms.TextBox();
            this.overrideCustomGuidCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterListView
            // 
            this.filterListView.CheckBoxes = true;
            this.filterListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.filterListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.filterListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterListView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.Tag = "Tracking";
            listViewItem2.StateImageIndex = 0;
            listViewItem2.Tag = "Rules";
            listViewItem3.StateImageIndex = 0;
            listViewItem3.Tag = "DataAccess";
            listViewItem4.StateImageIndex = 0;
            listViewItem4.Tag = "Workflow";
            listViewItem5.StateImageIndex = 0;
            listViewItem5.Tag = "Pipeline";
            listViewItem6.StateImageIndex = 0;
            listViewItem6.Tag = "Transform";
            listViewItem7.StateImageIndex = 0;
            listViewItem7.Tag = "Service";
            listViewItem8.StateImageIndex = 0;
            listViewItem8.Tag = "Custom";
            this.filterListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.filterListView.Location = new System.Drawing.Point(14, 96);
            this.filterListView.Name = "filterListView";
            this.filterListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.filterListView.Size = new System.Drawing.Size(560, 171);
            this.filterListView.TabIndex = 5;
            this.filterListView.UseCompatibleStateImageBehavior = false;
            this.filterListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Trace Filter Name";
            this.columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "GUID";
            this.columnHeader2.Width = 250;
            // 
            // detailLevelComboBox
            // 
            this.detailLevelComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.detailLevelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.detailLevelComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailLevelComboBox.FormattingEnabled = true;
            this.detailLevelComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.detailLevelComboBox.Items.AddRange(new object[] {
            "None",
            "Low",
            "Medium",
            "High",
            "All"});
            this.detailLevelComboBox.Location = new System.Drawing.Point(255, 43);
            this.detailLevelComboBox.Name = "detailLevelComboBox";
            this.detailLevelComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.detailLevelComboBox.Size = new System.Drawing.Size(121, 21);
            this.detailLevelComboBox.TabIndex = 2;
            // 
            // traceNameTextBox
            // 
            this.traceNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.traceNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.traceNameTextBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.traceNameTextBox.Location = new System.Drawing.Point(14, 44);
            this.traceNameTextBox.Name = "traceNameTextBox";
            this.traceNameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.traceNameTextBox.Size = new System.Drawing.Size(217, 20);
            this.traceNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Trace Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 25);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Detail Level:";
            // 
            // startStopButton
            // 
            this.startStopButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.startStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopButton.Location = new System.Drawing.Point(448, 345);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startStopButton.Size = new System.Drawing.Size(149, 30);
            this.startStopButton.TabIndex = 9;
            this.startStopButton.Text = "Start Trace";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 78);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trace Filter:";
            // 
            // logToFileCheckBox
            // 
            this.logToFileCheckBox.AutoSize = true;
            this.logToFileCheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.logToFileCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logToFileCheckBox.Location = new System.Drawing.Point(402, 44);
            this.logToFileCheckBox.Name = "logToFileCheckBox";
            this.logToFileCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logToFileCheckBox.Size = new System.Drawing.Size(85, 17);
            this.logToFileCheckBox.TabIndex = 3;
            this.logToFileCheckBox.Text = "Trace to File";
            this.logToFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // logToDebugViewCheckBox
            // 
            this.logToDebugViewCheckBox.AutoSize = true;
            this.logToDebugViewCheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.logToDebugViewCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logToDebugViewCheckBox.Location = new System.Drawing.Point(402, 63);
            this.logToDebugViewCheckBox.Name = "logToDebugViewCheckBox";
            this.logToDebugViewCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logToDebugViewCheckBox.Size = new System.Drawing.Size(172, 17);
            this.logToDebugViewCheckBox.TabIndex = 4;
            this.logToDebugViewCheckBox.Text = "Trace to DebugView (real-time)";
            this.logToDebugViewCheckBox.UseVisualStyleBackColor = true;
            // 
            // toggleSelectionButton
            // 
            this.toggleSelectionButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.toggleSelectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleSelectionButton.Location = new System.Drawing.Point(14, 273);
            this.toggleSelectionButton.Name = "toggleSelectionButton";
            this.toggleSelectionButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toggleSelectionButton.Size = new System.Drawing.Size(114, 23);
            this.toggleSelectionButton.TabIndex = 6;
            this.toggleSelectionButton.Text = "Toggle Selection";
            this.toggleSelectionButton.UseVisualStyleBackColor = true;
            this.toggleSelectionButton.Click += new System.EventHandler(this.toggleSelectionButton_Click);
            // 
            // launchDebugViewButton
            // 
            this.launchDebugViewButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.launchDebugViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchDebugViewButton.Location = new System.Drawing.Point(11, 345);
            this.launchDebugViewButton.Name = "launchDebugViewButton";
            this.launchDebugViewButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.launchDebugViewButton.Size = new System.Drawing.Size(149, 30);
            this.launchDebugViewButton.TabIndex = 7;
            this.launchDebugViewButton.Text = "Launch DebugView";
            this.launchDebugViewButton.UseVisualStyleBackColor = true;
            this.launchDebugViewButton.Click += new System.EventHandler(this.launchDebugViewButton_Click);
            // 
            // launchTextEditorButton
            // 
            this.launchTextEditorButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.launchTextEditorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchTextEditorButton.Location = new System.Drawing.Point(167, 345);
            this.launchTextEditorButton.Name = "launchTextEditorButton";
            this.launchTextEditorButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.launchTextEditorButton.Size = new System.Drawing.Size(149, 30);
            this.launchTextEditorButton.TabIndex = 8;
            this.launchTextEditorButton.Text = "Open Log in Text Editor";
            this.launchTextEditorButton.UseVisualStyleBackColor = true;
            this.launchTextEditorButton.Click += new System.EventHandler(this.launchTextEditorButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customComponentGuidTextBox);
            this.groupBox1.Controls.Add(this.overrideCustomGuidCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.detailLevelComboBox);
            this.groupBox1.Controls.Add(this.filterListView);
            this.groupBox1.Controls.Add(this.traceNameTextBox);
            this.groupBox1.Controls.Add(this.toggleSelectionButton);
            this.groupBox1.Controls.Add(this.logToFileCheckBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.logToDebugViewCheckBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(11, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(585, 309);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trace Configuration";
            // 
            // customComponentGuidTextBox
            // 
            this.customComponentGuidTextBox.Enabled = false;
            this.customComponentGuidTextBox.Location = new System.Drawing.Point(344, 275);
            this.customComponentGuidTextBox.Name = "customComponentGuidTextBox";
            this.customComponentGuidTextBox.Size = new System.Drawing.Size(230, 20);
            this.customComponentGuidTextBox.TabIndex = 13;
            // 
            // overrideCustomGuidCheckBox
            // 
            this.overrideCustomGuidCheckBox.AutoSize = true;
            this.overrideCustomGuidCheckBox.Location = new System.Drawing.Point(150, 277);
            this.overrideCustomGuidCheckBox.Name = "overrideCustomGuidCheckBox";
            this.overrideCustomGuidCheckBox.Size = new System.Drawing.Size(194, 17);
            this.overrideCustomGuidCheckBox.TabIndex = 14;
            this.overrideCustomGuidCheckBox.Text = "Override Custom Component GUID:";
            this.overrideCustomGuidCheckBox.UseVisualStyleBackColor = true;
            this.overrideCustomGuidCheckBox.CheckedChanged += new System.EventHandler(this.overrideCustomGuidCheckBox_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(395, 25);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Trace Output:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(607, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(379, 22);
            this.aboutToolStripMenuItem.Text = "&About BizTalk CAT Instrumentation Framework Controller";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 385);
            this.Controls.Add(this.launchTextEditorButton);
            this.Controls.Add(this.launchDebugViewButton);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BizTalk CAT Instrumentation Framework Controller {Version}";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView filterListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ComboBox detailLevelComboBox;
        private System.Windows.Forms.TextBox traceNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox logToFileCheckBox;
        private System.Windows.Forms.CheckBox logToDebugViewCheckBox;
        private System.Windows.Forms.Button toggleSelectionButton;
        private System.Windows.Forms.Button launchDebugViewButton;
        private System.Windows.Forms.Button launchTextEditorButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox overrideCustomGuidCheckBox;
        private System.Windows.Forms.TextBox customComponentGuidTextBox;
    }
}

