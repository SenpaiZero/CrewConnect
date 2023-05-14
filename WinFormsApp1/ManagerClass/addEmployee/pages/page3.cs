using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Helper;

namespace WinFormsApp1.ManagerClass.addEmployee.pages
{
    public partial class page3 : Form
    {
        public page3()
        {
            InitializeComponent();
            
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
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

        private void nextBtn_Click(object sender, EventArgs e)
        {
            pageHelper.changePage(new page4(), managerAddEmployee.panel);
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            pageHelper.changePage(new page2(), managerAddEmployee.panel);
        }
    }
}
