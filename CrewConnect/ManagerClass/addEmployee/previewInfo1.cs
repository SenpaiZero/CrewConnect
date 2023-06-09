﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using CrewConnect.Helper;
using CrewConnect.ManagerClass.addEmployee.pages;

namespace CrewConnect.ManagerClass.addEmployee
{
    public partial class previewInfo1 : Form
    {
        static bool isDebug = false;
        public previewInfo1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
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
            page1LoadData();
            page2LoadData();
            page3LoadData();
            page4LoadData();
            
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

            stateLabel.Text = globalVariables.state;
            cityLabel.Text = globalVariables.city;
            postalLabel.Text = globalVariables.postal;
        }

        void page2LoadData()
        {
            bdayLabel.Text = $"{globalVariables.month}, {globalVariables.day}, {globalVariables.year}".ToUpper();
            ageLabel.Text = globalVariables.age.ToString();
            bloodtypeLabel.Text = globalVariables.bloodType;
            genderLabel.Text = globalVariables.gender;
            nationalityLabel.Text = globalVariables.nationality;
            religionTB.Text = globalVariables.religion;
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
            contractLabel.Text = globalVariables.contract;
        }

        void page4LoadData()
        {
            bankNameLabel.Text = globalVariables.bankName;
            branchLabel.Text = globalVariables.branch;
            companyAddLabel.Text = globalVariables.companyAdd;
            accountNameLabel.Text = globalVariables.accountName;
            accountNumLabel.Text = globalVariables.accountNum;
            bsbLabel.Text = globalVariables.BSB;
            salaryLabel.Text = globalVariables.salary;
        }

