using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static SoftwareLocker.Locker;

namespace Example
{
    public partial class ExampleForm : Form
    {
        private RunTypes runType;

        public ExampleForm(RunTypes RunType)
        {
            InitializeComponent();

            if (RunType == RunTypes.Full)
            {
                label1.Text = "Full Running";
                label1.ForeColor = Color.Blue;
            }
            else if (RunType == RunTypes.Demo)
            {
                label1.Text = "Demo Running";
                label1.ForeColor = Color.Green;
            }

            runType = RunType;
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            if (runType == RunTypes.Trial)
                MessageBox.Show("This button don't run in trial mode");
            else
                MessageBox.Show("This button run in full mode");
        }

        private void btnFull_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button run in trial or full mode");
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button runs in Demo mode.");
        }
    }
}