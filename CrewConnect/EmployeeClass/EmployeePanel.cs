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
using CrewConnect.Helper;
using CrewConnect.ManagerClass.addEmployee.pages;

namespace CrewConnect.EmployeeClass
{
    public partial class EmployeePanel : Form
    {
        string whatBtn = "";
        public EmployeePanel()
        {
            InitializeComponent();
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
            if (whatBtn != "announcement")
            {
                SuspendLayout();
                whatBtn = "announcement";
                pageHelper.f.Close();
                announcementBtn.FillColor = Color.FromArgb(39, 72, 93);
                settingBtn.FillColor = Color.FromArgb(51, 52, 78);
                payslipBtn.FillColor = Color.FromArgb(51, 52, 78);
                pageHelper.changePage(new announcementView(), mainPanel);
                ResumeLayout();
            }
        }

        private void EmployeePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void payslipBtn_Click(object sender, EventArgs e)
        {
            if (whatBtn != "payslip" && whatBtn != "")
            {
                SuspendLayout();
                whatBtn = "payslip";
                pageHelper.f.Close();
                payslipBtn.FillColor = Color.FromArgb(39, 72, 93);
                settingBtn.FillColor = Color.FromArgb(51, 52, 78);
                announcementBtn.FillColor = Color.FromArgb(51, 52, 78);
                pageHelper.changePage(new payslipForm(), mainPanel);
                ResumeLayout();
            }
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            if (whatBtn != "setting")
            {
                SuspendLayout();
                whatBtn = "setting";
                pageHelper.f.Close();
                settingBtn.FillColor = Color.FromArgb(39, 72, 93);
                payslipBtn.FillColor = Color.FromArgb(51, 52, 78);
                announcementBtn.FillColor = Color.FromArgb(51, 52, 78);
                pageHelper.changePage(new employeeSetting(), mainPanel);
                ResumeLayout();
            }
        }
    }
}
