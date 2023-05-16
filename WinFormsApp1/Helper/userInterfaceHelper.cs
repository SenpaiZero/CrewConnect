using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinFormsApp1.Helper
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
            globalVariables.accountType = null;
        }


        // Limitting text count in label display
        public static String limitLabelDisplay(String text, int txtCount)
        {
            String txt;
            if(text.Length > txtCount)
            {
                txt = text.Substring(0, txtCount-3);
                txt += "...";
                return txt;
            }
            return text;
        }

        // Checking if user entered a value in required field
        public static bool checkFieldBlank(String tb)
        {
            if(string.IsNullOrEmpty(tb))
            {
                return true;
            }
            return false;
        }

        // Check if user entered alphabets only
        public static bool checkFieldAlpha(String tb)
        {
            if(Regex.IsMatch(tb, "^[a-zA-Z]+$"))
            {
                return true;
            }
            return false;
        }

        // Checks if user entered alphabets and numbers only
        public static bool checkFieldAlphaNumeric(String tb)
        {
            if (Regex.IsMatch(tb, "^[a-zA-Z0-9]+$"))
            {
                return true;
            }
            return false;
        }

        // Check if user entered numbers only
        public static bool checkFieldNumeric(String tb)
        {
            if(Regex.IsMatch(tb, "^[0-9]+$"))
            {
                return true;
            }
            return false;
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

        // Calculating date
        public static String calculateAge(int year, int month, int day)
        {
            DateTime date = DateTime.Now;
            int year_ = date.Year;
            int month_ = date.Month;
            int day_ = date.Day;

            MessageBox.Show((year_ - year).ToString() + "  asdas  " + year + "  year_:" + year_);
            if(month < month_)
            {
                globalVariables.age = (year_ - year);
                return (year_ - year).ToString();
            }
            else if (month > month_)
            {
                globalVariables.age = ((year_ - year) + 1);
                return ((year_ - year) + 1).ToString();
            }
            else if(month == month_)
            {
                if(day >= day_)
                {
                    globalVariables.age = ((year_ - year) + 1);
                    return ((year_ - year) + 1).ToString();
                }
            }

            globalVariables.age = (year_ - year);
            return (year_ - year).ToString();
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

        private void userInterfaceHelper_Load(object sender, EventArgs e)
        {

        }
    }
}
