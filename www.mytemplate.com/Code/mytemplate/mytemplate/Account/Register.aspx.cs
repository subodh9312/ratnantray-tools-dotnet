using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using mytemplate.Controller.Utilities;
using System.Web.DynamicData;
using mytemplate.Controller.Library;

namespace mytemplate.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "My Template - Registeration";
            MetaDescription = "My Template Register into your account.";
            MetaKeywords = "My Template registration, Register at My Template";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "My Template - Registration";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Use the form below to Register @ My Template.";

            if (IsPostBack)
                RegisterUser.Email = RegisterUser.UserName;

            RegisterUser.MailDefinition.From = MailUtility.SiteAdminstratorMail;
            RegisterUser.MailDefinition.BodyFileName = MetaModel.Default.DynamicDataFolderVirtualPath + "Content/EmailTemplates/AccountActivation.htm";
            RegisterUser.MailDefinition.Subject = "My Template: Steps to activate your new account...";

        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            string user = RegisterUser.UserName;
            MembershipUser userInfo = Membership.GetUser(RegisterUser.UserName);
            Roles.AddUsersToRole(new string[] { user }, "RegisteredUser");
            WebProfile profile = WebProfile.GetProfile(user);
            TextBox textBox = RegisterUserWizardStep.Controls[0].Controls[3] as TextBox;
            if (textBox != null)
                profile.FirstName = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[6] as TextBox;
            if (textBox != null)
                profile.LastName = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[9] as TextBox;
            if (textBox != null)
                profile.Education = textBox.Text;

            textBox = RegisterUserWizardStep.Controls[0].Controls[22] as TextBox;
            if (textBox != null)
                profile.CellNo1 = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[25] as TextBox;
            if (textBox != null)
                profile.CellNo2 = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[28] as TextBox;
            if (textBox != null)
                profile.DirectNo = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[31] as TextBox;
            if (textBox != null)
                profile.SwitchBoardNo = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[33] as TextBox;
            if (textBox != null)
                profile.Extension = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[36] as TextBox;
            if (textBox != null)
                profile.Organisation = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[38] as TextBox;
            if (textBox != null)
                profile.City = textBox.Text;

            FileUpload UploadPhoto = RegisterUserWizardStep.Controls[0].Controls[40] as FileUpload;
            if (UploadPhoto != null && UploadPhoto.PostedFile != null &&
                !String.IsNullOrEmpty(UploadPhoto.PostedFile.FileName))
            {
                byte[] imageSize = new byte
                              [UploadPhoto.PostedFile.ContentLength];
                HttpPostedFile uploadedImage = UploadPhoto.PostedFile;
                uploadedImage.InputStream.Read
                   (imageSize, 0, (int)UploadPhoto.PostedFile.ContentLength);

                // the imageSize array should now contain the uploaded image
                profile.ProfilePicture = imageSize;
            }

            profile.Save();

            RegisterUser.Email = RegisterUser.UserName;
        }

        protected void RegisterUser_SendingMail(object sender, MailMessageEventArgs e)
        {
            MembershipUser UserInfo = Membership.GetUser(RegisterUser.UserName);

            if (String.IsNullOrEmpty(UserInfo.Email))
            {
                UserInfo.Email = UserInfo.UserName;
                Membership.UpdateUser(UserInfo);
            }

            string VerifyURL = Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Account/VerifyUserAccount.aspx?ID=" + UserInfo.ProviderUserKey.ToString());

            e.Message.Body = e.Message.Body.Replace("<%VerifyUrl%>", VerifyURL);
        }
    }
}
