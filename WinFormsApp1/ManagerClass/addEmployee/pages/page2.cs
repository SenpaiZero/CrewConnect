using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Helper;

namespace WinFormsApp1.ManagerClass.addEmployee.pages
{
    public partial class page2 : Form
    {
        public page2()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            pageHelper.changePage(new page3(), managerAddEmployee.panel);
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            pageHelper.changePage(new page1(), managerAddEmployee.panel);
        }

        private void mainsPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void page2_Load(object sender, EventArgs e)
        {
            // Birth Day
            String[] monthVal = 
            {
                "MONTH" ,"JANUARY", "FEBUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST",
                "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"
            };

            userInterfaceHelper.comboBoxValue(monthCB, monthVal);
            userInterfaceHelper.comboBoxValue(dayCB, 30, "DAY");
            userInterfaceHelper.comboBoxValue(yearCB, 1960, DateTime.UtcNow.Year, "YEAR");
            monthCB.SelectedIndex = 0;
            dayCB.SelectedIndex = 0;
            yearCB.SelectedIndex = yearCB.Items.Count - 1;

            yearCB.IntegralHeight = false;
            yearCB.MaxDropDownItems = 12;
            yearCB.DropDownStyle = ComboBoxStyle.DropDownList;

            // Information
            String[] bloods =
            {
                "BLOOD TYPE", "O-", "O+", "B-", "B+", "A-", "A+", "AB-", "AB+"
            };

            String[] genders =
            {
                "MALE", "FEMALE", "OTHERS"
            };

            String[] nationalities = 
            { 
                "Filipino", "American", "Canadian", "British", "Australian", "Chinese", 
                "Japanese", "Korean", "Russian", "French", "German", "Italian", "Spanish", 
                "Mexican", "Brazilian" 
            };

            String[] status =
            {
                "STATUS", "SINGLE", "MARRIED", "WIDOWED", "DIVORCED", "SEPARATED"
            };

            String[] religionsInPh = 
            {
                "RELIGION", "Roman Catholicism", "Islam", "Iglesia ni Cristo",
                "Protestantism",  "Buddhism", "Hinduism", "Judaism", "Bahá'í Faith",
                "Aglipayanism", "Anitism", "Other indigenous beliefs"
            };
            userInterfaceHelper.comboBoxValue(genderCB, genders);
            genderCB.SelectedIndex = 0;

            userInterfaceHelper.comboBoxValue(nationalityCB, nationalities);
            nationalityCB.SelectedIndex = 0;

            userInterfaceHelper.comboBoxValue(bloodTypeCB, bloods);
            bloodTypeCB.SelectedIndex = 0;

            userInterfaceHelper.comboBoxValue(statusCB, status);
            statusCB.SelectedIndex = 0;

            userInterfaceHelper.comboBoxValue(religionCB, religionsInPh);
            religionCB.SelectedIndex = 0;
        }

        private void monthCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            String month = monthCB.GetItemText(monthCB.SelectedItem);
            switch (month.ToLower())
            {
                case "january":
                case "march":
                case "may":
                case "july":
                case "august":
                case "october":
                case "december":
                    userInterfaceHelper.comboBoxValue(dayCB, 31, "DAY");
                    break;
                case "febuary":
                    userInterfaceHelper.comboBoxValue(dayCB, 28, "DAY");
                    break;
                default:
                    userInterfaceHelper.comboBoxValue(dayCB, 30, "DAY");
                    break;

            }
            dayCB.IntegralHeight = false;
            dayCB.MaxDropDownItems = 12;
            dayCB.DropDownStyle = ComboBoxStyle.DropDownList;

            calculateAge();
        }

        public void calculateAge()
        {
            int day, month, year;
            if (dayCB.SelectedItem != null && monthCB.SelectedItem != null && yearCB.SelectedItem != null)
            {
                if (int.TryParse(dayCB.GetItemText(dayCB.SelectedItem), out day) &&
                    int.TryParse(yearCB.GetItemText(yearCB.SelectedItem), out year))
                {
                    month = monthCB.SelectedIndex + 1;
                    ageTB.Text = userInterfaceHelper.calculateAge(year, month, day);
                }
            }

        }

        private void dayCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateAge();
        }

        private void yearCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateAge();
        }
    }
}
