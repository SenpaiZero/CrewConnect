using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Helper;

namespace WinFormsApp1.ManagerClass.addEmployee
{
    public partial class previewInfo1 : Form
    {
        static bool isDebug = false;
        public previewInfo1()
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

        private void previewInfo1_Load(object sender, EventArgs e)
        {
            if(!globalVariables.isDebuging)
            {
                page1LoadData();
                page2LoadData();
                page3LoadData();
                page4LoadData();
            }
        }

        void page1LoadData()
        {
            fullNameLabel.Text = $"{globalVariables.lastname.ToUpper()}, " +
                $"{globalVariables.firstname.ToUpper()} {globalVariables.middlename.ToUpper()}";
            addLabel.Text = userInterfaceHelper.limitLabelDisplay(globalVariables.streetAdd, 43);

            if (string.IsNullOrEmpty(globalVariables.streetAdd2))
                add2Label.Text = "NONE";
            else
                add2Label.Text = userInterfaceHelper.limitLabelDisplay(globalVariables.streetAdd2, 42);

            cityLabel.Text = globalVariables.state;
            postalLabel.Text = globalVariables.postal;
            if(globalVariables.permAdd.HasValue)
                permAddCB.Checked = globalVariables.permAdd.Value;
            else
                permAddCB.Checked = false;
        }

        void page2LoadData()
        {
            bdayLabel.Text = $"{globalVariables.month} {globalVariables.day}, {globalVariables.year}".ToUpper();
            ageLabel.Text = globalVariables.age.ToString();
            bloodtypeLabel.Text = globalVariables.bloodType;
            genderLabel.Text = globalVariables.gender;
            nationalityLabel.Text = globalVariables.nationality;
        }

        void page3LoadData()
        {
            // Images
            personPic.Image = globalVariables.selfPic;
            qrCodePic.Image = globalVariables.qrCodePic;

            // Text
            positionLabel.Text = globalVariables.position;
            idNumLabel.Text = globalVariables.idNum;
            phoneNumLabel.Text = globalVariables.phoneNumber;
            emailLabel.Text = globalVariables.email;
            email2Label.Text = globalVariables.email2;
        }

        void page4LoadData()
        {
            bankNameLabel.Text = globalVariables.bankName;
            branchLabel.Text = globalVariables.branch;
            companyAddLabel.Text = globalVariables.companyAdd;
            accountNameLabel.Text = globalVariables.companyName;
            accountNumLabel.Text = globalVariables.accountNum;
            bsbLabel.Text = globalVariables.BSB;
        }

        void createUsername()
        {
            globalVariables.username = globalVariables.firstname.ToUpper() + "_" + globalVariables.lastname.ToUpper();
        }

        

        private void finishBtn_Click(object sender, EventArgs e)
        {
            SuspendLayout();
            createUsername();
            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.CenterParent;
            loadingForm.loadingTime = 2500;
            loadingForm.ShowDialog();
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                string query = $"" +
                // Bank Table
                $"{globalVariables.cmd_insert_bank} VALUES (@Id, @username, @bankName," +
                $" @branch, @companyAdd, @accountName, @BSB, @accountNum);" +
                // Contact Table
                $"{globalVariables.cmd_insert_contact} VALUES (@Id, @username, @phoneNumber," +
                $"@emailAddress, @emailAddress2, @address, @adress2);" +
                // Parttime and fulltime Table
                $"{globalVariables.cmd_insert_fulltime} VALUES (@Id, @username, @name, @salary);" +
                $"{globalVariables.cmd_insert_parttime} VALUES (@Id, @username, @name, @salary);" +
                // Identity Table
                $"{globalVariables.cmd_insert_identity} VALUES (@Id, @username, @personalPhoto, @qrCodePhoto);" +
                // job Table
                $"{globalVariables.cmd_insert_job} VALUES (@Id, @username, @position, @contract);" +
                // Users Table
                $"{globalVariables.cmd_insert_Users} VALUES (@Id, @username, @password, @position);" +
                // Personal Table
                $"{globalVariables.cmd_insert_personal} VALUES (@Id, @username, @name, @birthday, @age," +
                $" @bloodType, @status, @religion, @gender)";

                String name = (globalVariables.lastname + ", " + globalVariables.firstname + " " + globalVariables.middlename).ToUpper();
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    DateTime bday = new DateTime((int)globalVariables.year, (int)globalVariables.month, (int)globalVariables.day);
                    int id_ = int.Parse(globalVariables.idNum);
                    command.Parameters.AddWithValue("@username", globalVariables.username);
                    command.Parameters.AddWithValue("@employeeID", globalVariables.idNum);
                    command.Parameters.AddWithValue("@password", globalVariables.username);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@status", globalVariables.status);
                    command.Parameters.AddWithValue("@religion", globalVariables.religion);
                    command.Parameters.AddWithValue("@gender", globalVariables.gender);
                    command.Parameters.AddWithValue("@birthday", bday);
                    command.Parameters.AddWithValue("@age", globalVariables.age);
                    command.Parameters.AddWithValue("@bloodType", globalVariables.bloodType);
                    command.Parameters.AddWithValue("@Id", id_);
                    command.Parameters.AddWithValue("@position", globalVariables.position);
                    command.Parameters.AddWithValue("@contract", globalVariables.contract);
                    command.Parameters.AddWithValue("@salary", globalVariables.salary);
                    command.Parameters.AddWithValue("@personalPhoto",validationHelper.convertBitmapToByte(globalVariables.selfPic));
                    command.Parameters.AddWithValue("@qrCodePhoto", validationHelper.convertBitmapToByte(globalVariables.qrCodePic));
                    command.Parameters.AddWithValue("@phoneNumber", globalVariables.phoneNumber);
                    command.Parameters.AddWithValue("@emailAddress", globalVariables.email);
                    command.Parameters.AddWithValue("@emailAddress2", globalVariables.email2);
                    command.Parameters.AddWithValue("@address", globalVariables.streetAdd);
                    command.Parameters.AddWithValue("@adress2", globalVariables.streetAdd2);
                    command.Parameters.AddWithValue("@bankName", globalVariables.bankName);
                    command.Parameters.AddWithValue("@branch", globalVariables.branch);
                    command.Parameters.AddWithValue("@companyAdd", globalVariables.companyAdd);
                    command.Parameters.AddWithValue("@accountName", globalVariables.accountName);
                    command.Parameters.AddWithValue("@BSB", globalVariables.BSB);
                    command.Parameters.AddWithValue("@accountNum", globalVariables.accountNum);


                    // add condition to know if data already exist

                    // Execute the query
                    command.ExecuteNonQuery();
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                employeeID id = new employeeID();
                id.Show();
                ResumeLayout();
                con.Close();
                this.Close();
            }
        }

        private void mainsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
