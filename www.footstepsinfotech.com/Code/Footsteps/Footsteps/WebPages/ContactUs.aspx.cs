using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using Footsteps.Controller.Utilities;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Footsteps.WebPages
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
            Title = "Contact Us - Footsteps Infotech Inc.";
            MetaDescription = "Write to us with your feedback and suggestions. "
                + " Do let us know what you think and what are you feel and would help us serve you better.";
            MetaKeywords = "Contact us, Write to Us, Have your Say, Reach Us - Footsteps Infotech Inc.";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            MessageTextBox.Text = "";
            Email.Text = "";
            Name.Text = "";
            ResultPanel.Visible = false;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(MessageTextBox.Text)
                    || String.IsNullOrEmpty(Email.Text)
                    || String.IsNullOrEmpty(Name.Text))
                {
                    // input not specified
                    ResultPanel.Visible = true;
                    Result.Text = "Please enter all the fields. All fields are mandatory!";
                    return;
                }
                else if (!IsValidEmail(Email.Text))
                {
                    ResultPanel.Visible = true;
                    Result.Text = "Please enter a valid email addresss.";
                    return;
                }

                MailMessage Message = new MailMessage(MailUtility.SiteAdminstratorMail, MailUtility.SiteAdministratorContactMail);

                //if (CCMe.Checked)
                //    Message.CC.Add(Email.Text);

                Message.Subject = String.Format("Footsteps Infotech Inc.: Message recieved on {0}", DateTime.Now.ToShortDateString());

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
            ResultPanel.Visible = true;
        }

        public bool IsValidEmail(string emailAddress)
        {
            bool invalid = false;
            try
            {
                if (String.IsNullOrEmpty(emailAddress))
                    return false;

                // Use IdnMapping class to convert Unicode domain names.
                emailAddress = Regex.Replace(emailAddress, @"(@)(.+)$", this.DomainMapper);
                if (invalid)
                    return false;

                // Return true if emailAddress is in valid e-mail format.
                return Regex.IsMatch(emailAddress,
                       @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                       @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                       RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (Exception e)
            {
                throw e;
            }
            return match.Groups[1].Value + domainName;
        }

    }
}