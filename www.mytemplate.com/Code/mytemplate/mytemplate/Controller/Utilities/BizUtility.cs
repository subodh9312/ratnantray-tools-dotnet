
namespace mytemplate.Controller.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using mytemplate.Model;
    using System.Threading;
    using mytemplate.Controller.Library;
    using System.Web.Security;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Text;
    using System.Data.Common;


    // Implements application logic using the MyTemplateEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class BizUtility : LinqToEntitiesDomainService<MyTemplateEntities>
    {
        #region Comments
        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Comment' query.
        private IQueryable<Comment> GetComment()
        {
            return this.ObjectContext.Comment.OrderBy(c => c.Id);
        }

        public void InsertComment(Comment comment)
        {
            if ((comment.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(comment, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Comment.AddObject(comment);
            }
        }

        public void UpdateComment(Comment currentComment)
        {
            this.ObjectContext.Comment.AttachAsModified(currentComment, this.ChangeSet.GetOriginal(currentComment));
        }

        public void DeleteComment(Comment comment)
        {
            if ((comment.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Comment.Attach(comment);
            }
            this.ObjectContext.Comment.DeleteObject(comment);
        }

        public List<Comment> GetComments(int entityId, EntityType entityType)
        {
            return GetComment().Where(c => c.EntityId == entityId 
                && c.EntityType == Convert.ToInt32(entityType) 
                && c.Milestone == "Approved").ToList();
        }
        #endregion

        #region Utility Methods
        public byte[] GetProfilePicture(string userName)
        {
            object key = Membership.GetUser(userName).ProviderUserKey;
            Database database = DatabaseFactory.CreateDatabase();
            StringBuilder builder = new StringBuilder();
            builder.Append(" SELECT ProfilePicture FROM aspnet_Custom_UserDetails WHERE Upper(UserId) = '");
            builder.Append(key.ToString().ToUpper());
            builder.Append("' ");
            DbCommand dbCommand = database.GetSqlStringCommand(builder.ToString());
            object result = null;
            try
            {
                dbCommand.Connection = database.CreateConnection();
                dbCommand.Connection.Open();
                result = dbCommand.ExecuteScalar();
            }
            finally
            {
                if (dbCommand.Connection != null)
                    dbCommand.Connection.Close();
            }
            return result as byte[];
        }

        public static string ToUpperInvariant(string input)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }
        #endregion

        #region Feedback
        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Feedback' query.
        private IQueryable<Feedback> GetFeedback()
        {
            return this.ObjectContext.Feedback;
        }

        public void InsertFeedback(Feedback feedback)
        {
            if ((feedback.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(feedback, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Feedback.AddObject(feedback);
            }

            // Save Changes
            this.ObjectContext.SaveChanges();
        }

        public void UpdateFeedback(Feedback currentFeedback)
        {
            this.ObjectContext.Feedback.AttachAsModified(currentFeedback, this.ChangeSet.GetOriginal(currentFeedback));
        }

        public void DeleteFeedback(Feedback feedback)
        {
            if ((feedback.EntityState == EntityState.Detached))
            {
                this.ObjectContext.Feedback.Attach(feedback);
            }
            this.ObjectContext.Feedback.DeleteObject(feedback);
        }
        #endregion
    }
}


