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
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        public static DialogResult ShowDialog(ref MembershipUser user)
        {
            ForgotPasswordForm dialog = new ForgotPasswordForm();
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
            DialogResult result = DialogResult.OK;

            string securityQuestion = securityQuestionComboBox.SelectedItem as string;
            user = Membership.GetUser(userNameTextBox.Text.Trim(), false);
            if (user == null)
            {
                MessageBox.Show("User Not Found.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DialogResult.None;
            }
            try
            {
                string password = user.ResetPassword(securityAnswerTextBox.Text.Trim());
                MessageBox.Show(user.UserName + "'s password has been reset and reset. New password has "
                    + " been copied to your clipboard. Please change to password immediately.", "Operation Successful"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.SetDataObject(password, true);
                result = DialogResult.OK;
            }
            catch (Exception e)
            {
                MessageBox.Show("Password reset failed as " + e.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = DialogResult.None;
            }

            return result;
        }
    }
}
