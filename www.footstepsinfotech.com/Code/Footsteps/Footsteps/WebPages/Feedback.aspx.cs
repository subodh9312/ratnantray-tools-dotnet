using System;
using System.Web.UI;
using System.Web.Security;
using System.Net.Mail;
using Footsteps.Controller.Utilities;

namespace Footsteps.WebPages
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Feedback - Footsteps Infotech Inc.";
            MetaDescription = "feedback for Footsteps Infotech Inc., Footsteps Infotech Inc. provide feedback for improvement";
            MetaKeywords = "Footsteps.com feedback, feedback Footsteps.com";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
        }
    }
}