using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewConnect.Helper
{
    public class userInterfaceHelper : Form
    {
        // Clear all persistence data (global variables)
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
            month -= 1; 
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

        // Method for closing all instantiated shortcut popup
        public static void closeShortcut()
        {
            string formNameToClose = "shortcutForm"; 

            var formsToClose = Application.OpenForms
                .OfType<Form>()
                .Where(f => f.Name == formNameToClose)
                .ToList();

            foreach (var formToClose in formsToClose)
            {
                formToClose.Close();
            }
        }
        private void userInterfaceHelper_Load(object sender, EventArgs e)
        {

        }
        // Method for capturing application into image
        public static Bitmap CapturePanelImage(Form form)
        {
            Bitmap image = new Bitmap(form.Width, form.Height);

            using (Graphics graphics = Graphics.FromImage(image))
            {
                form.DrawToBitmap(image, new Rectangle(0, 0, form.Width, form.Height));
            }

            return image;
        }

        // Method for showing osk (on-screen keyboard)
        public static void openScreenKeyboard()
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "osk.exe",
                    UseShellExecute = true,
                    Verb = "runas"
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                messageDialogForm msg = new messageDialogForm()
                {
                    title = "THE ON-SCREEN KEYBOARD COULD NOT BE OPENED",
                    message = ex.Message,
                    StartPosition = FormStartPosition.CenterParent
                };
                msg.ShowDialog();
            }
        }

    }
}
