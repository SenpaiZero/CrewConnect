using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewConnect.Helper;

namespace CrewConnect.ManagerClass.addEmployee.pages
{
    public partial class page2 : Form
    {
        public static page2 p2;
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
            pageHelper.loading(mainsPanel);
            if ((yearCB.Text != "YEAR" && monthCB.Text != "MONTH" &&
                dayCB.Text != "DAY" && bloodTypeCB.Text != "BLOOD TYPE" &&
                genderCB.Text != "GENDER" && nationalityCB.Text != "NATIONALITY" &&
                statusCB.Text != "STATUS" && religionCB.Text != "RELIGION") )
            {
                globalVariables.year = Convert.ToInt32(yearCB.Text);
                globalVariables.day = Convert.ToInt32(dayCB.Text);
                globalVariables.month = monthCB.SelectedIndex;

                globalVariables.bloodType = bloodTypeCB.Text;
                globalVariables.gender = genderCB.Text;
                globalVariables.nationality = nationalityCB.Text;
                globalVariables.status = statusCB.Text;
                globalVariables.religion = religionCB.Text;
                globalVariables.age = Convert.ToInt32(ageTB.Text);

                pageHelper.f.Close();

                if (globalVariables.isEdit)
                {
                    pageHelper.changePage(new page4(), adminPanel.panel);
                    previewInfo1 prev = new previewInfo1();
                    if (prev.ShowDialog() == DialogResult.OK)
                    {
                        pageHelper.changePage(new page1(), adminPanel.panel);
                    }
                    return;
                }
                pageHelper.changePage(new page3(), adminPanel.panel);

            }
            else
            {
                validationHelper.comboBoxValidation(monthCB, "MONTH", errorProvider1);
                validationHelper.comboBoxValidation(dayCB, "DAY", errorProvider1);
                validationHelper.comboBoxValidation(yearCB, "YEAR", errorProvider1);
                validationHelper.comboBoxValidation(bloodTypeCB, "BLOOD TYPE", errorProvider1);
                validationHelper.comboBoxValidation(genderCB, "GENDER", errorProvider1);
                validationHelper.comboBoxValidation(nationalityCB, "NATIONALITY", errorProvider1);
                validationHelper.comboBoxValidation(statusCB, "STATUS", errorProvider1);
                validationHelper.comboBoxValidation(religionCB, "RELIGION", errorProvider1);

                pageHelper.errorDetails();
            }

        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (globalVariables.isEdit)
            {
                pageHelper.changePage(new page4(), adminPanel.panel);
                previewInfo1 prev = new previewInfo1();
                if (prev.ShowDialog() == DialogResult.OK)
                {
                    pageHelper.changePage(new page1(), adminPanel.panel);
                }
                return;
            }
            pageHelper.loading(mainsPanel);
            pageHelper.f.Close();
            pageHelper.changePage(new page1(), adminPanel.panel);
        }

        private void mainsPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void page2_Load(object sender, EventArgs e)
        {
            p2 = this;
            validationHelper.comboBoxFirstLoad = true;
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
                "GENDER", "MALE", "FEMALE", "OTHERS"
            };

            String[] nationalities = 
            { 
                "NATIONALITY", "Filipino", "American", "Canadian", "British", "Australian", "Chinese", 
                "Japanese", "Korean", "Russian", "French", "German", "Italian", "Spanish", 
                "Mexican", "Brazilian" 
            };

            String[] status =
            {
                "STATUS", "SINGLE", "MARRIED", "WIDOWED", "DIVORCED", "SEPARATED"
            };

            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"SELECT religion FROM religion", con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Store the data in a DataTable
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    DataRow positionRow = dataTable.NewRow();
                    positionRow["religion"] = "religion";
                    dataTable.Rows.InsertAt(positionRow, 0);

                    // Bind the data to the ComboBox
                    religionCB.DataSource = dataTable;
                    religionCB.DisplayMember = "religion".ToUpper();
                    religionCB.ValueMember = "religion".ToUpper();
                    reader.Close();
                }
            }
            userInterfaceHelper.comboBoxValue(genderCB, genders);
            genderCB.SelectedIndex = 0;

            userInterfaceHelper.comboBoxValue(nationalityCB, nationalities);
            nationalityCB.SelectedIndex = 0;

            userInterfaceHelper.comboBoxValue(bloodTypeCB, bloods);
            bloodTypeCB.SelectedIndex = 0;

            userInterfaceHelper.comboBoxValue(statusCB, status);
            statusCB.SelectedIndex = 0;

            if(globalVariables.isEdit)
            {
                genderCB.SelectedIndex = genderCB.Items.IndexOf(globalVariables.gender);
                nationalityCB.SelectedIndex = nationalityCB.Items.IndexOf(globalVariables.nationality);
                bloodTypeCB.SelectedIndex = bloodTypeCB.Items.IndexOf(globalVariables.bloodType);
                statusCB.SelectedIndex = statusCB.Items.IndexOf(globalVariables.status);
                religionCB.SelectedIndex = religionCB.Items.IndexOf(globalVariables.religion);

                monthCB.SelectedIndex = (int)globalVariables.month;
                dayCB.SelectedIndex = (int)globalVariables.day;
                yearCB.SelectedIndex = yearCB.Items.IndexOf(globalVariables.year.ToString());
            }

            errorProvider1.Clear();
            validationHelper.comboBoxFirstLoad = false;
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

        private void monthCB_SelectedValueChanged(object sender, EventArgs e)
        {
            validationHelper.comboBoxValidation(monthCB, "MONTH", errorProvider1);
        }

        private void dayCB_SelectedValueChanged(object sender, EventArgs e)
        {
            validationHelper.comboBoxValidation(dayCB, "DAY", errorProvider1);
        }

        private void yearCB_SelectedValueChanged(object sender, EventArgs e)
        {
            validationHelper.comboBoxValidation(yearCB, "YEAR", errorProvider1);
        }

        private void bloodTypeCB_SelectedValueChanged(object sender, EventArgs e)
        {
            validationHelper.comboBoxValidation(bloodTypeCB, "BLOOD TYPE", errorProvider1);
        }

        private void genderCB_SelectedValueChanged(object sender, EventArgs e)
        {
            validationHelper.comboBoxValidation(genderCB, "GENDER", errorProvider1);
        }

        private void nationalityCB_SelectedValueChanged(object sender, EventArgs e)
        {
            validationHelper.comboBoxValidation(nationalityCB, "NATIONALITY", errorProvider1);
        }

        private void statusCB_SelectedValueChanged(object sender, EventArgs e)
        {
            validationHelper.comboBoxValidation(statusCB, "STATUS", errorProvider1);
        }

        private void religionCB_SelectedValueChanged(object sender, EventArgs e)
        {
            validationHelper.comboBoxValidation(religionCB, "RELIGION", errorProvider1);
        }

        private void mainsPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void page2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                nextBtn.PerformClick();
            }
            else if(e.KeyCode == Keys.Escape) 
            {
                prevBtn.PerformClick();
            }
        }
    }
}
