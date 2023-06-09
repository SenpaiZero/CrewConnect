using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Helper;
using ZXing;

namespace WinFormsApp1.ManagerClass
{
    public partial class adminSetting : Form
    {
        public adminSetting()
        {
            InitializeComponent();
        }

        private void adminSetting_Load(object sender, EventArgs e)
        {
            showData();
            contrrolCB.SelectedIndex = 0;
        }

        void showData()
        {
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                showComboBox(con, positionCB, "system", "position");
                showComboBox(con, religionCB, "religion", "religion");
            }
        }
        void showComboBox(SqlConnection con, Guna2ComboBox cb, string table, string column)
        {
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

                // Bind the data to the ComboBox
                cb.DataSource = dataTable;
                cb.DisplayMember = column;
                cb.ValueMember = column;
                reader.Close();
            }
        }

        void removeData(string table, string column, Guna2ComboBox cb) 
        {
            string query = $"DELETE FROM {table} WHERE {column} = @SelectedText";
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SelectedText", cb.Text);

                    messageDialogForm msg = new messageDialogForm();
                    msg.message = "You've Successfully Removed " + cb.Text;
                    msg.ShowDialog();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void addReligionBtn_Click(object sender, EventArgs e)
        {
            loading();
            if (validationHelper.textBoxValidation_Alpha(religionTB, "religion", errorProvider1))
            {
                string query = "";

                query += $"DELETE FROM religion WHERE religion = 'Other indigenous beliefs'";
                query += $"INSERT INTO religion (religion) VALUES ('{religionTB.Text}');";
                query += $"INSERT INTO religion (religion) VALUES ('Other indigenous beliefs');";

                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.ExecuteNonQuery();
                        messageDialogForm msg = new messageDialogForm();
                        msg.message = "You've Successfully Addedd " + religionTB.Text;
                        msg.ShowDialog();
                        religionTB.Text = "";
                        showData();
                    }
                }
            }
        }

        private void addPositionBtn_Click(object sender, EventArgs e)
        {
            loading();
            if (validationHelper.textBoxValidation_Alpha(positionTB, "position", errorProvider1))
            {
                string query = "";

                query += $"INSERT INTO system (position, control) VALUES (@position, @control);";

                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@position", positionTB.Text.ToUpper());
                        cmd.Parameters.AddWithValue("@control", contrrolCB.Text);
                        cmd.ExecuteNonQuery();

                        messageDialogForm msg = new messageDialogForm();
                        msg.message = "You've Successfully Addedd " + positionTB.Text;
                        msg.ShowDialog();
                        positionTB.Text = "";

                        showData();
                    }
                }
            }
        }

        private void removePositionBtn_Click(object sender, EventArgs e)
        {
            loading();
            removeData("system", "position", positionCB);
            showData();
        }

        private void removeReligionBtn_Click(object sender, EventArgs e)
        {
            loading();
            if (religionCB.Text == "Other indigenous beliefs")
                return;

            removeData("religion", "religion", religionCB);
            showData();
        }

        void loading()
        {
            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.CenterParent;
            loadingForm.loadingTime = 2500;
            loadingForm.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            loading();
            string query = "SELECT password FROM Users WHERE password COLLATE Latin1_General_CS_AS = @password";
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@password", oldPass.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string storedPassword = dr["password"].ToString();

                        if (storedPassword == oldPass.Text && newPass.Text == newPass2.Text)
                        {
                            dr.Close(); 

                            string updatePass = "UPDATE Users SET password = @newPass WHERE username = @username";
                            SqlCommand cmd2 = new SqlCommand(updatePass, con);
                            cmd2.Parameters.AddWithValue("@newPass", securityHelper.HashPassword(newPass.Text));
                            cmd2.Parameters.AddWithValue("@username", globalVariables.username);
                            cmd2.ExecuteNonQuery();

                            messageDialogForm msg = new messageDialogForm();
                            msg.message = "You've Successfully Changed Your Password";
                            msg.ShowDialog();

                            oldPass.Text = "";
                            newPass.Text = "";
                            newPass2.Text = "";
                        }
                    }

                    dr.Close();
                }
            }
        }

        private void positionTB_Validating(object sender, CancelEventArgs e)
        {
            validationHelper.textBoxValidation_Alpha(positionTB, "position", errorProvider1);
        }

        private void religionTB_Validating(object sender, CancelEventArgs e)
        {
            validationHelper.textBoxValidation_Alpha(religionTB, "religion", errorProvider1);
        }
    }
}
