// BizTalk CAT Instrumentation Framework Controller
// Copyright (C) 2010-Present Thomas F. Abraham. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root.

using System;
using System.Windows.Forms;

namespace BizTalkCatInstrumentationController
{
    public partial class OptionsForm : Form
    {
        public bool LogToolOutputToFile
        {
            get { return logToolOutputCheckBox.Checked; }
            set { logToolOutputCheckBox.Checked = value; }
        }

        public string DebugViewPath
        {
            get { return debugViewPathTextBox.Text; }
            set { debugViewPathTextBox.Text = value; }
        }

        public string TextEditorPath
        {
            get { return textEditorPathTextBox.Text; }
            set { textEditorPathTextBox.Text = value; }
        }

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void debugViewPathBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = false;
            ofd.AutoUpgradeEnabled = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.DereferenceLinks = true;
            ofd.Multiselect = false;
            ofd.RestoreDirectory = true;
            ofd.Title = "Browse for DbgView.exe";
            ofd.Filter = "DebugView (DbgView.exe)|DbgView.exe";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                debugViewPathTextBox.Text = ofd.FileName;
            }
        }

        private void textEditorPathBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = false;
            ofd.AutoUpgradeEnabled = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.DereferenceLinks = true;
            ofd.Multiselect = false;
            ofd.RestoreDirectory = true;
            ofd.Title = "Browse for preferred text editor EXE";
            ofd.Filter = "Executable Files (*.exe)|*.exe";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textEditorPathTextBox.Text = ofd.FileName;
            }
        }
    }
}
