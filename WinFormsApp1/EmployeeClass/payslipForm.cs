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

namespace WinFormsApp1.EmployeeClass
{
    public partial class payslipForm : Form
    {
        public payslipForm()
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

        private void payslipForm_Load(object sender, EventArgs e)
        {
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

        string current = "current";
        private void changeBtn_Click(object sender, EventArgs e)
        {
            loadingForm load = new loadingForm();
            load.loadingTime = 1000;
            load.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = mainPanel.Parent.PointToScreen(mainPanel.Location);
            int loadingFormX = listTableLocationOnForm.X + (mainPanel.Width - load.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (mainPanel.Height - load.Height) / 2;
            load.Location = new Point(loadingFormX, loadingFormY);
            load.ShowDialog();

            if (current == "current")
            {
                loadPrevious();
                changeBtn.Text = "PREVIOUS";
                current = "previous";
            }
            else
            {
                loadCurrent();
                changeBtn.Text = "CURRENT";
                current = "current";
            }
        }

        void loadCurrent()
        {
            string query = $"SELECT job.Id, job.contract, job.salary, attendance.date, attendance.inTime, attendance.outTime " +
                $"FROM job " +
                $"JOIN attendance ON job.Id = attendance.Id " +
                $"WHERE job.Id = '{globalVariables.userID}'";
            //job.Id = 0
            //job.contract = 1
            //job.salary = 2
            //attendance.date = 3
            //attendance.inTime = 4
            //attendance.outTime = 5
            string id = "", contract = "", salary = "";
            DateOnly date;
            TimeOnly inTime, outTime;
            int totalHours = 0;
            int totalDays = 0;
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        salary = dr.GetSqlMoney(2).ToString();
                        contract = dr.GetString(1);
                        id = dr.GetInt32(0).ToString();

                        if (contract == "FULLTIME")
                        {
                            totalDays++;
                            DateTime dateValue = (DateTime)dr["date"];
                            date = new DateOnly(dateValue.Year, dateValue.Month, dateValue.Day);
                        }
                        else
                        {
                            TimeSpan inTimeSpan = (TimeSpan)dr["inTime"];
                            TimeSpan outTimeSpan = (TimeSpan)dr["outTime"];
                            inTime = TimeOnly.FromTimeSpan(inTimeSpan);
                            outTime = TimeOnly.FromTimeSpan(outTimeSpan);
                            if (!dr.IsDBNull(5))
                                totalHours = inTime.Hour - outTime.Hour;
                        }

                    }
                    dr.Close();

                    daysLabel.Text = totalDays.ToString() + " DAYS";
                    totalHoursLabel.Text = totalHours.ToString() + " HOURS";
                    basicPayLabel.Text = (Convert.ToDecimal(salary) * totalDays).ToString();
                }
            }
        }

        void loadPrevious()
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
