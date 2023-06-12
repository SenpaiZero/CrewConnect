using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using CrewConnect.Helper;

namespace CrewConnect.ManagerClass.addEmployee
{
    public partial class capturePicture : Form
    {
        

        public capturePicture()
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

        private void capturePicture_Load(object sender, EventArgs e)
        {
            cameraHelper.qrcode = false;
            cameraHelper.camListCB = camListCB;
            cameraHelper.selfPic = selfPic;
            cameraHelper.onLoad();
        }

        

        private void capturePicture_FormClosing(object sender, FormClosingEventArgs e)
        {
            cameraHelper.closeForm();
        }

        private void camListCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            cameraHelper.changeCam(camListCB.SelectedIndex);
        }

        private void captureBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            cameraHelper.captureBtn();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
