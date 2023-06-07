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

        }

        void loadPrevious()
        {

        }
    }
}
