using System;
using System.Web.Security;

namespace UserManagement.Utils
{
    public static class UserUtility
    {
        public static readonly string ADMINISTRATOR_USERNAME = "Administrator";

        public static readonly string DEFAULT_ADMINISTRATOR_PASSWORD = "P@ssword";

        public static string GetAuthenticatedUserName()
        {
            string userName = AppDomain.CurrentDomain.GetData("AuthenticatedUserName") as string;
            return userName == null ? "" : userName;
        }

        public static void SetAuthenticatedUserName(string userName)
        {
            AppDomain.CurrentDomain.SetData("AuthenticatedUserName", userName);
        }

        public static MembershipUser GetLoggedInUser()
        {
            return Membership.GetUser(GetAuthenticatedUserName());
        }
    }
}
