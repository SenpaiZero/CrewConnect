using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using WinFormsApp1.Helper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            String[] data = { idNumTB.Text, phoneNumTB.Text, emailTB.Text };
            // Debuging purposes
            if (globalVariables.isDebuging)
                pageHelper.changePage(new page4(), managerAddEmployee.panel);
            else
                // End of debugging
                if (personalPic.Image != null && !data.Any(string.IsNullOrWhiteSpace)
                    && positionCB.Text != "POSTION")
                {
                    globalVariables.position = positionCB.Text;
                    globalVariables.email = emailTB.Text;
                    globalVariables.phoneNumber = phoneNumTB.Text;
                    globalVariables.idNum = idNumTB.Text;

                    if (string.IsNullOrWhiteSpace(guardianTB.Text))
                        globalVariables.email2 = "NONE";
                    else
                        globalVariables.email2 = guardianTB.Text;

                    pageHelper.changePage(new page4(), managerAddEmployee.panel);
                }
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

        private void mainsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void page3_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"SELECT position FROM system", con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Store the data in a DataTable
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    // Bind the data to the ComboBox
                    positionCB.DataSource = dataTable;
                    positionCB.DisplayMember = "position"; // Display the "Name" column
                    reader.Close();
                }
            }
        }
    }
}
