using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrewConnect.Helper
{
    public class userInterfaceHelper : Form
    {
        // Clear all persistence data

        public static void removeAllData()
        {
            globalVariables.firstname = null;
            globalVariables.middlename = null;
            globalVariables.lastname = null;
            globalVariables.streetAdd = null;
            globalVariables.streetAdd2 = null;
            globalVariables.city = null;
            globalVariables.postal = null;
            globalVariables.permAdd = false;
            globalVariables.day = null;
            globalVariables.month = null;
            globalVariables.year = null;
            globalVariables.bloodType = null;
            globalVariables.gender = null;
            globalVariables.nationality = null;
            globalVariables.bankName = null;
            globalVariables.companyAdd = null;
            globalVariables.branch = null;
            globalVariables.BSB = null;
            globalVariables.accountName = null;
            globalVariables.email = null;
            globalVariables.email2 = null;
            globalVariables.state = null;
            globalVariables.salary = null;
            globalVariables.contract = null;
        }


        

        // Adding value to combo box (Guna UI) - STRING
        public static void comboBoxValue(Guna2ComboBox cb, String[] values)
        {
            cb.Items.Clear();
            for (int i = 0; i < values.Length; i++)
            {
                cb.Items.Add(values[i].ToUpper());
            }
        }

        // Adding value to combo box (GUNA UI) - INT
        public static void comboBoxValue(Guna2ComboBox cb, int values, String title)
        {
            cb.Items.Clear();
            cb.Items.Add(title);
            for (int i = 0; i < values; i++)
            {
                cb.Items.Add((i+1).ToString());
            }
        }
        public static void comboBoxValue(Guna2ComboBox cb, int values)
        {
            cb.Items.Clear();
            for (int i = 0; i < values; i++)
            {
                cb.Items.Add((i + 1).ToString());
            }
        }
        // Adding value to combo box (GUNA UI) - INT WITH SPECIFIC
        public static void comboBoxValue(Guna2ComboBox cb, int start, int end, String title)
        {
            cb.Items.Clear();
            for (int i = start; i < end; i++)
            {
                cb.Items.Add((i + 1).ToString());
            }
            cb.Items.Add(title);
        }
        public static void comboBoxValue(Guna2ComboBox cb, int start, int end)
        {
            cb.Items.Clear();
            for (int i = start; i < end; i++)
            {
                cb.Items.Add((i + 1).ToString());
            }
        }

        // Calculating date
        public static String calculateAge(int year, int month, int day)
        {
            DateTime today = DateTime.Now;
            DateTime birthdate = new DateTime(year, month, day);

            int age = today.Year - birthdate.Year;

            // Check if the birthdate has already occurred this year
            if (today.Month < birthdate.Month || (today.Month == birthdate.Month && today.Day < birthdate.Day))
            {
                age--;
            }
            return age.ToString();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // userInterfaceHelper
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "userInterfaceHelper";
            this.Load += new System.EventHandler(this.userInterfaceHelper_Load);
            this.ResumeLayout(false);

        }
        // Limitting text count in label display
        public static String limitLabelDisplay(String text, int txtCount)
        {
            String txt;
            if (text.Length > txtCount)
            {
                txt = text.Substring(0, txtCount - 3);
                txt += "...";
                return txt;
            }
            return text;
        }

        private void userInterfaceHelper_Load(object sender, EventArgs e)
        {

        }
    }
}
