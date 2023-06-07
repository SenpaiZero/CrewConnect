using Guna.UI2.WinForms;
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
            //
            // sorry makalat na sa part na to minamadali ko na talaga matapos
            //
            SuspendLayout();
            if (!int.TryParse(EmployeeList.selectedID, out selectedID))
                return;

            string query =  "SELECT * " +
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
                        while(reader.Read())
                        {
                            username1.PlaceholderText = "USERNAME: " + reader["username"].ToString();
                            name1.PlaceholderText = "NAME: " + reader["name"].ToString();
                            status1.PlaceholderText = "STATUS: " + reader["status"].ToString();
                            religion1.PlaceholderText = "RELIGION: " + reader["religion"].ToString();
                            gender1.PlaceholderText = "GENDER: " + reader["gender"].ToString();
                            bday1.PlaceholderText = "BDAY: " + reader["birthday"].ToString();
                            age1.PlaceholderText = "AGE: " + reader["age"].ToString();
                            bloodtype1.PlaceholderText = "BLOODTYPE: " + reader["bloodType"].ToString();
                            id1.PlaceholderText = "EMPLOYEE ID: " + reader["Id"].ToString();
                            position1.PlaceholderText = "POSITION: " + reader["position"].ToString();
                            contract1.PlaceholderText = "CONTRACT: " + reader["contract"].ToString();
                            salary1.PlaceholderText = "SALARY: " + reader["salary"].ToString();
                            phoneNum1.PlaceholderText = "PHONE NUMBER: " + reader["phoneNumber"].ToString();
                            email1.PlaceholderText = "EMAIL: " + reader["emailAddress"].ToString();
                            email2.PlaceholderText = "EMAIL2: " + reader["emailAdress2"].ToString();
                            address1.PlaceholderText = "ADDRESS: " + reader["address"].ToString();
                            address2.PlaceholderText = "ADDRESS2: " + reader["address2"].ToString();
                            bankname1.PlaceholderText = "BANK NAME: " + reader["bankName"].ToString();
                            branch1.PlaceholderText = "BRANCH: " + reader["branch"].ToString();
                            companyAdd1.PlaceholderText = "COMPANY ADDRESS: " + reader["companyAddress"].ToString();
                            accountName1.PlaceholderText = "ACCOUNT NAME: " + reader["accountName"].ToString();
                            bsb1.PlaceholderText = "BSB: " + reader["BSB"].ToString();
                            accountName1.PlaceholderText = "ACCOUNT NAME: " + reader["accountNum"].ToString();

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
            msg.title = "";
            msg.message = $"You successfully deleted ID # {selectedID}";
            if (msg.ShowDialog() == DialogResult.OK)
                this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

                                // pag di blanko = isali sa query
                                updateData(name1, "personal", "name", cmd);
                                updateData(status1, "personal", "status", cmd);
                                updateData(religion1, "personal", "religion", cmd);
                                updateData(gender1, "personal", "gender", cmd);
                                updateData(bday1, "personal", "birthday", cmd);
                                updateData(age1, "personal", "age", cmd);
                                updateData(bloodtype1, "personal", "bloodType", cmd);

                                updateData(position1, "job", "position", cmd);
                                updateData(contract1, "job", "contract", cmd);
                                updateData(salary1, "job", "salary", cmd);

                                updateData(phoneNum1, "contact", "phoneNumber", cmd);
                                updateData(email1, "contact", "emailAddress", cmd);
                                updateData(email2, "contact", "emailAdress2", cmd);
                                updateData(address1, "contact", "address", cmd);
                                updateData(address2, "contact", "address2", cmd);

                                updateData(bankname1, "bank", "bankName", cmd);
                                updateData(branch1, "branch", "branch", cmd);
                                updateData(companyAdd1, "bank", "companyAddress", cmd);
                                updateData(accountName1, "bank", "accountName", cmd);
                                updateData(bsb1, "bank", "BSB", cmd);

                                trans.Commit();

                                messageDialogForm msg = new messageDialogForm();
                                msg.isOkDialog = false;
                                msg.title = "";
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
        void updateData(Guna2TextBox tb, string table, string column, SqlCommand cmd)
        {
            if (!string.IsNullOrWhiteSpace(tb.Text))
            {
                cmd.CommandText = $"UPDATE {table} SET {column} = @{column} WHERE {table}.Id = '{selectedID}'";
                cmd.Parameters.AddWithValue("@"+column, tb.Text);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
