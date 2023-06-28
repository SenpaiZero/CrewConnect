using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewConnect.Helper;
using CrewConnect.ManagerClass;

namespace CrewConnect
{
    public partial class NoConnectionForm : Form
    {
        public NoConnectionForm()
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var loadingForm = new loadingForm();
            loginForm log = new loginForm();
            loadingForm.StartPosition = FormStartPosition.CenterParent;
            loadingForm.loadingTime = 2000;
            loadingForm.ShowDialog();

            adminPanel.isCancelExit = false;
            this.Hide();
            Environment.Exit(0);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadingForm load = new loadingForm();
            load.StartPosition = FormStartPosition.CenterParent;
            load.ShowDialog();
            if (validationHelper.internetAvailability())
            {
                this.Close();
            }
        }

        private void NoConnectionForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }
    }
}
