using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WinFormsApp1.ManagerClass;
using WinFormsApp1.Helper;
using WinFormsApp1.EmployeeClass;

namespace WinFormsApp1
{
    public partial class loginForm : Form
    {
        public static bool isDone = false;

        static String whatBtn = "";
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader dr;

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
        }

        //Login btn
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!validationHelper.internetAvailability())
                return;
            SuspendLayout();

            String username, password;
            username = userNameTB.Text;
            password = passwordTB.Text;

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
                    cmd = new SqlCommand($"SELECT * FROM Users WHERE username COLLATE Latin1_General_CS_AS = '{username}'" +
                        $" AND password COLLATE Latin1_General_CS_AS = '{password}'", con);
                }
                else
                {
                    cmd = new SqlCommand($"SELECT * FROM Users WHERE username COLLATE Latin1_General_CS_AS = '{username}'" +
                        $" AND password COLLATE Latin1_General_CS_AS = '{securityHelper.HashPassword(password)}'", con);
                }
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    string[] adminList_ = { "OWNER", "ADMIN", "MANAGER" };
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
                    if (adminList_.Any(item => item.Contains(globalVariables.userPosition.ToUpper())))
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
                    messageDialogForm msg = new messageDialogForm();
                    msg.title = "INCORRECT INFORMATION";
                    msg.message = "You have entered an invalid username or password\n" +
                        "Please ensure that you check the capitalization and other details accurately.";
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

        private void minimiseBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void passwordTB_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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
            con = new SqlConnection(globalVariables.server);
        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(con.State == System.Data.ConnectionState.Open)
                con.Close(); 
        }
    }
}