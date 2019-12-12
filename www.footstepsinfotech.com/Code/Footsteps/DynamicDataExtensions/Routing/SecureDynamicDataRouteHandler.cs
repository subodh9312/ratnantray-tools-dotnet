using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Security;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;
using DynamicDataExtensions.Attributes.Enums;
using DynamicDataExtensions.Attributes;
using DynamicDataExtensions.Attributes.ExtensionMethods;

namespace DynamicDataExtensions.Routing
{
    /// <summary>
    /// The SecureDynamicDataRouteHandler enables the 
    /// user to access a table based on the following:
    /// the Roles and TableDeny values assigned to 
    /// the SecureTableAttribute.
    /// </summary>
    public class SecureDynamicDataRouteHandler : DynamicDataRouteHandler
    {
        /// <summary>
        /// Creates the handler.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <param name="table">The table.</param>
        /// <param name="action">The action.</param>
        /// <returns>An IHttpHandler</returns>
        public override IHttpHandler CreateHandler(
            DynamicDataRoute route,
            MetaTable table,
            string action)
        {
            var httpContext = HttpContext.Current;
            if (httpContext != null && httpContext.User != null)
            {
                var usersRoles = Roles.GetRolesForUser(httpContext.User.Identity.Name);
                var tablePermissions = table.Attributes.OfType<SecureTableAttribute>();

                // if no permission exist then full access is granted
                if (tablePermissions.Count() == 0)
                    return null;

                foreach (var tp in tablePermissions)
                {
                    if (tp.HasAnyRole(usersRoles))
                    {
                        // if no action is allowed return no route
                        var tpAction = tp.Actions.ToString().Split(new char[] { ',', ' ' }, 
                            StringSplitOptions.RemoveEmptyEntries);

                        if (tp.Actions == CombinedActions.Full || tpAction.Contains(action))
                            return base.CreateHandler(route, table, action);
                    }
                }
            }
            return null;
        }
    }
}

