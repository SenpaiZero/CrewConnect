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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CrewConnect.EmployeeClass
{
    public partial class EmployeePanel : Form
    {
        string whatBtn = "";
        public EmployeePanel()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
            userInterfaceHelper.closeShortcut();
            payslipForm.isFirstRun = true;

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
            userInterfaceHelper.closeShortcut();
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
                this.ActiveControl = null;
                this.Focus();
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
                this.ActiveControl = null;
                this.Focus();
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            userInterfaceHelper.openScreenKeyboard();
        }

        private void minimiseBtn_Click(object sender, EventArgs e)
        {
            detailsForm detail = new detailsForm();
            detail.StartPosition = FormStartPosition.CenterParent;
            detail.ShowDialog();
        }

        private void EmployeePanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (whatBtn == "setting")
            {
                if (employeeSetting.empSet != null)
                {
                    if (employeeSetting.empSet.oldPass.Focused ||
                    employeeSetting.empSet.newPass.Focused ||
                    employeeSetting.empSet.newPass2.Focused)
                    {
                        return;
                    }

                }
            }

            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                payslipBtn.PerformClick();
            else if(e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                settingBtn.PerformClick();
            else if(e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                announcementBtn.PerformClick();

            if(whatBtn == "payslip" || whatBtn == "")
            {
                payslipForm.pay.shortcut(e);
            }

            this.ActiveControl = null;
            this.Focus();
        }
        public static shortcutForm shortcut;
        private void maximiseBtn_Click(object sender, EventArgs e)
        {
            if (shortcut != null)
                return;
            shortcut = new shortcutForm()
            {
                Category = new string[]
                {
                    "Payslip", "Payslip", "Setting", "Setting", "Menu", "Menu", "Menu"
                },
                Names = new string[]
                {
                    "Change Mode", "Send Email", "Next Textbox", "Change Password", "Payslip Menu", "Setting Menu", "Announcement Menu"
                },
                Key = new string[]
                {
                    "SPACE BAR", "ENTER", "TAB/ENTER", "ENTER", "NUM 1", "NUM 2", "NUM 3"
                },
            };
            Size size = shortcut.Size;
            shortcut.Size = new Size(size.Width, this.Height);
            shortcut.showAsSide(this);
            shortcut.Show();
        }

        private void EmployeePanel_Move(object sender, EventArgs e)
        {
            shortcut.showAsSide(this);
        }

        private void EmployeePanel_LocationChanged(object sender, EventArgs e)
        {
            if (shortcut != null)
            {
                shortcut.showAsSide(this);
            }
        }
    }
}
