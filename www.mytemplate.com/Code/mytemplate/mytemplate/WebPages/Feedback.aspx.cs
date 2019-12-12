using System;
using System.Web.UI;
using System.Web.Security;
using System.Net.Mail;
using mytemplate.Controller.Utilities;

namespace mytemplate.WebPages
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Feedback - My Template";
            MetaDescription = "feedback for My Template, my template provide feedback for improvement";
            MetaKeywords = "mytemplate.com feedback, feedback mytemplate.com";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (MyCaptcha1.IsValid)
            {
                try
                {
                    MailMessage Message = new MailMessage(MailUtility.SiteAdminstratorMail, MailUtility.SiteAdminstratorMail);

                    Message.Subject = String.Format("My Template: Feedback recieved on {0}", DateTime.Now.ToShortDateString());

                    Message.Priority = MailPriority.Normal;
                    Message.IsBodyHtml = true;
                    Message.Body = MailUtility.ReadFile(MailUtility.FeedBack);

                    Message.Body = Message.Body.Replace("<%Date%>", DateTime.Now.ToShortDateString());
                    Message.Body = Message.Body.Replace("<%Experience%>", Experience.SelectedItem.Text);
                    Message.Body = Message.Body.Replace("<%Dissatisfied%>", Dissatisfied.SelectedValue);
                    Message.Body = Message.Body.Replace("<%Correction%>", Corrections.Text);
                    Message.Body = Message.Body.Replace("<%Comparison%>", Comparison.SelectedItem.Text);
                    Message.Body = Message.Body.Replace("<%Competitor%>", Competitor.Text);
                    Message.Body = Message.Body.Replace("<%Suggestions%>", Suggestions.Text);

                    Message.Body = Message.Body.Replace("<%Name%>", Name.Text);
                    Message.Body = Message.Body.Replace("<%CityLocation%>", CityLocation.Text);
                    Message.Body = Message.Body.Replace("<%Email%>", Email.Text);
                    Message.Body = Message.Body.Replace("<%userid%>", "");
                    Message.Body = Message.Body.Replace("<%ContactNumber%>", ContactNumber.Text);

                    MailUtility.GetSmtpSettings().Send(Message);

                    // insert the value in the database
                    Model.Feedback feedback = new Model.Feedback();
                    feedback.Name = Name.Text;
                    feedback.City = CityLocation.Text;
                    feedback.EmailAddress = Email.Text;
                    feedback.ContactNo = ContactNumber.Text;
                    feedback.OverallExperience = Experience.SelectedItem.Text;
                    feedback.DissatisfiedWith = Dissatisfied.SelectedItem.Text;
                    feedback.CorrectIt = Corrections.Text;
                    feedback.Rating = Comparison.SelectedItem.Text;
                    feedback.WebsiteComparison = Competitor.Text;
                    feedback.Suggestions = Suggestions.Text;

                    BizUtility bizUtililty = new BizUtility();
                    bizUtililty.InsertFeedback(feedback);

                    Result.Text = "Feedback Posted successfully. Thank you!";
                }
                catch
                {
                    Result.Text = "Feedback could not be posted at this time! Please retry again later.";
                }
                SubmitPanel.Visible = false;
                ResultPanel.Visible = true;
            }
            else
            {
                lblCheckResult.Text = "Incorrect Verification Code. Please Try Again.";
            }
        }
    }
}