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
    public partial class adminPanel : Form
    {
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
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }

        private void addEmployeeBtn_Click(object sender, EventArgs e)
        {
            employeeID id = new employeeID();
            id.Show();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            employeeID id = new employeeID();
            id.saveID();
        }

        private void adminPanel_MouseDown(object sender, MouseEventArgs e)
        {
            SuspendLayout();
        }

        private void adminPanel_MouseUp(object sender, MouseEventArgs e)
        {
            ResumeLayout();
        }
    }
}
