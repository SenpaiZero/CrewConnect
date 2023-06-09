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
using System.Xml;
using WinFormsApp1.Helper;

namespace WinFormsApp1.EmployeeClass
{
    public partial class EmployeePanel : Form
    {
        public EmployeePanel()
        {
            InitializeComponent();
        }

        private void EmployeePanel_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Cursor = Cursors.Hand;
            positionLabel.Text = globalVariables.userPosition;

            pageHelper.changePage(new payslipForm(), mainPanel);
            try
            { 
                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT name FROM personal WHERE username = '{globalVariables.username}'", con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            nameLabel.Text = dr.GetString(0);
                        }
                        else
                        {
                            nameLabel.Text = "ADMIN";
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

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_MouseDown(object sender, MouseEventArgs e)
        {
            var loadingForm = new loadingForm();
            loginForm log = new loginForm();
            loadingForm.StartPosition = FormStartPosition.CenterParent;
            loadingForm.loadingTime = 2500;
            loadingForm.ShowDialog();

            this.Hide();
            log.StartPosition = FormStartPosition.CenterParent;
            log.ShowDialog();
            this.Close();
        }

        private void listBtn_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            pageHelper.changePage(new announcementView(), mainPanel);
        }
    }
}
