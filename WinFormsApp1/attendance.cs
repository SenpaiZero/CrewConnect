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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WinFormsApp1
{
    public partial class attendance : Form
    {
        public static attendance att;
        public attendance()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void attendance_Load(object sender, EventArgs e)
        {
            att = this;
            cameraHelper.qrcode = true;
            cameraHelper.camListCB = camListCB;
            cameraHelper.selfPic = camera;
            cameraHelper.name = "home";
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
            CheckForIllegalCrossThreadCalls = false;
            att.nameTB.Text = "";
            att.idTB.Text = "";
            att.dateTB.Text = "";
            att.timeTB.Text = "";
        }

        public void setData(string id, string date, string time, string name)
        {
            if (cameraHelper.isValid == false)
                return;

            CheckForIllegalCrossThreadCalls = false;
            att.nameTB.Text = name;
            att.idTB.Text = id;
            att.dateTB.Text = date;
            att.timeTB.Text = time;

        }
    }
}
