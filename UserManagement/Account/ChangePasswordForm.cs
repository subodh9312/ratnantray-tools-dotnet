using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;

namespace UserManagement.Account
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm(ref MembershipUser user)
        {
            InitializeComponent();

            if (user == null)
                throw new ArgumentNullException("User is required while changing the user Password.");
        }

        public static DialogResult ShowDialog(ref MembershipUser user)
        {
            ChangePasswordForm dialog = new ChangePasswordForm(ref user);
            DialogResult result = DialogResult.None;
            while (result == DialogResult.None)
            {
                result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                    result = dialog.Validate(ref user);
            }

            dialog.Dispose();
            return result;
        }

        public DialogResult Validate(ref MembershipUser user)
        {
            bool success = false;
            try
            {
                success = user.ChangePassword(oldPasswordTextBox.Text.Trim(), newPasswordTextBox.Text.Trim());
                if (success)
                {
                    MessageBox.Show("User Password Changed Successfully. Please login with New Password", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to Change user Password as " + e.Message, "Authentication Failure",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                oldPasswordTextBox.Text = "";
                newPasswordTextBox.Text = "";
                confirmPasswordTextBox.Text = "";
            }
            
            return success ? DialogResult.OK : DialogResult.None;
        }
    }
}
