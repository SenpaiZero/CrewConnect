using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewConnect.Helper;
using CrewConnect.ManagerClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CrewConnect
{
    public partial class attendance : Form
    {
        public static attendance att;
        public attendance()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;

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
        private void attendance_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                cameraHelper.qrcode = true;
                cameraHelper.camListCB = camListCB;
                cameraHelper.selfPic = camera;
                cameraHelper.name = "home";
                cameraHelper.onLoad();
            });
            att = this;
        }

        private void attendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            SuspendLayout();
            cameraHelper.closeForm();
            ResumeLayout();
        }

        private void scanBtn_Click(object sender, EventArgs e)
        {
            if (cameraHelper.isDetect == false)
                return;

            cameraHelper.start(camListCB.SelectedIndex);
            cameraHelper.isDetect = false;

            if (!cameraHelper.isValid)
                return;

            loadingForm load = new loadingForm();
            load.loadingTime = 1200;
            load.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = mainsPanel.Parent.PointToScreen(mainsPanel.Location);
            int loadingFormX = listTableLocationOnForm.X + (mainsPanel.Width - load.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (mainsPanel.Height - load.Height) / 2;
            load.Location = new Point(loadingFormX, loadingFormY);
            load.ShowDialog();

            CheckForIllegalCrossThreadCalls = false;
            att.nameTB.Text = "";
            att.idTB.Text = "";
            att.dateTB.Text = "";
            att.timeTB.Text = "";

            nameTB.FillColor = Color.White;
            idTB.FillColor = Color.White;
            dateTB.FillColor = Color.White;
            timeTB.FillColor = Color.White;

            setAttendance();
        }

        void setAttendance()
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today);
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("HH:mm:ss"); // e.g., 15:30:00
            string formattedDate = currentDate.ToShortDateString(); // e.g., 2023-06-08

            try
            {
                // This 
                string query = $"" +
                    $"SELECT outTime " +
                    $"FROM attendance " +
                    $"WHERE Id = @id " +
                    $"AND date = @date " +
                    $"ORDER BY date DESC";
                using (SqlConnection con = new SqlConnection(globalVariables.server))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(cameraHelper.idNum));
                        cmd.Parameters.AddWithValue("@date", formattedDate);
                        SqlDataReader dr = cmd.ExecuteReader();

                        // Check if the user is already in
                        if(dr.Read())
                        {
                            // Checks if the user is already done (kung nag out na)
                            if(dr.IsDBNull(0))
                            {
                                dr.Close();
                                string query2 = $"" +
                                    $"UPDATE attendance " +
                                    $"SET outTime = @out " +
                                    $"WHERE Id = @id ";
                                using (SqlCommand cmd2 = new SqlCommand(query2, con))
                                {
                                    cmd2.Parameters.AddWithValue("@out", formattedTime);
                                    cmd2.Parameters.AddWithValue("@id", Convert.ToInt32(cameraHelper.idNum));
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                messageDialogForm msg = new messageDialogForm();
                                msg.title = "ATTENDANCE COMPLETED";
                                msg.message = "You already checked in and out today!";
                                msg.ShowDialog();
                            }
                        }
                        else
                        {
                            dr.Close();
                            // Creates a row for in time
                            string query2 = $"" +
                                $"INSERT INTO attendance (Id, name, date, inTime) " +
                                $"VALUES (@id, @name, @date, @inTime)";
                            using (SqlCommand cmd2 = new SqlCommand(query2, con))
                            {
                                cmd2.Parameters.AddWithValue("@id", Convert.ToInt32(cameraHelper.idNum));
                                cmd2.Parameters.AddWithValue("@name", cameraHelper.fullName);
                                cmd2.Parameters.AddWithValue("@date", cameraHelper.dateString);
                                cmd2.Parameters.AddWithValue("@inTime", formattedTime);
                                cmd2.ExecuteNonQuery();
                            }
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

        public void setData(string id, string date, string time, string name)
        {
            if (cameraHelper.isValid == false)
                return;

            CheckForIllegalCrossThreadCalls = false;
            att.nameTB.Text = name;
            att.idTB.Text = id;
            att.dateTB.Text = date;
            att.timeTB.Text = time;

            nameTB.FillColor = Color.Green;
            idTB.FillColor = Color.Green;
            dateTB.FillColor = Color.Green;
            timeTB.FillColor = Color.Green;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (cameraHelper.isDetect == false)
                return;

            loadingForm load = new loadingForm();
            load.loadingTime = 1200;
            load.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = mainsPanel.Parent.PointToScreen(mainsPanel.Location);
            int loadingFormX = listTableLocationOnForm.X + (mainsPanel.Width - load.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (mainsPanel.Height - load.Height) / 2;
            load.Location = new Point(loadingFormX, loadingFormY);
            load.ShowDialog();

            cameraHelper.start(camListCB.SelectedIndex);
            cameraHelper.isDetect = false;
            CheckForIllegalCrossThreadCalls = false;
            att.nameTB.Text = "";
            att.idTB.Text = "";
            att.dateTB.Text = "";
            att.timeTB.Text = "";

            nameTB.FillColor = Color.White;
            idTB.FillColor = Color.White;
            dateTB.FillColor = Color.White;
            timeTB.FillColor = Color.White;
        }

    }
}
