using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using WinFormsApp1.Helper;
using WinFormsApp1.ManagerClass.addEmployee;
using WinFormsApp1.ManagerClass.addEmployee.pages;

namespace WinFormsApp1.ManagerClass
{
    public partial class adminPanel : Form
    {
        string whatBtn = "";
        public static Guna2Panel panel;
        public adminPanel()
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

        private void managerAddEmployee_Load(object sender, EventArgs e)
        {
            positionLabel.Text = globalVariables.userPosition;
            panel = this.mainPanel;
            pageHelper.changePage(new page1(), panel);

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

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (whatBtn != "add" && whatBtn != "")
            {
                SuspendLayout();
                whatBtn = "add";
                pageHelper.f.Close();
                listBtn.FillColor = Color.FromArgb(51, 52, 78);
                addBtn.FillColor = Color.FromArgb(39, 72, 93);
                settingBtn.FillColor = Color.FromArgb(51, 52, 78);
                announcementBtn.FillColor = Color.FromArgb(51, 52, 78);
                pageHelper.changePage(new page1(), panel);
                ResumeLayout();
            }
        }

        private void adminPanel_MouseDown(object sender, MouseEventArgs e)
        {
            SuspendLayout();
        }

        private void adminPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResumeLayout();
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

        private void rmvBtn_Click(object sender, EventArgs e)
        {
            if (whatBtn != "list")
            {
                globalVariables.isEdit = false;
                SuspendLayout();
                pageHelper.f.Close();
                whatBtn = "list";
                addBtn.FillColor = Color.FromArgb(51, 52, 78);
                listBtn.FillColor = Color.FromArgb(39, 72, 93);
                settingBtn.FillColor = Color.FromArgb(51, 52, 78);
                announcementBtn.FillColor = Color.FromArgb(51, 52, 78);
                pageHelper.changePage(new EmployeeList(), panel);
                ResumeLayout();
            }
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            if (whatBtn != "setting")
            {
                globalVariables.isEdit = false;
                SuspendLayout();
                pageHelper.f.Close();
                whatBtn = "setting";
                addBtn.FillColor = Color.FromArgb(51, 52, 78);
                listBtn.FillColor = Color.FromArgb(51, 52, 78);
                settingBtn.FillColor = Color.FromArgb(39, 72, 93);
                announcementBtn.FillColor = Color.FromArgb(51, 52, 78);
                pageHelper.changePage(new adminSetting(), panel);
                ResumeLayout();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (whatBtn != "announcement")
            {
                globalVariables.isEdit = false;
                SuspendLayout();
                pageHelper.f.Close();
                whatBtn = "announcement";
                addBtn.FillColor = Color.FromArgb(51, 52, 78);
                listBtn.FillColor = Color.FromArgb(51, 52, 78);
                listBtn.FillColor = Color.FromArgb(51, 52, 78);
                announcementBtn.FillColor = Color.FromArgb(39, 72, 93);
                pageHelper.changePage(new addAnnouncement(), panel);
                ResumeLayout();
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            globalVariables.isEdit = false;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
