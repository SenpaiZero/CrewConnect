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

namespace CrewConnect.EmployeeClass
{
    public partial class employeeSetting : Form
    {
        public employeeSetting()
        {
            InitializeComponent();
        }
        void loading()
        {
            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = panel.Parent.PointToScreen(panel.Location);
            int loadingFormX = listTableLocationOnForm.X + (panel.Width - loadingForm.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (panel.Height - loadingForm.Height) / 2;
            loadingForm.Location = new Point(loadingFormX, loadingFormY);

            loadingForm.loadingTime = 1000;
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
                    cmd.Parameters.AddWithValue("@password", securityHelper.HashPassword(oldPass.Text));
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string storedPassword = dr["password"].ToString();

                        if (newPass.Text == newPass2.Text)
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
                        else
                        {
                            messageDialogForm msg = new messageDialogForm();
                            msg.title = "NEW PASSWORD MUST BE THE SAME";
                            msg.message = "PLEASE DOUBLE CHECK THE CAPITALIZATIONS";
                            msg.ShowDialog();
                        }
                    }
                    else
                    {
                        messageDialogForm msg = new messageDialogForm();
                        msg.title = "INCORECT CURRENT PASSWORD";
                        msg.message = "PLEASE DOUBLE CHECK THE CAPITALIZATIONS";
                        msg.ShowDialog();
                    }

                    dr.Close();
                }
            }
        }

        private void oldPass_IconRightClick(object sender, EventArgs e)
        {
            if (oldPass.PasswordChar.ToString() == "●")
            {
                oldPass.PasswordChar = '\0';
            }
            else
            {
                oldPass.PasswordChar = '●';
            }
        }

        private void newPass_IconRightClick(object sender, EventArgs e)
        {
            if (newPass.PasswordChar.ToString() == "●")
            {
                newPass.PasswordChar = '\0';
            }
            else
            {
                newPass.PasswordChar = '●';
            }
        }

        private void newPass2_IconRightClick(object sender, EventArgs e)
        {
            if (newPass2.PasswordChar.ToString() == "●")
            {
                newPass2.PasswordChar = '\0';
            }
            else
            {
                newPass2.PasswordChar = '●';
            }
        }
    }
}
