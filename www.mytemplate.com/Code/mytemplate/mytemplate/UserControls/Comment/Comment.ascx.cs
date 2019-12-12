using System;
using System.Web.Security;
using mytemplate.Controller.Utilities;
using mytemplate.Model;
using mytemplate.Controller.Library;

namespace mytemplate.UserControls.CommentCtrl
{
    public partial class CommentCtrl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Membership.GetUser() != null)
                {
                    SubmitterName.Text = Membership.GetUser().UserName;
                    SubmitterEmail.Text = Membership.GetUser().Email;
                    SubmitterName.Enabled = SubmitterEmail.Enabled = false;
                }
            }
        }

        public void DataBindComment(int entityId, EntityType entityType)
        {
            HiddenEntityId.Value = entityId.ToString();
            HiddedEntityType.Value = Convert.ToInt32(entityType).ToString();
            BizUtility bizUtility = new BizUtility();

            GV1.DataSource = bizUtility.GetComments(entityId, entityType);
            GV1.DataBind();
        }

        protected void SubmitComment_Click(object sender, EventArgs e)
        {
            if (!MyCaptcha1.IsValid)
            {
                lblCheckResult.Text = "Invalid Code, please retry!";
            }
            else
            {
                lblCheckResult.Text = "";
                SubmitConfirmation.Text = "";

                BizUtility bizUtility = new BizUtility();

                Comment comment = new Comment();

                comment.EntityId = Convert.ToInt32(HiddenEntityId.Value);
                comment.EntityType = Convert.ToInt32(HiddedEntityType.Value);
                comment.CommentText = CommentText.Text;
                comment.SubmitDate = DateTime.Now;
                comment.SubmitterName = SubmitterName.Text;
                comment.SubmitterEmail = SubmitterEmail.Text;
                comment.SubmitterWebsite = WebsiteText.Text;
                comment.Milestone = "Submitted";

                bizUtility.InsertComment(comment);
                                
                CommentText.Text = "";
                SubmitConfirmation.Text = "Thank you! Your Comment has been submitted for moderation.";
                SubmitConfirmation.Visible = true;
            }
        }
    }
}