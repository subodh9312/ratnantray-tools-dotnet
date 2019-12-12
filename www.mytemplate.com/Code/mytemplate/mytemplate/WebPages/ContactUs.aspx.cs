using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using mytemplate.Controller.Utilities;

namespace mytemplate.WebPages
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink hyperlink = Page.Master.FindControl("TitleHyperLink") as HyperLink;
            if (hyperlink != null)
            {
                hyperlink.Text = "Contact Information";
                hyperlink.NavigateUrl = "~/WebPages/Contact.aspx";
            }
            Literal literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Our Contact Information";
            Title = "Contact Us - My Template";
            MetaDescription = "Write to us with your feedback and suggestions. "
                + " Do let us know what you think and what are you feel would help us serve you better.";
            MetaKeywords = "Contact us, Write to Us, Have your Say, Reach Us";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage Message = new MailMessage(MailUtility.SiteAdminstratorMail, MailUtility.SiteAdministratorContactMail);

                Message.Subject = String.Format("My Template: Message recieved on {0}", DateTime.Now.ToShortDateString());

                Message.Priority = MailPriority.Normal;
                Message.IsBodyHtml = true;
                Message.Body = MailUtility.ReadFile(MailUtility.Message);

                Message.Body = Message.Body.Replace("<%Email%>", Email.Text);
                Message.Body = Message.Body.Replace("<%Name%>", Name.Text);
                Message.Body = Message.Body.Replace("<%Message%>", MessageTextBox.Text);

                MailUtility.GetSmtpSettings().Send(Message);

                Result.Text = "Message has been Posted successfully. Thank you!";
            }
            catch
            {
                Result.Text = "Feedback could not be posted at this time! Please retry again later.";
            }
            SubmitPanel.Visible = false;
            ResultPanel.Visible = true;
        }

    }
}