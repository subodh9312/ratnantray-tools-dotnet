using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Footsteps.Model;
using Footsteps.Controller.Library;
using Footsteps.Controller.Utilities;
using System.Web.UI.HtmlControls;

namespace Footsteps.UserControls.RecentComments
{
    public partial class RecentComments : System.Web.UI.UserControl
    {
        public List<Comment> RecentItems { get; set; }
        public bool IsMobileDevice { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsMobileDevice)
            {
                RecentComents.Font.Size = 8;
                RecentComents.Font.Italic = true;
            }
            if (RecentItems != null && RecentItems.Count > 0)
            {
                RecentComents.DataSource = RecentItems;
                RecentComents.DataBind();
            }
            else
                RecentComents.ShowHeader = RecentComents.ShowFooter = false;
        }

        protected string GetDisplayText(string input)
        {
            if (input.Length <= Constants.TextLengthSiteMaster)
                return input;
            input = input.Substring(0, Constants.TextLengthSiteMaster - 3);

            input += "...";
            return input;
        }
    }
}