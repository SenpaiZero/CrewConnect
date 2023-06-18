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
using CrewConnect.Helper;
using CrewConnect.ManagerClass.addEmployee;
using CrewConnect.ManagerClass.addEmployee.pages;

namespace CrewConnect.ManagerClass
{
    public partial class adminPanel : Form
    {
        string whatBtn = "";
        public static Guna2Panel panel;
        private Boolean isCancelExit = true;
        public adminPanel()
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

        private void managerAddEmployee_Load(object sender, EventArgs e)
        {
            logoutBtn.Cursor = Cursors.Hand;
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
                settingBtn.FillColor = Color.FromArgb(51, 52, 78);
                announcementBtn.FillColor = Color.FromArgb(39, 72, 93);
                pageHelper.changePage(new addAnnouncement(), panel);
                ResumeLayout();
            }
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            userInterfaceHelper.closeShortcut();
            globalVariables.isEdit = false;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            messageDialogForm msg = new messageDialogForm();
            msg.title = "ARE YOU SURE?";
            msg.message = "YOU ARE ABOUT TO CLOSE CREWCONNECT";
            msg.isOkDialog = true;

            if (msg.ShowDialog() == DialogResult.OK)
            {
                var loadingForm = new loadingForm();
                loginForm log = new loginForm();
                loadingForm.StartPosition = FormStartPosition.CenterParent;
                loadingForm.loadingTime = 2000;
                loadingForm.ShowDialog();

                isCancelExit = false;
                this.Hide();
                Environment.Exit(0);
            }
        }

        private void adminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = isCancelExit;
        }

        private void kbBtn_Click(object sender, EventArgs e)
        {
            userInterfaceHelper.openScreenKeyboard();
        }

        private void detailBtn_Click(object sender, EventArgs e)
        {
            detailsForm detail = new detailsForm();
            detail.StartPosition = FormStartPosition.CenterParent;
            detail.ShowDialog();
        }

        public static shortcutForm shortcut;
        private void shortcutBtn_Click(object sender, EventArgs e)
        {
            if (shortcut != null)
                return;

            shortcut = new shortcutForm()
            {
                Category = new string[]
                {
                    "Add Employee", "Add Employee", "Textbox", 
                    "Search", "Search", "Employee List", "Employee List",
                    "Setting", "Setting", "Announcement", "Announcement",
                    "Menu", "Menu", "Menu", "Menu"
                },
                Names = new string[]
                {
                    "Next Button", "Previous Button", "Stop Textbox Focus", 
                    "Focus Search Textbox", "Enter Search", "All Refresh", "Open Selected",
                    "System Tab", "Account Tab", "Delete Selected", "Focus Add Textbox",
                    "Add Employee", "Employee List", "Settings", "Announcement"
                },
                Key = new string[]
                {
                    "ENTER", "ESC", "CTRL + SPACE", 
                    "F", "ENTER", "R", "O",
                    "Q", "W", "D", "A",
                    "NUM 1", "NUM 2", "NUM 3", "NUM 4"
                },
            };

            Size size = shortcut.Size;
            shortcut.Size = new Size(size.Width, this.Height);
            shortcut.showAsSide(this);
            shortcut.Show();
        }

        private void adminPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                addBtn.PerformClick();
            if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                listBtn.PerformClick();
            if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                settingBtn.PerformClick();
            if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                announcementBtn.PerformClick();

            // list
            if(whatBtn == "list")
            {
                if(e.KeyCode == Keys.F)
                {
                    EmployeeList.empList.focusTB();
                }
                else if(e.KeyCode == Keys.R) 
                {
                    EmployeeList.empList.refresh();
                }
            }

            if(whatBtn == "setting")
            {
                if(e.KeyCode == Keys.Q)
                {
                    adminSetting.adSet.systemClick();
                }
                else if(e.KeyCode == Keys.W)
                {
                    adminSetting.adSet.accountClick();
                }
            }

            if(whatBtn == "announcement")
            {
                if (e.KeyCode == Keys.F)
                {
                    addAnnouncement.ann.focusSearch();
                }
                else if (e.KeyCode == Keys.R)
                {
                    addAnnouncement.ann.refresh();
                }
                else if(e.KeyCode == Keys.A)
                {
                    addAnnouncement.ann.focusAdd();
                }
            }

            Focus();
        }

        private void adminPanel_LocationChanged(object sender, EventArgs e)
        {
            if(shortcut != null)
                shortcut.showAsSide(this);
        }
    }
}
