
namespace DynamicDataExtensions.CustomMembership
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration.Provider;
    using System.Web.Security;

    public class UserNameAsEmailSqlMembershipProvider : SqlMembershipProvider
    {
        /// <summary>
        /// Supress the email parameter and pass the value of username as the Email address supplied
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        /// <param name="isApproved"></param>
        /// <param name="providerUserKey"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public override MembershipUser CreateUser(string username,
                                                   string password,
                                                   string email,
                                                   string passwordQuestion,
                                                   string passwordAnswer,
                                                   bool isApproved,
                                                   object providerUserKey,
                                                   out    MembershipCreateStatus status)
        {
            return base.CreateUser(username, password, username, passwordQuestion, passwordAnswer, isApproved, providerUserKey, out status);
        }

        /// <summary>
        /// RequiresUniqueEmail should always return true for Email address to be used as UserName
        /// </summary>
        public override bool RequiresUniqueEmail
        {
            get
            {
                return true;
            }
        }
    }
}
