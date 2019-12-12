using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Footsteps.WebPages
{
    public partial class TermsOfUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Status = "301 Moved Permanently";
            Response.StatusCode = 301;
            Response.StatusDescription = "Moved Permanently";
            Response.Redirect("~/");
        }
    }
}