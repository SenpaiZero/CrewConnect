using System.Drawing.Imaging;
using System.Windows.Forms;
using WinFormsApp1.ManagerClass;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        static String whatBtn = "";
        static Form f;

        public Form1()
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
        public void loadForm(object Form)
        {
            f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainsPanel.Controls.Add(f);
            this.mainsPanel.Tag = f;
            f.Show();
        }

        // loginBtn
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (whatBtn != "login")
            {
                whatBtn = "login";
                attendanceBtn.FillColor = Color.FromArgb(51, 52, 78);
                loginBtn.FillColor = Color.FromArgb(39, 72, 93);
                f.SendToBack();
                this.mainsPanel.Controls.Remove(f);
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
                loadForm(new attendance());
                f.BringToFront();
            }
        }

        // ExitBtn
        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        //Login btn
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            managerAddEmployee ad = new managerAddEmployee();
            ad.ShowDialog();
            this.Hide();
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
    }
}