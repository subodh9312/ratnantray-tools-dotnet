using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using DBManager.Utils;


namespace DBManager
{
    [RunInstaller(false)]
    public partial class ConnectionStringInstaller : Installer
    {
        public ConnectionStringInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            string assmeblyPath = Context.Parameters["assemblypath"];

            DBUtils.WriteApplicationSettings(assmeblyPath, "ConnectionString.DataSource", 
                Context.Parameters["DataSource"]);
            DBUtils.WriteApplicationSettings(assmeblyPath, "ConnectionString.InitialCatalog", 
                Context.Parameters["InitialCatalog"]);

            DBUtils.WriteApplicationSettings(assmeblyPath, "ConnectionString.UserId", Context.Parameters["UserId"]);

            if (!String.IsNullOrEmpty(Context.Parameters["Password"]))
            {
                DBUtils.WriteApplicationSettings(assmeblyPath, "ConnectionString.Password",
                    StringCipher.Encrypt(Context.Parameters["Password"]));
            }

            string connectionString = DBUtils.GetConnectionString(Context.Parameters["DataSource"], 
                Context.Parameters["InitialCatalog"], Context.Parameters["UserId"], 
                Context.Parameters["Password"]);
        }
    }
}
