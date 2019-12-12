using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Footsteps.Controller.Utilities;
using System.Web.DynamicData;
using Footsteps.Controller.Library;

namespace Footsteps.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Footsteps Infotech Inc. - Registeration";
            MetaDescription = "Footsteps Infotech Inc. Register into your account.";
            MetaKeywords = "Footsteps Infotech Inc. registration, Register at Footsteps Infotech Inc.";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "Footsteps Infotech Inc. - Registration";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Use the form below to Register @ Footsteps Infotech Inc..";

            if (IsPostBack)
                RegisterUser.Email = RegisterUser.UserName;

            RegisterUser.MailDefinition.From = MailUtility.SiteAdminstratorMail;
            RegisterUser.MailDefinition.BodyFileName = MetaModel.Default.DynamicDataFolderVirtualPath + "Content/EmailTemplates/AccountActivation.htm";
            RegisterUser.MailDefinition.Subject = "Footsteps Infotech Inc.: Steps to activate your new account...";

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in RegisterUserWizardStep.Controls[0].Controls)
            {
                TextBox textBox = control as TextBox;
                if (textBox != null)
                    textBox.Text = "";
                else
                {
                    DropDownList dropDownList = control as DropDownList;
                    if (dropDownList != null)
                        dropDownList.SelectedIndex = 0;
                }
            }
            RegisterUser.UserName = "";
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            string user = RegisterUser.UserName;
            MembershipUser userInfo = Membership.GetUser(RegisterUser.UserName);
            Roles.AddUsersToRole(new string[] { user }, "RegisteredUser");
            WebProfile profile = WebProfile.GetProfile(user);
            TextBox textBox = null;
            foreach (Control control in RegisterUserWizardStep.Controls[0].Controls)
            {
                textBox = control as TextBox;
                if (textBox != null)
                {
                    switch (textBox.ID)
                    {
                        case "FirstName":
                            profile.FirstName = textBox.Text;
                            break;
                        case "LastName":
                            profile.LastName = textBox.Text;
                            break;
                        case "Education":
                            profile.Education = textBox.Text;
                            break;
                        case "ContactNo":
                            profile.ContactNo = textBox.Text;
                            break;
                    }
                }
                else
                {
                    DropDownList dropDownList = control as DropDownList;
                    if (dropDownList != null)
                    {
                        profile.WorkPreference = dropDownList.Text;
                    }
                    else
                    {
                        FileUpload UploadPhoto = control as FileUpload;
                        if (UploadPhoto != null && UploadPhoto.PostedFile != null &&
                            !String.IsNullOrEmpty(UploadPhoto.PostedFile.FileName))
                        {
                            byte[] imageSize = new byte
                                          [UploadPhoto.PostedFile.ContentLength];
                            HttpPostedFile uploadedImage = UploadPhoto.PostedFile;
                            uploadedImage.InputStream.Read
                               (imageSize, 0, (int)UploadPhoto.PostedFile.ContentLength);

                            // the imageSize array should now contain the uploaded image
                            profile.ResumeData = imageSize;
                        }
                    }
                }
            }
            profile.EmailAddress = RegisterUser.UserName;
            profile.Save();

            /*TextBox textBox = RegisterUserWizardStep.Controls[0].Controls[3] as TextBox;
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
                profile.ContactNo = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[25] as TextBox;
            if (textBox != null)
                profile.EmailAddress = textBox.Text;
            textBox = RegisterUserWizardStep.Controls[0].Controls[31] as TextBox;
            if (textBox != null)
                profile.WorkPrefrence = textBox.Text;

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
                profile.ResumePath = imageSize.ToString();
            }

            profile.Save();*/

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

            string VerifyURL = Request.Url.GetLeftPart(UriPartial.Authority) +
                Page.ResolveUrl("~/Account/VerifyUserAccount.aspx?ID=" + UserInfo.ProviderUserKey.ToString());

            e.Message.Body = e.Message.Body.Replace("<%VerifyUrl%>", VerifyURL);
            e.Message.Body = e.Message.Body.Replace("<%UserName%>", UserInfo.UserName);
            e.Message.Body = e.Message.Body.Replace("<%Password%>", Membership.Provider.GetPassword(RegisterUser.UserName, null));
        }
    }
}
