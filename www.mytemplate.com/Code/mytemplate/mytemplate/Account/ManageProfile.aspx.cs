using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mytemplate.Controller.Utilities;
using System.Web.Security;
using System.Web.DynamicData;
using mytemplate.Model;

namespace mytemplate.Account
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

                Submit.Visible = false;
                FirstName.ReadOnly = true;
                LastName.ReadOnly = true;
                Education.ReadOnly = true;
                Organisation.ReadOnly = true;

                FieldsetLabel.Text = "View User Profile";
                Title = "View User Profile";

                BizUtility bizUtility = new BizUtility();

                if (!IsPostBack)
                    FromValue(WebProfile.GetProfile(userName), false);
            }
            else if (!IsPostBack)
            {
                FromValue(WebProfile.Current, true);
                Title = "Update Profile - My Template";
            }
        }

        private void FromValue(WebProfile profile, bool isLoggedInUser)
        {
            FirstName.Text = profile.FirstName;
            LastName.Text = profile.LastName;
            Education.Text = profile.Education;
            Organisation.Text = profile.Organisation;
            CellNo1.Text = profile.CellNo1;
            CellNo2.Text = profile.CellNo2;
            DirectNo.Text = profile.DirectNo;
            SwitchBoardNo.Text = profile.SwitchBoardNo;
            Extension.Text = profile.Extension;
            City.Text = profile.City;

            ProfilePicture.ImageUrl = ImageUtilities.GetImageUrl(profile);
            if (isLoggedInUser)
                UploadPhotoLabel.Text = "Change Profile Picture";
            else
            {
                UploadPhotoLabel.Visible = false;
                UploadPhoto.Visible = false;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            bool isLoggedInUser = !(HttpContext.Current.User == null || !HttpContext.Current.Request.IsAuthenticated);
            string userName = String.IsNullOrEmpty(Request.QueryString["UserName"]) ? null : Request.QueryString["UserName"];
            if (literal != null)
            {
                if (isLoggedInUser)
                    literal.Text = "My Template - Manage Profile";
                else
                    literal.Text = "My Template - View Profile";
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

            ProfilePicture.ImageUrl = Page.ResolveUrl(ImageUtilities.GetImageUrl(WebProfile.Current));
            UploadPhotoLabel.Text = "Change Profile Picture";
        }

        private void ToValue()
        {
            WebProfile.Current.FirstName = FirstName.Text;
            WebProfile.Current.LastName = LastName.Text;
            WebProfile.Current.Education = Education.Text;
            WebProfile.Current.Organisation = Organisation.Text;
            WebProfile.Current.CellNo1 = CellNo1.Text;
            WebProfile.Current.CellNo2 = CellNo2.Text;
            WebProfile.Current.City = City.Text;
            WebProfile.Current.DirectNo = DirectNo.Text;
            WebProfile.Current.SwitchBoardNo = SwitchBoardNo.Text;
            WebProfile.Current.Extension = Extension.Text;

            if (UploadPhoto.PostedFile != null &&
                !String.IsNullOrEmpty(UploadPhoto.PostedFile.FileName))
            {
                byte[] imageSize = new byte
                              [UploadPhoto.PostedFile.ContentLength];
                HttpPostedFile uploadedImage = UploadPhoto.PostedFile;
                uploadedImage.InputStream.Read
                   (imageSize, 0, (int)UploadPhoto.PostedFile.ContentLength);

                // the imageSize array should now contain the uploaded image
                WebProfile.Current.ProfilePicture = imageSize;
            }
        }
    }
}