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
using CrewConnect.Helper;

namespace CrewConnect.ManagerClass.addEmployee
{
    public partial class addAnnouncement : Form
    {
        static SqlConnection con;
        public addAnnouncement()
        {
            InitializeComponent();
        }

        private void addAnnouncement_Load(object sender, EventArgs e)
        {
            if (!validationHelper.internetAvailability())
                return;
            showData();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (!validationHelper.internetAvailability())
                return;

            if (string.IsNullOrWhiteSpace(searchTB.Text))
            {
                showData();
                return;
            }

            loading();
            SqlCommand cmd;
            con.Open();
            cmd = new SqlCommand($"SELECT message, date FROM announcement WHERE message LIKE '%{searchTB.Text}%'", con);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            listTable.DataSource = dt;
            con.Close();
        }
        void showData()
        {
            loading();
            try
            {
                con = new SqlConnection(globalVariables.server);
                SqlCommand cmd = new SqlCommand("SELECT message, date FROM announcement", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                listTable.DataSource = dt;
            }
            catch (Exception ex)
            {
                messageDialogForm msg = new messageDialogForm();
                msg.title = "AN ERROR HAS OCCURED";
                msg.message = ex.Message;
                msg.ShowDialog();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            searchTB.Text = "";
            showData();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            loading();
            string selectedMsg = "";
            if (listTable.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = listTable.SelectedRows[0];
                selectedMsg = selectedRow.Cells[0].Value.ToString();
            }
            string query = "DELETE FROM announcement WHERE message = @selectedMsg";

            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@selectedMsg", selectedMsg);
                    messageDialogForm msg = new messageDialogForm();
                    msg.title = "ARE YOU SURE?";
                    msg.message = "YOU ARE ABOUT TO DELETE AN ANNOUNEMENT MESSAGE";
                    msg.isOkDialog = true;

                    if (msg.ShowDialog() == DialogResult.OK)
                    {
                        searchBtn.PerformClick();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            loading();
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            string query = $"INSERT INTO announcement (message, date)" +
                            $"VALUES ('{newMsgTB.Text}', '{date.ToShortDateString()}');";
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.ExecuteNonQuery();
                searchBtn.PerformClick();

                messageDialogForm msg = new messageDialogForm();
                msg.title = "YOU'VE SUCCESSFULLY ADDED AN ANNOUNEMENT";
                msg.message = newMsgTB.Text + "\n" + date;
                msg.ShowDialog();
            }
            con.Close();
        }

        void loading()
        {
            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = listTable.Parent.PointToScreen(listTable.Location);
            int loadingFormX = listTableLocationOnForm.X + (listTable.Width - loadingForm.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (listTable.Height - loadingForm.Height) / 2;
            loadingForm.Location = new Point(loadingFormX, loadingFormY);

            loadingForm.loadingTime = 1000;
            loadingForm.ShowDialog();
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
