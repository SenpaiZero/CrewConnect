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
    public partial class page4 : Form
    {
        public page4()
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

        private void prevBtn_Click(object sender, EventArgs e)
        {
            pageHelper.changePage(new page3(), managerAddEmployee.panel);
        }

        private void page4_Load(object sender, EventArgs e)
        {
            String[] contacts =
            {
                "PERMANENT", "PART-TIME"
            };
            contractCB.Items.Clear();
            userInterfaceHelper.comboBoxValue(contractCB, contacts);
        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            previewInfo1 prev = new previewInfo1();
            prev.ShowDialog();
        }
    }
}
