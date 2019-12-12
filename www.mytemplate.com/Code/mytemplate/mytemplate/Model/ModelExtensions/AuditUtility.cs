using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Objects;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace mytemplate.Model.ModelExtensions
{
    public interface IAuditable
    {
        int Id { get; set; }
        string CreatedBy { get; set; }
        Nullable<DateTime> CreatedOn { get; set; }
        string LastModeratedBy { get; set; }
        Nullable<DateTime> LastModeratedOn { get; set; }
        string Milestone { get; set; }
    }

    internal static class AuditUtility
    {
        private static string GetUserName()
        {
            string UserName = "";

            if (HttpContext.Current != null)
                UserName = HttpContext.Current.User.Identity.Name;
            else
                UserName = "Anonymous";             //TODO throw an exception here

            return UserName.Equals(string.Empty) ? "Anonymous" : UserName;
        }


        internal static void ProcessInserts(IEnumerable<ObjectStateEntry> list)
        {
            foreach (ObjectStateEntry ObjStateEntry in list)
            {
                IAuditable Item = ObjStateEntry.Entity as IAuditable;

                if (Item != null)
                {
                    // Item.CreatedBy = Item.LastUpdatedBy = GetUserName();
                    // Item.CreatedOn = Item.LastUpdatedOn = DateTime.Now;
                    Item.CreatedBy = GetUserName();
                    Item.CreatedOn = DateTime.Now;
                }

            }
        }

        /*  NOTE: 
         1. Updates are carried out only by Moderators. (and Admins).
         2. Reg users, though appear to be updating they are actually inserting records (Drafts).*/

        internal static void ProcessUpdates(IEnumerable<ObjectStateEntry> list)
        {
            foreach (ObjectStateEntry ObjStateEntry in list)
            {
                IAuditable Item = ObjStateEntry.Entity as IAuditable;

                if (Item != null)
                {
                    //Restore Creator and Updator values, by reading them from DB.
                    Database db = DatabaseFactory.CreateDatabase();

                    //Generate SQL
                    string Sql = "SELECT * FROM " + ObjStateEntry.Entity.ToString().Split('.').Last() + " WHERE";
                    for (int i = 0; i < ObjStateEntry.EntityKey.EntityKeyValues.Count(); i++)
                    {
                        if (i == 0)
                            Sql += " ";
                        else
                            Sql += " AND";

                        if (ObjStateEntry.EntityKey.EntityKeyValues[0].Value is System.Int32)
                        {
                            Sql += ObjStateEntry.EntityKey.EntityKeyValues[0].Key.ToString() + 
                                "=" + ObjStateEntry.EntityKey.EntityKeyValues[0].Value.ToString();
                        }
                        else
                        {
                            Sql += ObjStateEntry.EntityKey.EntityKeyValues[0].Key.ToString() + 
                                "='" + ObjStateEntry.EntityKey.EntityKeyValues[0].Value.ToString() + "'";
                        }
                    }

                    DbCommand dbc = db.GetSqlStringCommand(Sql);

                    using (var dr = db.ExecuteReader(dbc))
                    {
                        while (dr.Read())
                        {
                            //Restore Original Creator
                            Item.CreatedBy = dr["CreatedBy"].ToString();
                            Item.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

                            //Restore Original Updator
                            // Item.LastUpdatedBy = dr["LastUpdatedBy"].ToString();
                            // Item.LastUpdatedOn = Convert.ToDateTime(dr["LastUpdatedOn"]);
                        }
                    }

                    Item.LastModeratedBy = GetUserName();
                    Item.LastModeratedOn = DateTime.Now;
                }
            }
        }
    }
}