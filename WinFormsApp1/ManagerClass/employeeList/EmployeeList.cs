using Guna.UI2.WinForms;
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
using WinFormsApp1.Helper;

namespace WinFormsApp1.ManagerClass
{
    public partial class EmployeeList : Form
    {
        public static string selectedID;
        public EmployeeList()
        {
            InitializeComponent();
        }
        static SqlConnection con;
        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (!validationHelper.internetAvailability())
                return;

            if (string.IsNullOrWhiteSpace(searchTB.Text))
            {
                showData();
                return;
            }

            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.CenterParent;
            loadingForm.loadingTime = 1000;
            loadingForm.ShowDialog();

            int i;
            bool result = int.TryParse(searchTB.Text,out i);
            SqlCommand cmd;
            con.Open();

            if (result) 
            {
                cmd = new SqlCommand("SELECT personal.Id, personal.name, personal.age, contact.emailAddress," +
                    " contact.phoneNumber, job.position, job.contract FROM personal INNER JOIN contact ON " +
                    $"personal.Id = contact.Id JOIN job ON personal.Id = job.Id WHERE personal.Id LIKE '%{searchTB.Text}%'", con);

                MessageBox.Show(searchTB.Text);
            }
            else
            {
                cmd = new SqlCommand("SELECT personal.Id, personal.name, personal.age, contact.emailAddress," +
                    " contact.phoneNumber, job.position, job.contract FROM personal INNER JOIN contact ON " +
                    $"personal.Id = contact.Id JOIN job ON personal.Id = job.Id WHERE personal.name LIKE '%{searchTB.Text}%'", con);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            listTable.DataSource = dt;
            con.Close();
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            if (!validationHelper.internetAvailability())
                return;
            showData();
        }

        void showData()
        {
            con = new SqlConnection(globalVariables.server);
            SqlCommand cmd = new SqlCommand("SELECT personal.Id, personal.name, personal.age, contact.emailAddress," +
                    " contact.phoneNumber, job.position, job.contract FROM personal JOIN contact ON " +
                    "personal.Id = contact.Id JOIN job ON personal.Id = job.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.CenterParent;
            loadingForm.loadingTime = 1000;
            loadingForm.ShowDialog();

            listTable.DataSource = dt;
        }

        private void openSelectedBtn_Click(object sender, EventArgs e)
        {
            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.CenterParent;
            loadingForm.loadingTime = 1200;
            loadingForm.ShowDialog();

            if (listTable.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = listTable.SelectedRows[0];
                selectedID = selectedRow.Cells[0].Value.ToString();

                MessageBox.Show(selectedID);
                showEmployee empl = new showEmployee();
                empl.Owner = this;
                empl.Show();
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            searchTB.Text = "";
            showData();
        }

        private void searchTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchBtn.PerformClick();
            }
        }
    }
}
