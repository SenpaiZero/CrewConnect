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

namespace WinFormsApp1
{
    public partial class attendance : Form
    {
        public attendance()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void attendance_Load(object sender, EventArgs e)
        {
            cameraHelper.qrcode = true;
            cameraHelper.camListCB = camListCB;
            cameraHelper.selfPic = camera;
            cameraHelper.onLoad();
        }

        private void attendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            SuspendLayout();
            cameraHelper.closeForm();
            ResumeLayout();
        }

        private void scanBtn_Click(object sender, EventArgs e)
        {
            cameraHelper.start(camListCB.SelectedIndex);
        }
    }
}
