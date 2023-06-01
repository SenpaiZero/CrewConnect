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
using WinFormsApp1.Helper.email;

namespace WinFormsApp1.ManagerClass
{
    public partial class employeeID : Form
    {
        public employeeID()
        {
            InitializeComponent();
        }

        private void employeeID_Load(object sender, EventArgs e)
        {
            width = this.Width;
            height= this.Height;

            if (globalVariables.isDebuging)
            {
                nameLabel.Text = $"SANTOS, YGI MARTIN" +
                    $"BORLONGAN".ToUpper();

                roleLabel.Text = "PERMANENT";
                employeeLabel.Text = "EMPLOYEE # 100045013";

                employeePhoto.Image = Image.FromFile("C:\\Users\\Xeb\\Pictures\\Roblox\\RobloxScreenShot20230219_195725941.png");
                qrPhoto.Image = Image.FromFile("C:\\Users\\Xeb\\Downloads\\qr.png");
            }
            else
            {
                nameLabel.Text = $"{globalVariables.lastname}, {globalVariables.firstname} ".ToUpper() +
                $"{globalVariables.middlename}".ToUpper();

                roleLabel.Text = globalVariables.position;
                employeeLabel.Text = "EMPLOYEE # " + globalVariables.idNum;

                employeePhoto.Image = globalVariables.selfPic;
                qrPhoto.Image = globalVariables.qrCodePic;
            }

            
            saveID();
            this.Close();
        }
        public static int width
        {
            set; get;
        }

        public static int height
        {
            set; get;
        }

        public void saveID()
        {
            // Create a bitmap with the size of the form
            Bitmap bmp = new Bitmap(this.Width, this.Height);

            // Draw the form onto the bitmap
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));

            // Get the location of the picture box control
            Point location = employeePhoto.PointToScreen(Point.Empty);
            Point qr_location = qrPhoto.PointToScreen(Point.Empty);
            Point p1_location = guna2Panel1.PointToScreen(Point.Empty);
            Point p2_location = guna2Panel2.PointToScreen(Point.Empty);

            // Get the location of the picture box control relative to the form
            Point formLocation = this.PointToClient(location);
            Point qr_formLocation = this.PointToClient(qr_location);
            Point p1_formLocation = this.PointToClient(p1_location);
            Point p2_formLocation = this.PointToClient(p2_location);

            // Draw the picture box onto the bitmap
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(employeePhoto.Image, new Rectangle(formLocation, employeePhoto.Size));
                g.DrawImage(qrPhoto.Image, new Rectangle(qr_formLocation, qrPhoto.Size));
            }

            Bitmap panel1Bmp = new Bitmap(guna2Panel1.Width, guna2Panel1.Height);
            Bitmap panel2Bmp = new Bitmap(guna2Panel2.Width, guna2Panel2.Height);

            // Draw the panel onto the bitmap
            guna2Panel1.DrawToBitmap(panel1Bmp, new Rectangle(Point.Empty, panel1Bmp.Size));
            guna2Panel2.DrawToBitmap(panel2Bmp, new Rectangle(Point.Empty, panel2Bmp.Size));

            // Draw the panel bitmap onto the main bitmap
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(panel1Bmp, p1_formLocation);
                g.DrawImage(panel2Bmp, p2_formLocation);
            }

            // Save the bitmap as a file
            string directoryPath = "..\\..\\..\\Helper\\email\\images\\";
            Directory.CreateDirectory(directoryPath);
            bmp.Save(directoryPath + "id.png", ImageFormat.Png);
            globalVariables.idPic = bmp;

            // Dispose of the bitmap
            bmp.Dispose();
            panel1Bmp.Dispose();
            panel2Bmp.Dispose();

            if (globalVariables.isDebuging)
                emailHelper.sendEmail("ygisantos@gmail.com", true);
            else
                emailHelper.sendEmail(globalVariables.email);

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
