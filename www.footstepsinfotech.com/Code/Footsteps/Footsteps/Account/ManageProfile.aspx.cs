using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Footsteps.Controller.Utilities;
using System.Web.Security;
using System.Web.DynamicData;
using Footsteps.Model;

namespace Footsteps.Account
{
    public partial class ManageProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User == null || !HttpContext.Current.Request.IsAuthenticated)
            {
                // User is not logged in. So there is nothing to manage profile.
                // Redirect the user to the login page.
                // Convert this page into Read Only Page for viewing the profiles
                string userName = String.IsNullOrEmpty(Request.QueryString["UserName"]) ? null : Request.QueryString["UserName"];
                if (userName == null)
                {
                    Response.Redirect(FormsAuthentication.LoginUrl);
                    return;
                }

                CreateUserButton.Visible = false;
                FirstName.ReadOnly = true;
                LastName.ReadOnly = true;
                Education.ReadOnly = true;

                Title = "View User Profile";

                BizUtility bizUtility = new BizUtility();

                if (!IsPostBack)
                    FromValue(WebProfile.GetProfile(userName), false);
            }
            else if (!IsPostBack)
            {
                FromValue(WebProfile.Current, true);
                Title = "Update Profile - Footsteps Infotech Inc.";
            }
            UserName.ReadOnly = true;
            UserName.Enabled = false;

            if (IsPostBack)
                UserName.Text = Email.Text;
        }

        private void FromValue(WebProfile profile, bool isLoggedInUser)
        {
            FirstName.Text = profile.FirstName;
            LastName.Text = profile.LastName;
            Education.Text = profile.Education;
            ContactNo.Text = profile.ContactNo;
            Email.Text = UserName.Text = profile.EmailAddress;
            string temp = profile.WorkPreference;
            ListItem item = WorkPrefrence.Items.FindByText(temp);
            WorkPrefrence.SelectedValue = item.Value;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            bool isLoggedInUser = !(HttpContext.Current.User == null || !HttpContext.Current.Request.IsAuthenticated);
            string userName = String.IsNullOrEmpty(Request.QueryString["UserName"]) ? null : Request.QueryString["UserName"];
            if (literal != null)
            {
                if (isLoggedInUser)
                    literal.Text = "Footsteps Infotech Inc. - Manage Profile";
                else
                    literal.Text = "Footsteps Infotech Inc. - View Profile";
            }
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
            {
                if (isLoggedInUser)
                    literal.Text = "Use the form below to update your profile.";
                else
                    literal.Text = "The Profile Details for user " + userName;
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ToValue();

            ResultLabel.Text = "Profile has been updated successfully.";
        }

        private void ToValue()
        {
            WebProfile.Current.FirstName = FirstName.Text;
            WebProfile.Current.LastName = LastName.Text;
            WebProfile.Current.Education = Education.Text;
            WebProfile.Current.ContactNo = ContactNo.Text;
            WebProfile.Current.EmailAddress = Email.Text;
            WebProfile.Current.WorkPreference = WorkPrefrence.Text;

            if (UploadPhoto.PostedFile != null &&
                !String.IsNullOrEmpty(UploadPhoto.PostedFile.FileName))
            {
                byte[] imageSize = new byte
                              [UploadPhoto.PostedFile.ContentLength];
                HttpPostedFile uploadedImage = UploadPhoto.PostedFile;
                uploadedImage.InputStream.Read
                   (imageSize, 0, (int)UploadPhoto.PostedFile.ContentLength);

                // the imageSize array should now contain the uploaded image
                WebProfile.Current.ResumeData = imageSize;
            }
            WebProfile.Current.Save();
        }
    }
}