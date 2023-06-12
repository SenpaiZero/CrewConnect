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
using CrewConnect.Helper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CrewConnect.ManagerClass.addEmployee.pages
{
    
    public partial class page3 : Form
    {
        static bool[] isValid = new bool[4];
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
            pageHelper.loading(mainsPanel);
            String[] data = { idNumTB.Text, phoneNumTB.Text, emailTB.Text };

            if ((personalPic.Image != null && qrPic.Image != null) &&
            !isValid.Contains(false) && !data.Any(string.IsNullOrWhiteSpace)
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

                pageHelper.f.Close();
                if (globalVariables.isEdit)
                {
                    pageHelper.changePage(new page4(), adminPanel.panel);
                    previewInfo1 prev = new previewInfo1();
                    if (prev.ShowDialog() == DialogResult.OK)
                    {
                        pageHelper.changePage(new page1(), adminPanel.panel);
                    }
                    return;
                }
                pageHelper.changePage(new page4(), adminPanel.panel);
            }
            else
            {

                validationHelper.textBoxValidation_Email_option(guardianTB, "Email", errorProvider1);
                validationHelper.textBoxValidation_PhoneNumber(phoneNumTB, "Phone Number", errorProvider1);
                validationHelper.textBoxValidation_Email(emailTB, "Email", errorProvider1);
                validationHelper.comboBoxValidation(positionCB, "POSITION", errorProvider1);

                pageHelper.errorDetails();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (globalVariables.isEdit)
            {
                pageHelper.changePage(new page4(), adminPanel.panel);
                previewInfo1 prev = new previewInfo1();
                if (prev.ShowDialog() == DialogResult.OK)
                {
                    pageHelper.changePage(new page1(), adminPanel.panel);
                }
                return;
            }
            pageHelper.loading(mainsPanel);
            pageHelper.f.Close();
            pageHelper.changePage(new page2(), adminPanel.panel);
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int baseId = 1000;
            int randomDigits = random.Next(10000, 99999); // Generates a 5-digit random number
            String randomizedId = (baseId * 100000 + randomDigits).ToString();

            string query = $"SELECT Id FROM personal WHERE Id = {randomizedId}";
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        generateBtn.PerformClick();
                        return;
                    }
                    dr.Close();
                }
            }

            idNumTB.Text = randomizedId;
            Bitmap img = qrCodeHelper.generateQrCode(randomizedId);
            globalVariables.qrCodePic = img; 
            qrPic.Image = img;
            // img.Save($"C:\\Users\\Xeb\\Desktop\\{randomizedId}.png", ImageFormat.Png);
        }

        private void mainsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void page3_Load(object sender, EventArgs e)
        {
            validationHelper.comboBoxFirstLoad = true;
            for (int i = 0; i < isValid.Length; i++)
            {
                if(!globalVariables.isEdit)
                    isValid[i] = false;
                else
                    isValid[i] = true;
            }
            isValid[3] = true;
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

                    DataRow positionRow = dataTable.NewRow();
                    positionRow["position"] = "Position";
                    dataTable.Rows.InsertAt(positionRow, 0);

                    // Bind the data to the ComboBox
                    positionCB.DataSource = dataTable; 
                    positionCB.DisplayMember = "position";
                    reader.Close();
                }
            }
            positionCB.SelectedIndex = 0;

            if(globalVariables.isEdit)
            {
                positionCB.Text = globalVariables.position;
                personalPic.Image = globalVariables.selfPic;
                qrPic.Image = globalVariables.qrCodePic;
                phoneNumTB.Text = globalVariables.phoneNumber;
                emailTB.Text = globalVariables.email;
                guardianTB.Text = globalVariables.email2;
                idNumTB.Text = globalVariables.idNum;
            }

            errorProvider1.Clear();
            validationHelper.comboBoxFirstLoad = false;
        }

        private void fileBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                globalVariables.selfPic = new Bitmap(openFileDialog1.FileName);
                personalPic.Image = new Bitmap(globalVariables.selfPic);
            }
        }

        private void captureBtn_Click(object sender, EventArgs e)
        {
            capturePicture cap = new capturePicture();
            if(cap.ShowDialog() == DialogResult.OK)
            {
                personalPic.Image = globalVariables.selfPic;
            }
        }

        private void positionCB_Validating(object sender, CancelEventArgs e)
        {
        }

        private void phoneNumTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[0] = false;
            if(validationHelper.textBoxValidation_PhoneNumber(phoneNumTB, "Phone Number", errorProvider1))
                isValid[0] = true;
        }

        private void emailTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[1] = false;
            if (validationHelper.textBoxValidation_Email(emailTB, "Email", errorProvider1))
                isValid[1] = true;
        }

        private void guardianTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[3] = false;
            if (validationHelper.textBoxValidation_Email_option(guardianTB, "Email", errorProvider1))
                isValid[3] = true;
        }

        private void positionCB_SelectedValueChanged(object sender, EventArgs e)
        {
            isValid[2] = false;
            if(validationHelper.comboBoxValidation(positionCB, "POSITION", errorProvider1))
                isValid[2] = true;
        }

        private void emailTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
