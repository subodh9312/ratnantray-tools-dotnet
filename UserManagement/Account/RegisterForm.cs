using System.Web.Security;
using System.Windows.Forms;

namespace UserManagement.Account
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        public static DialogResult ShowDialog(ref MembershipUser user)
        {
            RegisterForm dialog = new RegisterForm();
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
            MembershipCreateStatus status;
            user = Membership.CreateUser(userNameTextBox.Text.Trim(), 
                passwordTextBox.Text.Trim(), emailTextBox.Text.Trim(), securityQuestion.Trim(), 
                securityAnswerTextBox.Text.Trim(), true, out status);
            if (status != MembershipCreateStatus.Success)
            {
                user = null;
                result = DialogResult.None;
                passwordTextBox.Text = "";
                confirmPasswordTextBox.Text = "";
                switch(status)
                {
                    case MembershipCreateStatus.DuplicateUserName:
                        MessageBox.Show("User name is already used. Please provide a different user name.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case MembershipCreateStatus.DuplicateEmail:
                        MessageBox.Show("Email address is already used. Please provide a different Email address.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case MembershipCreateStatus.InvalidEmail:
                        MessageBox.Show("Invalid Email address.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case MembershipCreateStatus.InvalidPassword:
                        MessageBox.Show("Invalid Password. Password must contain at least eight characters, at least one number and both lower and uppercase letters and special characters.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case MembershipCreateStatus.InvalidUserName:
                        MessageBox.Show("Invalid Username.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case MembershipCreateStatus.UserRejected:
                        MessageBox.Show("User Rejected, please contact System Adminstrator for details.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case MembershipCreateStatus.InvalidAnswer:
                        MessageBox.Show("Invalid Answer, please contact System Adminstrator for details.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case MembershipCreateStatus.InvalidQuestion:
                        MessageBox.Show("Invalid Question, please contact System Adminstrator for details.",
                            "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            return result;
        }
    }
}
