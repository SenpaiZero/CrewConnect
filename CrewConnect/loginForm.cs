using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using CrewConnect.ManagerClass;
using CrewConnect.Helper;
using CrewConnect.EmployeeClass;

namespace CrewConnect
{
    public partial class loginForm : Form
    {

        static String whatBtn = "";
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;

        bool isAtt = false;
        public loginForm()
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

        // loginBtn
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (whatBtn != "login" && whatBtn != "")
            {
                whatBtn = "login";
                attendanceBtn.FillColor = Color.FromArgb(51, 52, 78);
                loginBtn.FillColor = Color.FromArgb(39, 72, 93);
                pageHelper.f.Close();
            }
            Focus();
        }

        // AttendanceBtn
        private void attendanceBtn_Click(object sender, EventArgs e)
        {
            if(whatBtn != "attendance")
            {
                whatBtn = "attendance";
                loginBtn.FillColor = Color.FromArgb(51, 52, 78);
                attendanceBtn.FillColor = Color.FromArgb(39, 72, 93);
                pageHelper.changePage(new attendance(), this.mainsPanel);
            }
            Focus();
        }

        //Login btn
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            userInterfaceHelper.closeShortcut();

            if (!validationHelper.internetAvailability())
                return;
            SuspendLayout();

            // Storing the variable from textbox
            String username, password;
            username = userNameTB.Text.Trim();
            password = passwordTB.Text.Trim();

            // Loading in the center of panel
            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = mainsPanel.Parent.PointToScreen(mainsPanel.Location);
            int loadingFormX = listTableLocationOnForm.X + (mainsPanel.Width - loadingForm.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (mainsPanel.Height - loadingForm.Height) / 2;
            loadingForm.Location = new Point(loadingFormX, loadingFormY);

            loadingForm.loadingTime = 2500;
            loadingForm.ShowDialog();


            try
            {
                con.Open();
                adminPanel ad = new adminPanel();
                EmployeePanel em = new EmployeePanel();
                if (password == "ADMIN")
                {
                    // if the username is ADMIN, don't use hash
                    cmd = new SqlCommand($"SELECT * FROM Users WHERE username COLLATE Latin1_General_CS_AS = '{username}'" +
                        $" AND password COLLATE Latin1_General_CS_AS = '{password}'", con);
                }
                else
                {
                    // Checking if username and hashed password is in the database
                    cmd = new SqlCommand($"SELECT * FROM Users WHERE username COLLATE Latin1_General_CS_AS = '{username}'" +
                        $" AND password COLLATE Latin1_General_CS_AS = '{securityHelper.HashPassword(password)}'", con);
                }
                dr = cmd.ExecuteReader();


                //continue if it exist in database
                if (dr.Read())
                {
                    globalVariables.userPosition = dr.GetString(3).ToUpper();
                    globalVariables.username = dr.GetString(1).ToUpper();
                    globalVariables.userID = dr.GetInt32(0).ToString();
                    dr.Close();

                    if (globalVariables.userID != "0")
                    {
                        cmd = new SqlCommand($"SELECT name FROM personal WHERE Id = '{globalVariables.userID}'", con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                            globalVariables.userFullName = dr.GetString(0).ToUpper();
                    }

                    this.Hide();
                    if (globalVariables.adminList.Any(item => item.Contains(globalVariables.userPosition.ToUpper())))
                    {
                        ad.StartPosition = FormStartPosition.CenterParent;
                        ad.ShowDialog();
                    }
                    else
                    {
                        em.StartPosition = FormStartPosition.CenterParent;
                        em.ShowDialog();
                    }

                    dr.Close();
                    this.Close();
                }
                else
                {
                    dr.Close();
                    messageDialogForm msg = new messageDialogForm()
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        title = "INCORRECT INFORMATION",
                        message = "You have entered an invalid username or password\n" +
                            "Please ensure that you check the capitalization and other details accurately."
                    };
                    
                    msg.ShowDialog();
                }
                con.Close();
            } catch(Exception ex)
            {
                messageDialogForm msg = new messageDialogForm();
                msg.title = "AN ERROR HAS OCCURED";
                msg.message = ex.Message;
                msg.ShowDialog();
            }
            ResumeLayout();
        }

        // Show password
        private void guna2TextBox2_IconRightClick(object sender, EventArgs e)
        {
            if(passwordTB.PasswordChar.ToString() == "●")
            {
                passwordTB.PasswordChar = '\0';
            }
            else
            {
                passwordTB.PasswordChar = '●';
            }
        }

        private void maximiseBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void passwordTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                mainsPanel.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                guna2Button2.PerformClick();
            }
        }

        private async void loginForm_Shown(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            if (!validationHelper.internetAvailability())
            {
                NoConnectionForm noNetwork = new NoConnectionForm();
                noNetwork.StartPosition = FormStartPosition.CenterParent;
                noNetwork.ShowDialog();
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            con = new SqlConnection(globalVariables.server);
            DateTime date = DateTime.Today;
            dateLabel.Text = date.ToShortDateString();
        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(con.State == System.Data.ConnectionState.Open)
                con.Close();

            e.Cancel = true;
        }

        private void passwordTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            userInterfaceHelper.openScreenKeyboard();
            Focus();
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
                    "Textbox", "Textbox", "Textbox", "Attendance", "Attendance", "Menu", "Menu"
                },
                Names = new string[]
                {
                    "Change Focus", "Enter Login", "Unfocus Textbox", "Scan", "Cancel", "Login Menu", "Attendance Menu"
                },
                Key = new string[]
                {
                    "TAB/ENTER", "ENTER", "CTRL + SPACE", "SPACE BAR", "CTRL + SPACE BAR", "NUM 1", "NUM 2"
                },
            };

            Size size = shortcut.Size;
            shortcut.Size = new Size(size.Width, this.Height);
            shortcut.showAsSide(this);
            shortcut.Show();
            Focus();
        }

        // Keyboard shortcut functions
        private void loginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (userNameTB.Focused || passwordTB.Focused)
                return;

            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                loginBtn.PerformClick();
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                attendanceBtn.PerformClick();
            }

            if (whatBtn == "attendance")
            {
                attendance.att.shortCut(e);
            }
                
            Focus();
        }

        // username textbox keyboard functions
        private void userNameTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                e.SuppressKeyPress = false;
                mainsPanel.Focus();
            }

            if (e.KeyCode == Keys.Enter)
                passwordTB.Focus();
        }

        private void minimiseBtn_Click(object sender, EventArgs e)
        {
            detailsForm detail = new detailsForm();
            detail.StartPosition = FormStartPosition.CenterParent;
            detail.ShowDialog();
            Focus();
        }

        private void loginForm_LocationChanged(object sender, EventArgs e)
        {
            if(shortcut != null)
            {
                shortcut.showAsSide(this);
            }
        }

        private void mainsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}