        void createUsername()
        {
            string user = (globalVariables.firstname.ToUpper() + "_" + globalVariables.lastname.ToUpper()).Replace(" ", "_");
            string query = $"SELECT username FROM personal WHERE username = '{user}'";
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        Random random = new Random();
                        int randomDigits = random.Next(1, 50);
                        if(randomDigits < 10) 
                        {
                            user += "0" + randomDigits.ToString();
                        }
                        else
                        {
                            user += randomDigits.ToString();
                        }
                    }
                    dr.Close();
                }
            }
                globalVariables.usernameNew = user.Trim();
        }

        

        private void finishBtn_Click(object sender, EventArgs e)
        {
            if (!validationHelper.internetAvailability())
            {
                NoConnectionForm cnn = new NoConnectionForm();
                cnn.StartPosition = FormStartPosition.CenterParent;
                cnn.ShowDialog(ParentForm);
                return;
            }

            createUsername();

                try
                {
                    Task.Run(() =>
                    {
                        using (SqlConnection con = new SqlConnection(globalVariables.server))
                        {
                            con.Open();
                            string query = $"" +
                            // Users Table
                            $"{globalVariables.cmd_insert_Users} VALUES (@Id, @username, @password, @position);" +
                            // job Table
                            $"{globalVariables.cmd_insert_job} VALUES (@Id, @username, @position, @contract, @salary);" +
                            // Personal Table
                            $"{globalVariables.cmd_insert_personal} VALUES (@Id, @username, @name, @birthday, @age," +
                            $" @bloodType, @status, @religion, @gender)" +
                            // Bank Table
                            $"{globalVariables.cmd_insert_bank} VALUES (@Id, @username, @bankName," +
                            $" @branch, @companyAdd, @accountName, @BSB, @accountNum);" +
                            // Contact Table
                            $"{globalVariables.cmd_insert_contact} VALUES (@Id, @username, @phoneNumber," +
                            $"@emailAddress, @emailAddress2, @address, @adress2);" +
                            // Identity Table
                            $"{globalVariables.cmd_insert_identity} VALUES (@Id, @username, @personalPhoto, @qrCodePhoto);";

                            String name = (globalVariables.lastname.Trim() + ", " + globalVariables.firstname.Trim() + " " + globalVariables.middlename.Trim()).ToUpper();
                            using (SqlCommand command = new SqlCommand(query, con))
                            {
                                DateTime bday = new DateTime((int)globalVariables.year, (int)globalVariables.month, (int)globalVariables.day);
                                int id_ = int.Parse(globalVariables.idNum);
                                command.Parameters.AddWithValue("@username", globalVariables.usernameNew.Trim());
                                command.Parameters.AddWithValue("@employeeID", globalVariables.idNum);
                                command.Parameters.AddWithValue("@password", securityHelper.HashPassword(globalVariables.usernameNew.Trim()));
                                command.Parameters.AddWithValue("@name", name.Trim());
                                command.Parameters.AddWithValue("@status", globalVariables.status.Trim());
                                command.Parameters.AddWithValue("@religion", globalVariables.religion.Trim());
                                command.Parameters.AddWithValue("@gender", globalVariables.gender.Trim());
                                command.Parameters.AddWithValue("@birthday", bday);
                                command.Parameters.AddWithValue("@age", globalVariables.age);
                                command.Parameters.AddWithValue("@bloodType", globalVariables.bloodType.Trim());
                                command.Parameters.AddWithValue("@Id", id_);
                                command.Parameters.AddWithValue("@position", globalVariables.position.Trim());
                                command.Parameters.AddWithValue("@contract", globalVariables.contract.Trim());
                                command.Parameters.AddWithValue("@salary", globalVariables.salary.Trim());
                                command.Parameters.AddWithValue("@personalPhoto", validationHelper.convertBitmapToByte(globalVariables.selfPic));
                                command.Parameters.AddWithValue("@qrCodePhoto", validationHelper.convertBitmapToByte(globalVariables.qrCodePic));
                                command.Parameters.AddWithValue("@phoneNumber", globalVariables.phoneNumber.Trim());
                                command.Parameters.AddWithValue("@emailAddress", globalVariables.email.Trim());
                                command.Parameters.AddWithValue("@emailAddress2", globalVariables.email2.Trim());
                                command.Parameters.AddWithValue("@address", globalVariables.streetAdd.Trim());
                                command.Parameters.AddWithValue("@adress2", globalVariables.streetAdd2.Trim());
                                command.Parameters.AddWithValue("@bankName", globalVariables.bankName.Trim());
                                command.Parameters.AddWithValue("@branch", globalVariables.branch.Trim());
                                command.Parameters.AddWithValue("@companyAdd", globalVariables.companyAdd.Trim());
                                command.Parameters.AddWithValue("@accountName", globalVariables.accountName.Trim());
                                command.Parameters.AddWithValue("@BSB", globalVariables.BSB.Trim());
                                command.Parameters.AddWithValue("@accountNum", globalVariables.accountNum.Trim());

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
                    });
                }
                catch (Exception ex)
                {
                    messageDialogForm msg2 = new messageDialogForm();
                    msg2.StartPosition = FormStartPosition.CenterParent;
                    msg2.title = "AN ERROR HAS OCCURED";
                    msg2.message = ex.Message;
                    msg2.ShowDialog();
                }

            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.CenterParent;
            loadingForm.loadingTime = 3000;
            loadingForm.title = "Please Wait";
            loadingForm.ShowDialog();

            messageDialogForm msg = new messageDialogForm();
            msg.StartPosition = FormStartPosition.CenterParent;
            msg.title = "EMPLOYEE HAS BEEN SAVED";
            msg.message = "YOU'VE SUCCESSFULLY ADDED A NEW EMPLOYEE!";
            msg.ShowDialog(ParentForm);

            var loadingForm2 = new loadingForm();
            loadingForm2.StartPosition = FormStartPosition.CenterParent;
            loadingForm2.title = "Sending Email";
            loadingForm2.loadingTime = 2000;
            loadingForm2.ShowDialog();

            messageDialogForm msg1 = new messageDialogForm();
            msg1.StartPosition = FormStartPosition.CenterParent;
            msg1.title = "YOUR EMAIL HAS BEEN SENT!";
            msg1.message = "Please check your spam if you did not recieve the email!";
            msg1.ShowDialog(ParentForm);

            globalVariables.isEdit = false;

        }
        private void mainsPanel_Paint(object sender, PaintEventArgs e)
        {
            TopMost = true;
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            globalVariables.isEdit = false;
            this.Close();
        }

        private void page1edit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            globalVariables.isEdit = true;
            pageHelper.f.Close();
            pageHelper.changePage(new page1(), adminPanel.panel);
            this.Close();
        }

        private void page2edit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            globalVariables.isEdit = true;
            pageHelper.f.Close();
            pageHelper.changePage(new page2(), adminPanel.panel);
            this.Close();
        }

        private void page3edit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            globalVariables.isEdit = true;
            pageHelper.f.Close();
            pageHelper.changePage(new page3(), adminPanel.panel);
            this.Close();
        }

        private void page4edit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            globalVariables.isEdit = true;
            pageHelper.f.Close();
            pageHelper.changePage(new page4(), adminPanel.panel);
            this.Close();
        }
    }
}
