using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SerialMaker
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                stbPass.Text = SoftwareLocker.Encryption.MakePassword(stbBase.Text, txtIdentifier.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Can't make password\n" + ex.Message);
            }
        }
    }
}