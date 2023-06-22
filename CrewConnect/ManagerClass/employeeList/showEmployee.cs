using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewConnect.Helper;

namespace CrewConnect.ManagerClass
{
    public partial class showEmployee : Form
    {
        bool[] isValid = new bool[11];
        public showEmployee()
        {
            InitializeComponent();
        }
        static int selectedID;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }
        private void showEmployee_Load(object sender, EventArgs e)
        {
            TopMost = true;
            for (int i = 0; i < isValid.Length; i++)
            {
                isValid[i] = true;
            }
            //
            // sorry makalat na sa part na to minamadali ko na talaga matapos
            //
            SuspendLayout();
            if (!int.TryParse(EmployeeList.selectedID, out selectedID))
                return;

            // Information
            String[] contacts =
            {
            "FULLTIME", "PART-TIME"
            };
            String[] bloods =
            {
            "O-", "O+", "B-", "B+", "A-", "A+", "AB-", "AB+"
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
            "SINGLE", "MARRIED", "WIDOWED", "DIVORCED", "SEPARATED"
            };
            String[] monthVal =
            {
            "JANUARY", "FEBUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST",
            "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"
            };

            cbValue("religion", "religion", religionCB);
            cbValue("system", "position", positionCB);

            contractCB.Items.Clear();
            statusCB.Items.Clear();
            genderCB.Items.Clear();
            bloodTypeCB.Items.Clear();
            userInterfaceHelper.comboBoxValue(contractCB, contacts);
            userInterfaceHelper.comboBoxValue(statusCB, status);
            userInterfaceHelper.comboBoxValue(genderCB, genders);
            userInterfaceHelper.comboBoxValue(bloodTypeCB, bloods);
            userInterfaceHelper.comboBoxValue(genderCB, genders);

            userInterfaceHelper.comboBoxValue(monthCB, monthVal);
            userInterfaceHelper.comboBoxValue(dayCB, 30);
            userInterfaceHelper.comboBoxValue(yearCB, 1960, DateTime.UtcNow.Year);

            yearCB.MaxDropDownItems = 12;
            dayCB.MaxDropDownItems = 12;
            monthCB.MaxDropDownItems = 12;
            bloodTypeCB.MaxDropDownItems = 12;
            positionCB.MaxDropDownItems = 12;
            religionCB.MaxDropDownItems = 12;
            positionCB.MaxDropDownItems = 12;

            string query = "SELECT * " +
                            "FROM bank " +
                            "INNER JOIN contact ON bank.Id = contact.Id " +
                            "INNER JOIN identities ON bank.Id = identities.Id " +
                            "INNER JOIN job ON bank.Id = job.Id " +
                            "INNER JOIN personal ON bank.Id = personal.Id " +
                            $"WHERE bank.Id = '{selectedID}'";
            
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DateTime date;
                        while (reader.Read())
                        {
                            date = (DateTime)reader["birthday"];
                            username1.PlaceholderText = "USERNAME: " + reader["username"].ToString();
                            name1.PlaceholderText = "NAME: " + reader["name"].ToString();
                            statusCB.Text = reader["status"].ToString();
                            religionCB.Text = reader["religion"].ToString();
                            genderCB.Text = reader["gender"].ToString();
                            monthCB.SelectedIndex = Math.Abs(date.Month - 1);
                            dayCB.Text = date.Day.ToString();
                            yearCB.Text = date.Year.ToString();
                            bloodTypeCB.Text = reader["bloodType"].ToString();
                            id1.PlaceholderText = "EMPLOYEE ID: " + reader["Id"].ToString();
                            positionCB.Text = reader["position"].ToString();
                            contractCB.Text = reader["contract"].ToString();
                            salary1.PlaceholderText = "SALARY: " + Convert.ToInt32(reader["salary"]).ToString();
                            phoneNum1.PlaceholderText = "PHONE NUMBER: " + reader["phoneNumber"].ToString();
                            email1.PlaceholderText = "EMAIL: " + reader["emailAddress"].ToString();
                            email2.PlaceholderText = "EMAIL2: " + reader["emailAdress2"].ToString();
                            address1.PlaceholderText = "ADDRESS: " + reader["address"].ToString();
                            address2.PlaceholderText = "ADDRESS2: " + reader["address2"].ToString();
                            bankname1.PlaceholderText = "BANK NAME: " + reader["bankName"].ToString();
                            branch1.PlaceholderText = "BRANCH: " + reader["branch"].ToString();
                            companyAdd1.PlaceholderText = "BANK ADDRESS: " + reader["companyAddress"].ToString();
                            accountName1.PlaceholderText = "ACCOUNT NUM: " + reader["accountName"].ToString();
                            bsb1.PlaceholderText = "BSB: " + reader["BSB"].ToString();

                            byte[] perPic = (byte[])reader["personalPhoto"];
                            byte[] qrPic = (byte[])reader["qrCodePhoto"];


                            using (MemoryStream ms = new MemoryStream(perPic))
                            {
                                selfPic.Image = Image.FromStream(ms);
                            }

                            using (MemoryStream ms = new MemoryStream(qrPic))
                            {
                                qrPic_pic.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
            ResumeLayout();
        }

        void cbValue(string table, string column, Guna2ComboBox cb)
        {
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"SELECT {column} FROM {table}", con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Store the data in a DataTable
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    DataRow positionRow = dataTable.NewRow();
                    positionRow[column] = column;
                    dataTable.Rows.InsertAt(positionRow, 0);

                    DataRow[] rows = dataTable.Select($"{column} = '{column.ToUpper()}'");
                    foreach (DataRow row in rows)
                    {
                        dataTable.Rows.Remove(row);
                    }

                    // Bind the data to the ComboBox
                    cb.DataSource = dataTable;
                    cb.DisplayMember = column.ToUpper();
                    cb.ValueMember = column.ToUpper();
                    reader.Close();
                }
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!validationHelper.internetAvailability())
                return;

            messageDialogForm msg = new messageDialogForm();
            try
            {
                string[] query = { $"DELETE FROM bank WHERE Id = '{selectedID}'",
                $"DELETE FROM contact WHERE Id = '{selectedID}'",
                $"DELETE FROM identities WHERE Id = '{selectedID}'",
                $"DELETE FROM job WHERE Id = '{selectedID}'",
                $"DELETE FROM personal WHERE Id = '{selectedID}'",
                $"DELETE FROM Users WHERE Id = '{selectedID}'"};
                msg.isOkDialog = true;
                msg.title = "ARE YOU SURE?";
                msg.message = "You can't undo what you are about to do";

                if (msg.ShowDialog() != DialogResult.OK)
                    return;

                SuspendLayout();
                SqlConnection con = new SqlConnection(globalVariables.server);
                con.Open();

                foreach (var item in query)
                {
                    using (SqlCommand cmd = new SqlCommand(item, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                msg.title = "AN ERROR HAS OCCURED";
                msg.message = ex.Message;
                msg.ShowDialog();
            }
            ResumeLayout();
            msg.isOkDialog = false;
            msg.title = "DELETE SUCCESS";
            msg.message = $"You successfully deleted ID # {selectedID}";
            msg.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!isValid.Contains(false))
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(globalVariables.server))
                    {
                        con.Open();

                        using (SqlTransaction trans = con.BeginTransaction())
                        {
                            try
                            {
                                using (SqlCommand cmd = con.CreateCommand())
                                {
                                    cmd.Transaction = trans;

                                    //updateData(name1, "personal", "name", cmd);
                                    updateData(statusCB.Text, "personal", "status", cmd);
                                    updateData(religionCB.Text, "personal", "religion", cmd);
                                    updateData(genderCB.Text, "personal", "gender", cmd);

                                    DateTime date = new DateTime(Convert.ToInt32(yearCB.Text), (monthCB.SelectedIndex + 1),
                                        Convert.ToInt32(dayCB.Text));
                                    updateData(date, "personal", "birthday", cmd);
                                    updateData(calculateAge(), "personal", "age", cmd);
                                    updateData(bloodTypeCB.Text, "personal", "bloodType", cmd);

                                    updateData(positionCB.Text, "job", "position", cmd);
                                    updateData(contractCB.Text, "job", "contract", cmd);
                                    updateData(salary1, "job", "salary", cmd);

                                    updateData(phoneNum1, "contact", "phoneNumber", cmd);
                                    updateData(email1, "contact", "emailAddress", cmd);
                                    updateData(email2, "contact", "emailAdress2", cmd);
                                    updateData(address1, "contact", "address", cmd);
                                    updateData(address2, "contact", "address2", cmd);

                                    updateData(bankname1, "bank", "bankName", cmd);
                                    updateData(branch1, "bank", "branch", cmd);
                                    updateData(companyAdd1, "bank", "companyAddress", cmd);
                                    updateData(accountName1, "bank", "accountName", cmd);
                                    updateData(bsb1, "bank", "BSB", cmd);

                                    trans.Commit();

                                    messageDialogForm msg = new messageDialogForm();
                                    msg.isOkDialog = false;
                                    msg.title = "UPDATE SUCCESS";
                                    msg.message = $"You Successfully Update Employee ID # {selectedID}";
                                    if (msg.ShowDialog() == DialogResult.OK)
                                        this.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                messageDialogForm msg = new messageDialogForm();
                                msg.title = "AN ERROR HAS OCCURED";
                                msg.message = ex.Message;
                                msg.ShowDialog();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    messageDialogForm msg = new messageDialogForm();
                    msg.title = "AN ERROR HAS OCCURED";
                    msg.message = ex.Message;
                    msg.ShowDialog();
                }
            }
            else
            {
                validationHelper.textBoxValidation_PhoneNumber_optional(phoneNum1, "Phone Number", errorProvider);
                validationHelper.textBoxValidation_Numeric_optional(salary1, "Salary", errorProvider, 2);
                validationHelper.textBoxValidation_Alpha_optional(address2, "Address", errorProvider);
                validationHelper.textBoxValidation_Alpha_optional(address1, "Address", errorProvider);
                validationHelper.textBoxValidation_Email_option(email2, "Email", errorProvider);
                validationHelper.textBoxValidation_Email_option(email1, "Email", errorProvider);
                validationHelper.textBoxValidation_Alpha_optional(bankname1, "Bank Name", errorProvider);
                validationHelper.textBoxValidation_Alpha_optional(branch1, "Branch", errorProvider);
                validationHelper.textBoxValidation_Numeric_optional(accountName1, "Account Number", errorProvider, 10);
                validationHelper.textBoxValidation_Numeric_optional(bsb1, "BSB", errorProvider, 6);

                messageDialogForm msg = new messageDialogForm()
                {
                    title = "INCORRECT INFORMATION",
                    message = "Please enter a valid data"
                };
                msg.ShowDialog();
            }
        }
        void updateData(Guna2TextBox tb, string table, string column, SqlCommand cmd)
        {
            if (!string.IsNullOrWhiteSpace(tb.Text))
            {
                cmd.CommandText = $"UPDATE {table} SET {column} = @{column} WHERE {table}.Id = '{selectedID}'";
                cmd.Parameters.AddWithValue("@"+column, tb.Text);

                cmd.ExecuteNonQuery();
            }
        }

        void updateData(string data, string table, string column, SqlCommand cmd)
        {
            cmd.CommandText = $"UPDATE {table} SET {column} = @{column} WHERE {table}.Id = '{selectedID}'";
            cmd.Parameters.AddWithValue("@" + column, data);

            cmd.ExecuteNonQuery();
        }

        void updateData(DateTime date, string table, string column, SqlCommand cmd)
        {
            cmd.CommandText = $"UPDATE {table} SET {column} = @{column} WHERE {table}.Id = '{selectedID}'";
            cmd.Parameters.AddWithValue("@" + column, date);

            cmd.ExecuteNonQuery();
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
                    userInterfaceHelper.comboBoxValue(dayCB, 31);
                    break;
                case "febuary":
                    userInterfaceHelper.comboBoxValue(dayCB, 28);
                    break;
                default:
                    userInterfaceHelper.comboBoxValue(dayCB, 30);
                    break;

            }
            dayCB.IntegralHeight = false;
            dayCB.MaxDropDownItems = 12;
            dayCB.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        string calculateAge()
        {
            int day, month, year;
            if (int.TryParse(dayCB.GetItemText(dayCB.SelectedItem), out day) &&
                int.TryParse(yearCB.GetItemText(yearCB.SelectedItem), out year))
            {
                month = monthCB.SelectedIndex + 1;
                return userInterfaceHelper.calculateAge(year, month, day);
            }
            return "0";
        }

        private void salary1_Validating(object sender, CancelEventArgs e)
        {
            isValid[0] = false;
            if (validationHelper.textBoxValidation_Numeric_optional(salary1, "Salary", errorProvider, 2))
                isValid[0] = true;
        }

        private void address2_Validating(object sender, CancelEventArgs e)
        {
            isValid[1] = false;
            if (validationHelper.textBoxValidation_Alpha_optional(address2, "Address", errorProvider))
                isValid[1] = true;
        }

        private void address1_Validating(object sender, CancelEventArgs e)
        {
            isValid[2] = false;
            if (validationHelper.textBoxValidation_Alpha_optional(address1, "Address", errorProvider))
                isValid[2] = true;
        }

        private void phoneNum1_Validating(object sender, CancelEventArgs e)
        {
            isValid[3] = false;
            if (validationHelper.textBoxValidation_PhoneNumber_optional(phoneNum1, "Phone Number", errorProvider))
                isValid[3] = true;
        }

        private void email2_Validating(object sender, CancelEventArgs e)
        {
            isValid[4] = false;
            if (validationHelper.textBoxValidation_Email_option(email2, "Email", errorProvider))
                isValid[4] = true;
        }

        private void email1_Validating(object sender, CancelEventArgs e)
        {
            isValid[5] = false;
            if (validationHelper.textBoxValidation_Email_option(email1, "Email", errorProvider))
                isValid[5] = true;
        }

        private void bankname1_Validating(object sender, CancelEventArgs e)
        {
            isValid[6] = false;
            if (validationHelper.textBoxValidation_Alpha_optional(bankname1, "Bank Name", errorProvider))
                isValid[6] = true;
        }

        private void companyAdd1_Validating(object sender, CancelEventArgs e)
        {
            isValid[7] = false;
            if (validationHelper.textBoxValidation_Address_optional(companyAdd1, "Bank Address", errorProvider))
                isValid[7] = true;
        }

        private void branch1_Validating(object sender, CancelEventArgs e)
        {
            isValid[8] = false;
            if (validationHelper.textBoxValidation_Alpha_optional(branch1, "Branch", errorProvider))
                isValid[8] = true;
        }

        private void accountName1_Validating(object sender, CancelEventArgs e)
        {
            isValid[9] = false;
            if (validationHelper.textBoxValidation_Numeric_optional(accountName1, "Account Number", errorProvider, 10))
                isValid[9] = true;
        }

        private void bsb1_Validating(object sender, CancelEventArgs e)
        {
            isValid[10] = false;
            if (validationHelper.textBoxValidation_Numeric_optional(bsb1, "BSB", errorProvider, 6))
                isValid[10] = true;
        }
    }
}
