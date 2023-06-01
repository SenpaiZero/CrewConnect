using Microsoft.Data.SqlClient;
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

namespace WinFormsApp1.ManagerClass
{
    public partial class showEmployee : Form
    {
        public showEmployee()
        {
            InitializeComponent();
        }

        private void showEmployee_Load(object sender, EventArgs e)
        {
            //
            // sorry makalat na sa part na to minamadali ko na talaga matapos
            //
            int selectedID;
            if (!int.TryParse(EmployeeList.selectedID, out selectedID))
                return;

            string query = $"SELECT * FROM bank, contact, identities, job, personal, parttime, fulltime WHERE personal.Id = '" + selectedID + "'";
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            username1.Text = "USERNAME: " + reader["username"].ToString();
                            name1.Text = "NAME: " + reader["name"].ToString();
                            status1.Text = "STATUS: " + reader["status"].ToString();
                            religion1.Text = "RELIGION: " + reader["religion"].ToString();
                            gender1.Text = "GENDER: " + reader["gender"].ToString();
                            bday1.Text = "BDAY: " + reader["birthday"].ToString();
                            age1.Text = "AGE: " + reader["age"].ToString();
                            bloodtype1.Text = "BLOODTYPE: " + reader["bloodType"].ToString();
                            id1.Text = "EMPLOYEE ID: " + reader["Id"].ToString();
                            position1.Text = "POSITION: " + reader["position"].ToString();
                            contract1.Text = "CONTRACT: " + reader["contract"].ToString();
                            salary1.Text = "SALARY: " + reader["salary"].ToString();
                            phoneNum1.Text = "PHONE NUMBER: " + reader["phoneNumber"].ToString();
                            email1.Text = "EMAIL: " + reader["emailAddress"].ToString();
                            email2.Text = "EMAIL2: " + reader["emailAdress2"].ToString();
                            address1.Text = "ADDRESS: " + reader["address"].ToString();
                            address2.Text = "ADDRESS2: " + reader["address2"].ToString();
                            bankname1.Text = "BANK NAME: " + reader["bankName"].ToString();
                            branch1.Text = "BRANCH: " + reader["branch"].ToString();
                            companyAdd1.Text = "COMPANY ADDRESS: " + reader["companyAddress"].ToString();
                            accountName1.Text = "ACCOUNT NAME: " + reader["accountName"].ToString();
                            bsb1.Text = "BSB: " + reader["BSB"].ToString();
                            accountName1.Text = "ACCOUNT NAME: " + reader["accountNum"].ToString();

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
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
