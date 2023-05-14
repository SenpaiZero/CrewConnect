using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Helper
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


        public static string server = "Server=tcp:crewconnect.database.windows.net,1433;Initial Catalog=CrewConnectDB;" +
            "Persist Security Info=False;User ID=crewconnect;Password=123sti_bsit;MultipleActiveResultSets=False;" +
            "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        // Persistence Data for adding employee
        // Page 1
        public static string? firstname { get; set; }
        public static string? lastname { get; set; }
        public static string? middlename { get; set; }
        public static string? streetAdd { get; set; }
        public static string? streetAdd2 { get; set; }
        public static string? city { get; set; }
        public static string? state { get; set; }
        public static string? postal { get; set; }
        public static Boolean? permAdd { get; set; }

        // Page 2
        public static int? day { get; set; }
        public static int? month { get; set; }
        public static int? year { get; set; }
        public static String? bloodType { get; set; }
        public static String? gender { get; set; }
        public static String? nationality { get; set; }
        public static int? age { get; set; }

        // Page 3
        public static string? qrPath { get; set; }
        public static string? picPath { get; set; }
        public static string? position { get; set; }
        public static string? phoneNumber { get; set; }
        public static string? email { get; set; }
        public static string? email2 { get; set; }

        // Page 4
        public static string? bankName { get; set; }
        public static string? companyAdd { get; set; }
        public static string? companyName { get; set; }
        public static string? accountName { get; set; }
        public static string? branch { get; set; }
        public static string? BSB { get; set; }
        public static string? accountNum { get; set; }
        public static int? accountType { get; set; }
        public static string? salary { get; set; }

        //
        // Persistence data for login
        //
        public static string? username { get; set; }
        public static string? userPosition { get; set; }


    }
}
