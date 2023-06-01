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
            int i;
            bool result = int.TryParse(searchTB.Text,out i);
            
            con.Open();

            if (result)
            {
                SqlCommand cmd = new SqlCommand("SELECT personal.Id, personal.name, personal.age, contact.emailAddress," +
                    " contact.phoneNumber, job.position, job.contract FROM personal INNER JOIN contact ON " +
                    "personal.Id = contact.Id JOIN job ON personal.Id = job.Id", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                listTable.DataSource = dt;
            }
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(globalVariables.server);
            SqlCommand cmd = new SqlCommand("SELECT personal.Id, personal.name, personal.age, contact.emailAddress," +
                    " contact.phoneNumber, job.position, job.contract FROM personal JOIN contact ON " +
                    "personal.Id = contact.Id JOIN job ON personal.Id = job.Id", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            listTable.DataSource = dt;

        }

        private void openSelectedBtn_Click(object sender, EventArgs e)
        {
            if (listTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = listTable.SelectedRows[0];
                selectedID = selectedRow.Cells[0].Value.ToString();

                showEmployee empl = new showEmployee();
                empl.Show();
            }
        }
    }
}
