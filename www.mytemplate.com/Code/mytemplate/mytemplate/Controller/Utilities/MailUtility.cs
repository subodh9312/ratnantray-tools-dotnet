using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.IO;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net;
using System.Web.Configuration;
using System.Web.Security;
using System.ComponentModel;
using System.Diagnostics;
using mytemplate.Controller.Library;
using System.Text;
using mytemplate.Model;
using System.Web.DynamicData;


namespace mytemplate.Controller.Utilities
{
    public interface IMailable
    {
        int Id { get; set; }
        string SubmitterEmail { get; set; }
        string SubmitterName { get; set; }
    }

    public class MailUtility
    {
        private static SmtpClient MailClient;

        // Constants
        public static string SiteAdminstratorMail
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteAdministratorMail"];
            }
        }

        // Site Administrator Contact Email
        public static string SiteAdministratorContactMail
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteAdministratorContactMail"];
            }
        }

        // Site Administrator Display Name
        public static string SiteAdminstratorDisplayName 
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteAdministratorDisplayName"];
            }
        }

        public const string Submitted = "~/DynamicData/Content/EmailTemplates/TypeSubmitted.htm";
        public const string SubmittedToModerators = "~/DynamicData/Content/EmailTemplates/TypeSubmittedToModerators.htm";
        public const string Updated = "~/DynamicData/Content/EmailTemplates/TypeUpdated.htm";
        public const string UpdatedToModerators = "~/DynamicData/Content/EmailTemplates/TypeUpdatedToModerators.htm";
        public const string Approved = "~/DynamicData/Content/EmailTemplates/TypeApproved.htm";
        public const string ApprovedToApprover = "~/DynamicData/Content/EmailTemplates/TypeApprovedToApprover.htm";
        public const string Rejected = "~/DynamicData/Content/EmailTemplates/TypeRejected.htm";
        public const string RejectedToRejector = "~/DynamicData/Content/EmailTemplates/TypeRejectedToRejector.htm";
        public const string Message = "~/DynamicData/Content/EmailTemplates/Message.htm";
        public const string FeedBack = "~/DynamicData/Content/EmailTemplates/Feedback.htm";

        public static string ReadFile(string fileName)
        {
            // Uri uri = new Uri(fileName);

            string Return = null;

            StreamReader Stream = File.OpenText(HttpContext.Current.Server.MapPath(fileName));
            Return = Stream.ReadToEnd();
            Stream.Close();

            return Return;
        }

        public static SmtpClient GetSmtpSettings()
        {
            Configuration Config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup Settings = (MailSettingsSectionGroup)Config.GetSectionGroup("system.net/mailSettings");

            MailClient = new SmtpClient();


            MailClient.UseDefaultCredentials = false;
            MailClient.Host = Settings.Smtp.Network.Host;
            MailClient.Port = Settings.Smtp.Network.Port;
            MailClient.Credentials = new NetworkCredential(Settings.Smtp.Network.UserName, Settings.Smtp.Network.Password);

            return MailClient;
        }

        public static void SendMail(string entityType, string entityURL, string entityName, string templateFileName, string mailTo, string userTo, string subject, bool async = true)
        {
            try
            {
                MailMessage Message = new MailMessage();

                Message.From = new MailAddress(SiteAdminstratorMail, "My Template");

                string[] Tos = mailTo.Split(',');
                foreach (string To in Tos)
                    Message.To.Add(To);

                Message.Subject = subject;

                Message.Priority = MailPriority.Normal;
                Message.IsBodyHtml = true;
                Message.Body = ReadFile(templateFileName);

                if (async)
                {
                    //wire up the event for when the Async send is completed
                    object userState = Message;
                    GetSmtpSettings().SendCompleted += new SendCompletedEventHandler(SmtpClient_OnCompleted);

                    GetSmtpSettings().SendAsync(Message, userState);
                }
                else
                    GetSmtpSettings().Send(Message);
            }
            catch (Exception e)
            {
                string exce = e.Message;
            }
        }

        public static void SendMail(string SiteAdminstratorMail, string SiteAdminstratorName, string body, string mailTo, string subject, bool async = true)
        {
            try
            {
                MailMessage Message = new MailMessage();

                Message.From = new MailAddress(SiteAdminstratorMail, SiteAdminstratorName);

                string[] Tos = mailTo.Split(',');
                foreach (string To in Tos)
                    Message.To.Add(To);

                Message.Subject = subject;
                Message.Body = body;

                Message.Priority = MailPriority.Normal;
                Message.IsBodyHtml = true;

                if (async)
                {
                    //wire up the event for when the Async send is completed
                    object userState = Message;
                    GetSmtpSettings().SendCompleted += new SendCompletedEventHandler(SmtpClient_OnCompleted);

                    GetSmtpSettings().SendAsync(Message, userState);
                }
                else
                    GetSmtpSettings().Send(Message);
            }
            catch (Exception e)
            {
                string exce = e.Message;
            }
        }

        public static void SmtpClient_OnCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //Get the Original MailMessage object
            MailMessage mail = (MailMessage)e.UserState;

            //write out the subject
            string subject = mail.Subject;

            if (e.Error != null)
            {
                Debug.WriteLine("Error {1} occurred when sending mail [{0}] ", subject, e.Error.ToString());
            }
            else
            {
                Debug.WriteLine("Message [{0}] sent.", subject);
            }
        }

        public static List<UserNameAndEmail> GetUserNameAndEmails(string exceptUser = "")
        {
            List<UserNameAndEmail> UsersAndEmails = new List<UserNameAndEmail>();
            string[] Users = Roles.GetUsersInRole("Moderator");
            foreach (string User in Users)
            {
                if (exceptUser.Equals(User))
                    continue;
                UsersAndEmails.Add(new UserNameAndEmail()
                {
                    Email = Membership.GetUser(User).Email,
                    UserName = User
                });
            }
            return UsersAndEmails;
        }

        public static string GetUserEmails(string exceptUser = "")
        {
            List<UserNameAndEmail> UsersAndEmails = GetUserNameAndEmails(exceptUser);

            string UserEmails = "";
            foreach (UserNameAndEmail UserAndEmail in UsersAndEmails)
            {
                if (UserEmails == "")
                    UserEmails = UserAndEmail.Email;
                else
                    UserEmails += "," + UserAndEmail.Email;
            }

            return UserEmails;
        }

        public static string ReplaceTokens(string body, IMailable currentObject, string entityType)
        {
            StringBuilder builder = new StringBuilder(body);
            builder = builder.Replace("<%Username%>", currentObject.SubmitterName);
            builder = builder.Replace("<%Type%>", entityType);
            builder = builder.Replace("<%Name%>", currentObject.GetType().Name);
            builder = builder.Replace("<%TypeLink%>", GetApprovedEntityUrl(currentObject));

            builder = builder.Replace("<%UpdateUser%>", Membership.GetUser().UserName);
            builder = builder.Replace("<%UpdateDate%>", DateTime.Now.ToShortDateString());

            return builder.ToString();
        }

        private static string GetApprovedEntityUrl(IMailable currentObject)
        {
            return MetaModel.Default.GetActionPath(MetaModel.Default.GetTable(currentObject.GetType()).Name, PageAction.Details, currentObject);
        }
    }
}