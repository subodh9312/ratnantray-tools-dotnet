
namespace Footsteps.Controller
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
    using Footsteps.Model;
    using Footsteps.Controller.Content_Staging;


    // Implements application logic using the FootstepsEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class Biz : LinqToEntitiesDomainService<FootstepsEntities>
    {
        #region Comment
        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Comment' query.
        public IQueryable<Comment> GetComment()
        {
            return ApprovalContentStagingWithoutDrafts.GetEntity(this.ObjectContext.Comment.OrderBy(c => c.Id));
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
        #endregion

        #region Feedback
        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Feedback' query.
        [RequiresRole("Administrator")]
        public IQueryable<Feedback> GetFeedback()
        {
            return this.ObjectContext.Feedback.OrderBy(c => c.Id);
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


