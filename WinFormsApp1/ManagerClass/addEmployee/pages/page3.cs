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

        private void generateBtn_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int baseId = 1000;

            int randomDigits = random.Next(10000, 99999); // Generates a 5-digit random number

            String randomizedId = (baseId * 100000 + randomDigits).ToString();

            idNumTB.Text = randomizedId;
            Bitmap img = qrCodeHelper.generateQrCode(randomizedId);
            qrPic.Image = img;
            img.Save($"C:\\Users\\Xeb\\Desktop\\{randomizedId}.png", ImageFormat.Png);
        }
    }
}
