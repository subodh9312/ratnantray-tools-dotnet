using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBManager.Utils
{
    public static class DBConstants
    {
        public const string LOG_FILE_PATH = "DBManager.LOG_FILE_PATH";

        public const string CONNECTION_STRING_TEMPLATE = @"Data Source=<ServerName>;" +
            "Initial Catalog=<DatabaseName>;Integrated Security=False;User Id=<UserId>;Password=<Password>";
    }
}
