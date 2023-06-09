﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewConnect.Helper;
using CrewConnect.Helper.email;
using CrewConnect.ManagerClass;
using Guna.UI2.WinForms;
using Microsoft.SqlServer.Server;
using static QRCoder.PayloadGenerator.SwissQrCode;

namespace CrewConnect.EmployeeClass
{
    public partial class payslipForm : Form
    {
        public static payslipForm payslip;
        string current = "current";

        public payslipForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        string id = "", contract = "", salary = "", position = "";
        DateOnly date;
        TimeOnly inTime, outTime;
        int totalHours = 0;
        int totalDays = 0;
        double otHours = 0;
        double otPay = 0;
        double basicIncome = 0;
        double allowance = 0;
        double others = 0;
        double grossPay = 0;
        double deduction = 0;
        double netpay = 0;
        double sssDed = 0;
        double pagIbigDed = 0;
        double philHealthDed = 0;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }

        void loading()
        {
            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = center.Parent.PointToScreen(center.Location);
            int loadingFormX = listTableLocationOnForm.X + (center.Width - loadingForm.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (center.Height - loadingForm.Height) / 2;
            loadingForm.Location = new Point(loadingFormX, loadingFormY);

            loadingForm.loadingTime = 1000;
            loadingForm.ShowDialog();
        }

        private void payslipForm_Load(object sender, EventArgs e)
        {
            payslip = this;

            loadCurrent("attendance");
            positionLabel.Text = globalVariables.userPosition;
            try
            {
                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT name FROM personal WHERE username = '{globalVariables.username}'", con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            nameLabel.Text = dr.GetString(0);
                        }
                        else
                        {
                            nameLabel.Text = "ADMIN";
                        }
                        dr.Close();
                    }

                    using (SqlCommand cmd = new SqlCommand($"SELECT position FROM job WHERE username = '{globalVariables.username}'", con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            positionLabel.Text = dr.GetString(0);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                messageDialogForm msg = new messageDialogForm();
                msg.title = "AN ERROR HAS OCCURED";
                msg.message = ex.Message;
                msg.ShowDialog();
            }
        }

        public void shortcut(KeyEventArgs e)
        {
            if (changeBtn.Focused || emailBtn.Focused)
                return;

            if (e.KeyCode == Keys.Space)
            {
                changeBtn.PerformClick();
            }

            if (e.KeyCode == Keys.Enter)
            {
                emailBtn.PerformClick();
            }

            Parent.Focus();
        }
        private void payslipForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void changeBtn_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void changeBtn_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            if (current == "current")
            {
                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand($"SELECT name FROM attendance_prev WHERE Id = '{globalVariables.userID}'", con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if(!dr.Read())
                        {
                            messageDialogForm msg = new messageDialogForm();
                            msg.title = "DATA DOES NOT EXIST";
                            msg.message = "You either don't have past data or something went wrong";
                            msg.ShowDialog();
                            return;
                        }
                    }
                }

                loadCurrent("attendance_prev");
                changeBtn.Text = "PREVIOUS";
                current = "previous";
            }
            else
            {
                loadCurrent("attendance");
                changeBtn.Text = "CURRENT";
                current = "current";
            }
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        Bitmap capturedImage;
        private void printBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDocument = new PrintDocument();
                printPayslip print = new printPayslip();

                changeColorPrint(true);
                capturedImage = userInterfaceHelper.CapturePanelImage(this);
                printDocument.PrintPage += PrintDocument_PrintPage;

