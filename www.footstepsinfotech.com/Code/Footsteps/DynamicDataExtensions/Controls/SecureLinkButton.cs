﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.DynamicData;
using System.Web.Security;
using System.Configuration;
using DynamicDataExtensions.Attributes.ExtensionMethods;
using DynamicDataExtensions.Linq.LinqHelper;
using DynamicDataExtensions.Attributes;
using DynamicDataExtensions.Attributes.Enums;

namespace DynamicDataExtensions.Controls
{
    /// <summary>
    /// Secures the link button when used for delete actions
    /// </summary>
    public class SecureLinkButton : LinkButton
    {
        private const String DISABLED_NAMES = "SecureLinkButtonDeleteCommandNames";
        private String[] delete = new String[] { "delete" };

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs"/> 
        /// object that contains the event data.
        /// </param>
        protected override void OnInit(EventArgs e)
        {
            /*if (ConfigurationManager.AppSettings.AllKeys.Contains(DISABLED_NAMES))
                delete = ConfigurationManager.AppSettings[DISABLED_NAMES]
                    .ToLower()
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);*/

            base.OnInit(e);
        }

        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="T:System.Web.UI.HtmlTextWriter"/> 
        /// object that receives the control content.
        /// </param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!IsDisabled())
                base.Render(writer);
            else
                writer.Write(String.Format("<a>{0}</a>", Text));
        }

        /// <summary>
        /// Determines whether this instance is disabled.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance is 
        /// 	disabled; otherwise, <c>false</c>.
        /// </returns>
        private Boolean IsDisabled()
        {
            if (!delete.Contains(CommandName.ToLower()))
                return false;

            // get restrictions for the current
            // users access to this table
            var table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
            var usersRoles = Roles.GetRolesForUser();
            var tableRestrictions = table.Attributes.OfType<SecureTableAttribute>();

            // restrictive permissions
            if (tableRestrictions.Count() == 0)
                return true;

            foreach (var tp in tableRestrictions)
            {
                // the LinkButton is considered disabled if delete is denied.
                var action = CommandName.ToEnum<TableActions>();
                if (tp.HasAnyRole(usersRoles) && (tp.Actions & action) == action)
                    return false;
            }
            return true;
        }
    }
}
