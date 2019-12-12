using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Security;
using System.Windows.Forms;
using UserManagement.Utils;

namespace UserManagement.Account
{
    public partial class SelectUserForm : Form
    {
        public SelectUserForm()
        {
            InitializeComponent();

            MembershipUserCollection users = Membership.GetAllUsers();
            List<MembershipUser> userList = new List<MembershipUser>();
            string[] usersToIgnore = { UserUtility.ADMINISTRATOR_USERNAME.ToUpper(), UserUtility.GetAuthenticatedUserName().ToUpper() };
            foreach (MembershipUser user in users)
            {
                if (usersToIgnore.Contains(user.UserName.ToUpper()))
                    continue;
                userList.Add(user);
            }

            usersComboBox.DataSource = userList;
        }

        public static DialogResult ShowDialog(ref MembershipUser user)
        {
            SelectUserForm dialog = new SelectUserForm();

            if (dialog.usersComboBox.Items.Count < 1)
            {
                MessageBox.Show("ERR: There are no users in the system.", 
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DialogResult.Cancel;
            }

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
            user = usersComboBox.SelectedItem as MembershipUser;
            return DialogResult.OK;
        }
    }
}
