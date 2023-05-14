using Guna.UI2.WinForms;
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
using WinFormsApp1.ManagerClass.addEmployee.pages;

namespace WinFormsApp1.ManagerClass
{
    public partial class managerAddEmployee : Form
    {
        private static String name, role, idNum;
        private static Bitmap photo, qrPhoto;
        public static Guna2Panel panel;
        public managerAddEmployee()
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
        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        public static void createID()
        {
            employeeID id = new employeeID();

            Name = "Arquio, kyla lim".ToUpper();
            Role = "janitor".ToUpper();
            Id = "employee # 02203884".ToUpper();
            Photo = (Bitmap)Bitmap.FromFile("C:\\Users\\Xeb\\Downloads\\kyla.jpg");
            QRPhoto = (Bitmap)Bitmap.FromFile("C:\\Users\\Xeb\\Downloads\\qr.png");
        }

        public static String Name
        {
            set { name = value; }
            get { return name; }
        }

        public static String Role
        {
            set { role = value; }
            get { return role; }
        }

        public static String Id
        {
            set { idNum = value; }
            get { return idNum; }
        }

        public static Bitmap Photo
        {
            set { photo = value; }
            get { return photo; }
        }

        private void managerAddEmployee_Load(object sender, EventArgs e)
        {
            positionLabel.Text = globalVariables.userPosition;
            panel = this.mainPanel;
            pageHelper.changePage(new page1(), panel);
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void managerAddEmployee_Load_1(object sender, EventArgs e)
        {

        }

        public static Bitmap QRPhoto
        {
            set { qrPhoto = value; }
            get { return qrPhoto; }
        }
        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            createID();
            employeeID id = new employeeID();
            id.Show();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            employeeID id = new employeeID();
            id.saveID();
        }


    }
}
