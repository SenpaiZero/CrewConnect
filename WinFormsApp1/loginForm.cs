using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WinFormsApp1.ManagerClass;
using WinFormsApp1.Helper;

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
            String username, password;
            username = userNameTB.Text;
            password = passwordTB.Text;

            using (con = new SqlConnection(globalVariables.server))
            {
                var loadingForm = new loadingForm();
                loadingForm.StartPosition = FormStartPosition.CenterParent;
                loadingForm.loadingTime = 2500;
                loadingForm.ShowDialog();
                con.Open();
                    managerAddEmployee ad = new managerAddEmployee();
                    cmd = new SqlCommand($"SELECT * FROM Users WHERE username = '{username}' AND password = '{password}'", con);
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                            globalVariables.userPosition = dr.GetString(3).ToUpper();
                            globalVariables.username = dr.GetString(1).ToUpper();
                            dr.Close();

                            this.Hide();
                            ad.StartPosition = FormStartPosition.CenterParent;
                            ad.ShowDialog();
                            this.Dispose(true);
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("INCORRECT");
                    }
                }
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

        private void closeBtn_Click(object sender, EventArgs e)
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

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            globalVariables.isDebuging = true;
            MessageBox.Show("Debugging turned on!");
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {


        }
    }
}