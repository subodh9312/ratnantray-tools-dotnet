using System.Linq;
using DynamicDataExtensions.Linq.LinqHelper;
using System.Web;
using System.Web.Security;
using Footsteps.Model.ModelExtensions;
using Footsteps.Controller.Library;
using Footsteps.Controller.Utilities;

namespace Footsteps.Controller.Content_Staging
{
    public static class ApprovalContentStagingWithoutDrafts
    {
        /// <summary>
        /// Returns the list of the entities which are visible to current logged in User
        /// depending upon his role.
        /// </summary>
        /// <typeparam name="T">Type of the Entities</typeparam>
        /// <param name="Entities">All the enitites in all the loadedStates</param>
        /// <returns>Filtered list of the Entities which are visible to the user</returns>
        public static IQueryable<T> GetEntity<T>(IQueryable<T> Entities)
        {
            if (HttpContext.Current.User.IsInRole("Administrator"))
            {
                return Entities;
            }
            const string MilestonColumn = "Milestone";
            const string submittedByColumn = "CreatedBy";

            if (HttpContext.Current.User.IsInRole("Moderator"))
            {
                string UserName = HttpContext.Current.User.Identity.Name;

                IQueryable<T> query = Entities.Where("(" + MilestonColumn + " == @0 || " +
                    MilestonColumn + " == @1) || (" + MilestonColumn + " == @3)",
                    "Submitted", "Updated", UserName, "Approved").Select(a => a);
                return query.AsQueryable<T>();
            }
            else if (HttpContext.Current.User.IsInRole("RegisteredUser"))
            {
                string UserName = HttpContext.Current.User.Identity.Name;

                IQueryable<T> query = Entities
                    .Where("(" + MilestonColumn + " == @0 || " + submittedByColumn + " == @1)", "Approved", UserName)
                    .Select(a => a);
                return query.AsQueryable<T>();
            }
            else
            {
                IQueryable<T> query = Entities.Where(MilestonColumn + " == @0", "Approved").Select(a => a);
                return query.AsQueryable<T>();
            }
        }

        /// <summary>
        /// Creates a list of the possible work flow operation in the various
        /// stages through which the entity can progress.
        /// The permissible target stage over writes, the current entity stage depending upon the role the user is in.
        /// </summary>
        /// <typeparam name="T">Type of the Entity</typeparam>
        /// <param name="Entities">All the list of Entities, with the current Stage</param>
        /// <returns>The list of Entities with the permissible targets</returns>
        public static IQueryable<T> GetEntityByRole<T>(IQueryable<T> Entities)
        {
            if (HttpContext.Current.User.IsInRole("Administrator"))
            {
                foreach (var P in Entities)
                {
                    ((IAuditable)P).Milestone = "Submitted,Approved,Rejected";
                }

            }
            else if (HttpContext.Current.User.IsInRole("Moderator"))
            {
                foreach (var P in Entities)
                {
                    if (((IAuditable)P).Milestone == "Submitted" || ((IAuditable)P).Milestone == "Updated")
                        ((IAuditable)P).Milestone = "Approved,Rejected";
                    else if (((IAuditable)P).Milestone == "Approved")
                        ((IAuditable)P).Milestone = "Rejected";
                    else if (((IAuditable)P).Milestone == "Rejected")
                        ((IAuditable)P).Milestone = "Approved";
                    else
                        ((IAuditable)P).Milestone = "Submitted";
                }
            }
            else if (HttpContext.Current.User.IsInRole("RegisteredUser"))
            {
                foreach (var P in Entities)
                {
                    ((IAuditable)P).Milestone = "Submitted";
                }
            }
            return Entities;
        }

        public static void OnSuccessfulSubmit(IMailable currentObject, EntityType type)
        {
            string entityType = type.ToString().Replace('_', ' ');
            // Send mail to submitter

            string body = MailUtility.ReadFile(MailUtility.Submitted);
            body = MailUtility.ReplaceTokens(body, currentObject, entityType);

            MailUtility.SendMail(MailUtility.SiteAdminstratorMail, MailUtility.SiteAdminstratorDisplayName, body, currentObject.SubmitterEmail,
                "Footsteps Infotech Inc.: Your " + entityType + " has been submitted for Moderation");

            // Notify Moderators.
            body = MailUtility.ReadFile(MailUtility.SubmittedToModerators);
            body = MailUtility.ReplaceTokens(body, currentObject, entityType);

            MailUtility.SendMail(MailUtility.SiteAdminstratorMail, MailUtility.SiteAdminstratorDisplayName, body, MailUtility.GetUserEmails(),
                "Footsteps Infotech Inc.: A New " + entityType + " has been submitted for Moderation");
        }

        public static void OnSuccessfulApproval(IMailable currentObject, EntityType type)
        {
            string entityType = type.ToString().Replace('_', ' ');

            //Send Thank you mail to Submitter
            string body = MailUtility.ReadFile(MailUtility.Approved);
            body = MailUtility.ReplaceTokens(body, currentObject, entityType);

            MailUtility.SendMail(MailUtility.SiteAdminstratorMail, MailUtility.SiteAdminstratorDisplayName, body, currentObject.SubmitterEmail,
                "Footsteps Infotech Inc.: Your " + entityType + " has been approved.");

            // Send Thank you mail to Moderator
            body = MailUtility.ReadFile(MailUtility.ApprovedToApprover);
            body = MailUtility.ReplaceTokens(body, currentObject, entityType);

            MailUtility.SendMail(MailUtility.SiteAdminstratorMail, MailUtility.SiteAdminstratorDisplayName, body, Membership.GetUser().Email,
                "Footsteps Infotech Inc.: Thank you for Approving " + entityType);
            
            //Send Tweet
            string Error;
            SocialNetworkingHelper.SendTweet("Latest " + entityType + " @ " + Constants.ServerAddress, out Error);
        }

        public static void OnSuccessfulReject(IMailable currentObject, EntityType type)
        {
            string entityType = type.ToString().Replace('_', ' ');

            // Send apology mail to Sumitter
            string body = MailUtility.ReadFile(MailUtility.Rejected);
            body = MailUtility.ReplaceTokens(body, currentObject, entityType);
            MailUtility.SendMail(MailUtility.SiteAdminstratorMail, MailUtility.SiteAdminstratorDisplayName, body, currentObject.SubmitterEmail,
                "Footsteps Infotech Inc.: Sorry your " + entityType + " has been rejected.");

            // Send Thank you mail to Moderator
            body = MailUtility.ReadFile(MailUtility.RejectedToRejector);
            body = MailUtility.ReplaceTokens(body, currentObject, entityType);

            MailUtility.SendMail(MailUtility.SiteAdminstratorMail, MailUtility.SiteAdminstratorDisplayName, body, Membership.GetUser().Email,
                "Footsteps Infotech Inc.: You've Rejected a " + entityType);
        }
    }
}