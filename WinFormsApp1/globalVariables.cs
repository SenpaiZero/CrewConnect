using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class globalVariables
    {
        static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        globalVariables()
        {
            builder.DataSource = "crewconnect.database.windows.net";
            builder.UserID = "crewconnect";
            builder.Password = "123sti_bsit";
            builder.InitialCatalog = "CrewConnectDB";
        }


        public static String server = "Server=tcp:crewconnect.database.windows.net,1433;Initial Catalog=CrewConnectDB;" +
            "Persist Security Info=False;User ID=crewconnect;Password=123sti_bsit;MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static String? position { get; set; }
        public static String? username { get; set; }
        public static String? id { get; set; }

    }
}
