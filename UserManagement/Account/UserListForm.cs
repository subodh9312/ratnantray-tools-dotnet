using System.Web.Security;
using System.Windows.Forms;

namespace UserManagement.Account
{
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
            PopulateListViewControl(listView1);
        }

        public void PopulateListViewControl(ListView listViewControl)
        {
            listViewControl.Items.Clear();
            listViewControl.Columns.Clear();

            listViewControl.View = View.Tile;
            listViewControl.Columns.Add("Name", 100);
            listViewControl.Columns.Add("Description", 400);
            listViewControl.TileSize = new System.Drawing.Size(300, 40);

            foreach (MembershipUser user in Membership.GetAllUsers())
            {
                ListViewItem item = new ListViewItem();
                item.Name = user.UserName;
                item.Text = user.UserName;

                item.SubItems.Add(user.Email);
                listViewControl.Items.Add(item);
            }
        }
    }
}