                print.doc = printDocument;
                changeColorPrint(false);
                // Show the print preview form
                if (print.ShowDialog() == DialogResult.OK)
                {
                    messageDialogForm msg = new messageDialogForm()
                    {
                        title = "PRINT SUCCESS",
                        message = "Your payslip is about to print. If it failed please check" +
                        " the print queue"
                    };
                    msg.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                messageDialogForm msg = new messageDialogForm()
                {
                    title = "AN ERROR OCCURED",
                    message = ex.Message.ToString()
                };

                msg.ShowDialog();
            }
            
        }


        public bool printPage()
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.PrintPage += PrintDocument_PrintPage;

                // Print the image
                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDoc;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDoc.Print();
                    return true;
                }
            }
            catch (Exception e)
            {
                messageDialogForm msg = new messageDialogForm()
                {
                    title = "AN ERROR OCCURED",
                    message = e.Message
                };

                msg.ShowDialog();
            }
            
            return false;
        }
        private void changeColorPrint(bool isPrint)
        {
            if (isPrint)
            {
                foreach (Control item in mainPanel.Controls)
                {
                    if(item is Guna2HtmlLabel tb)
                    {
                        tb.ForeColor = Color.Black;
                    }
                }

                printBtn.Visible = false;
                emailBtn.Visible = false;
                mainPanel.BackColor = Color.White;
            }
            else
            {
                foreach (Control item in mainPanel.Controls)
                {
                    if (item is Guna2HtmlLabel tb)
                    {
                        tb.ForeColor = Color.WhiteSmoke;
                    }
                }

                printBtn.Visible = true;
                emailBtn.Visible = true;
                mainPanel.BackColor = Color.FromArgb(39, 72, 93);
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

            // Calculate the aspect ratio of the captured image
            if(capturedImage == null)
            {
                changeColorPrint(true);
                capturedImage = userInterfaceHelper.CapturePanelImage(this);
                changeColorPrint(false);
            }
            
            float imageAspectRatio = (float)capturedImage.Width / capturedImage.Height;

            // Calculate the dimensions to fit the image within the margin bounds
            int maxWidth = e.MarginBounds.Width;
            int maxHeight = (int)(maxWidth / imageAspectRatio) + 90;

            if (maxHeight > e.MarginBounds.Height)
            {
                maxHeight = e.MarginBounds.Height;
                maxWidth = (int)(maxHeight * imageAspectRatio);
            }

            // Calculate the position to center the image on the page
            int imageX = e.MarginBounds.Left + (e.MarginBounds.Width - maxWidth) / 2;
            int imageY = e.MarginBounds.Top + (e.MarginBounds.Height - maxHeight) / 2;

            // Print the image onto the page
            e.Graphics.DrawImage(capturedImage, imageX, imageY, maxWidth, maxHeight);
        }

        public static bool isFirstRun = true;
        void loadCurrent(string table)
        {
            Task.Run(
                () =>
                {
                    string query = $"SELECT job.Id, job.contract, job.salary, {table}.date, {table}.inTime, {table}.outTime " +
                $"FROM job " +
                $"JOIN {table} ON job.Id = {table}.Id " +
                $"WHERE job.Id = '{globalVariables.userID}'";

                    id = "";
                    contract = "";
                    salary = "";
                    DateOnly date;
                    TimeOnly inTime, outTime;
                    totalHours = 0;
                    totalDays = 0;
                    otHours = 0;
                    otPay = 0;
                    basicIncome = 0;
                    allowance = 2000;
                    others = 0;
                    grossPay = 0;
                    deduction = 0;
                    netpay = 0;
                    sssDed = 585;
                    pagIbigDed = 100;
                    philHealthDed = 260;
                    Boolean isValid = false;

                    //job.Id = 0
                    //job.contract = 1
                    //job.salary = 2
                    //attendance.date = 3
                    //attendance.inTime = 4
                    //attendance.outTime = 5
                    using (SqlConnection con = new SqlConnection(globalVariables.server))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            SqlDataReader dr = cmd.ExecuteReader();
                            SuspendLayout();
                            while (dr.Read())
                            {
                                salary = dr.GetSqlMoney(2).ToString();
                                contract = dr.GetString(1);
                                id = dr.GetInt32(0).ToString();
                                TimeSpan inTimeSpan = (TimeSpan)dr["inTime"];
                                TimeSpan outTimeSpan = (TimeSpan)dr["outTime"];

                                inTime = TimeOnly.FromTimeSpan(inTimeSpan);
                                outTime = TimeOnly.FromTimeSpan(outTimeSpan);
                                if (contract == "FULLTIME")
                                {
                                    totalDays++;
                                    DateTime dateValue = (DateTime)dr["date"];
                                    date = new DateOnly(dateValue.Year, dateValue.Month, dateValue.Day);


                                    // overtime
                                    if (!dr.IsDBNull(5))
                                    {
                                        TimeSpan timeDiff = (TimeSpan.FromHours(inTime.Hour) - TimeSpan.FromHours(outTime.Hour)).Duration();
                                        if (timeDiff.TotalHours > 8)
                                            otHours += timeDiff.TotalHours - 8;
                                    }
                                }
                                else
                                {
                                    if (!dr.IsDBNull(5))
                                        totalHours += inTime.Hour - outTime.Hour;
                                }
                                isValid = true;
                            }
                            dr.Close();
                            ResumeLayout();


                            if (contract == "FULLTIME")
                            {
                                hoursLabel.Text = "OVERTIME HOURS";
                                numDayLabel.Visible = true;
                                daysLabel.Visible = true;

                                if (isValid)
                                {
                                    basicIncome = (double)Convert.ToDecimal(salary) * Math.Abs(totalDays);
                                    otPay = Math.Ceiling(otHours * 100);

                                }
                                else
                                {
                                    basicIncome = 0.00;
                                    otPay = 0.00;
                                }

                                totalHoursLabel.Text = Math.Ceiling(otHours).ToString() + " HOURS";
                                daysLabel.Text = totalDays.ToString() + " DAYS";
                                otPayLabel.Text = Math.Abs(otPay).ToString();
                            }
                            else
                            {
                                hoursLabel.Text = "NO. OF HOURS";
                                numDayLabel.Visible = false;
                                daysLabel.Visible = false;
                                otPay = 0.00;

                                if (isValid)
                                {
                                    basicIncome = (double)Convert.ToDecimal(salary) * Math.Abs(totalHours);
                                }
                                else
                                {
                                    basicIncome = 0.00;
                                }
                                totalHoursLabel.Text = Math.Abs(totalHours).ToString() + " HOURS";

                            }

                            grossPay = Math.Abs(basicIncome + allowance + others + otPay);
                            deduction = sssDed + pagIbigDed + philHealthDed;
                            netpay = grossPay - deduction;

                            otPayLabel.Text = otPay.ToString("F2");
                            allowanceLabel.Text = allowance.ToString("F2");
                            basicPayLabel.Text = basicIncome.ToString("F2");
                            sssLabel.Text = sssDed.ToString("F2");
                            pagIbigLabel.Text = pagIbigDed.ToString("F2");
                            philHealthLabel.Text = philHealthDed.ToString("F2");

                            grossPayLabel.Text = grossPay.ToString("F2");
                            totalDeductionLabel.Text = deduction.ToString("F2");
                            netpayLabel.Text = "NET PAY: " + netpay.ToString("F2");
                        }
                    }
                }
            );

            if(isFirstRun)
            {

                isFirstRun = false;
                return;
            }
                loading();
        }
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void emailBtn_Click(object sender, EventArgs e)
        {
            string email = "";
            string position = "";
            Task.Run(() => {
                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    string query = $"SELECT emailAddress FROM contact WHERE username = '{globalVariables.username}'";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            email = dr.GetString(0);
                        }
                        dr.Close();
                    }

                    string query2 = $"SELECT position FROM job WHERE username = '{globalVariables.username}'";
                    using (SqlCommand cmd = new SqlCommand(query2, con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            position = dr.GetString(0);
                        }
                        dr.Close();
                    }
                }
                emailBtn.Visible = false;
                printBtn.Visible = false;
                Bitmap capturedImage = userInterfaceHelper.CapturePanelImage(this);
                emailHelper.sendEmail_payslip(email, capturedImage);
            });

            loading();
            printBtn.Visible = true;
            emailBtn.Visible = true;

            messageDialogForm msg1 = new messageDialogForm()
            {
                title = "Your Email Has Been Sent!",
                message = "Please check your spam if you did not recieve the email!"
            };

            msg1.ShowDialog();
        }
    }
}
