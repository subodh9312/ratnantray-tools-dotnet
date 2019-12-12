using System.Web.Security;
using System.Windows.Forms;
using log4net;
using UserManagement.Utils;

namespace UserManagement.Account
{
    public partial class LoginForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LoginForm)); 

        public LoginForm()
        {
            InitializeComponent();

            MembershipUser user = Membership.GetUser(UserUtility.ADMINISTRATOR_USERNAME);
            if (user == null)
            {
                MembershipCreateStatus status;
                Membership.CreateUser(UserUtility.ADMINISTRATOR_USERNAME, UserUtility.DEFAULT_ADMINISTRATOR_PASSWORD, "subodh.shah@hotmail.com",
                    "What is the name of  Grand Father (Father's Father)?", "Ratanchand", true, out status);
                if (status != MembershipCreateStatus.Success)
                    log.WarnFormat("Failed to create " + UserUtility.ADMINISTRATOR_USERNAME + " user with status {0}", status.ToString());
                else
                    log.DebugFormat("Created " + UserUtility.ADMINISTRATOR_USERNAME + " user with status {0}", status.ToString());
            }
        }

        public static DialogResult ShowDialog(ref MembershipUser user)
        {
            LoginForm dialog = new LoginForm();
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
            bool success = Membership.ValidateUser(userNameTextBox.Text, passwordTextBox.Text);
            if (!success)
            {
                MessageBox.Show("Invalid user name or password.", "Authentication Failure", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                user = Membership.GetUser(userNameTextBox.Text);
                UserUtility.SetAuthenticatedUserName(user.UserName);
            }
            return success ? DialogResult.OK : DialogResult.None;
        }

        private void forgotPasswordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MembershipUser user = null;
            this.Hide();
            DialogResult result = ForgotPasswordForm.ShowDialog(ref user);
            if (result == DialogResult.OK)
            {
                // show Change password form
                result = ChangePasswordForm.ShowDialog(ref user);
                if (result != DialogResult.OK)
                    Application.Exit();
            }
            this.Show();
        }
    }
}
