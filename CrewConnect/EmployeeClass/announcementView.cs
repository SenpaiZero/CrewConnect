﻿using AForge.Imaging.Filters;
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

namespace CrewConnect.EmployeeClass
{
    public partial class announcementView : Form
    {
        public announcementView()
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
        private void announcementView_Load(object sender, EventArgs e)
        {
            var loadingForm = new loadingForm();
            loadingForm.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = mainPanel.Parent.PointToScreen(mainPanel.Location);
            int loadingFormX = listTableLocationOnForm.X + (mainPanel.Width - loadingForm.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (mainPanel.Height - loadingForm.Height) / 2;
            loadingForm.Location = new Point(loadingFormX, loadingFormY);

            loadingForm.loadingTime = 1000;
            loadingForm.ShowDialog();

            string query = $"SELECT message, date FROM announcement ORDER BY date DESC";
            using (SqlConnection con = new SqlConnection(globalVariables.server))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    addNewLabel("MESSAGE", "DATE", true);
                    SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            addNewLabel(dr.GetString(0), dr.GetDateTime(1).ToShortDateString(), false);
                        }
                dr.Close();
                }
            }

        }

        int index = 0;
        void addNewLabel(string left, string right, bool isHeader)
        {
            DateTime date = DateTime.Today;
            // Create a new label instance
            Label leftLabel = new Label();
            Label rightLabel = new Label();

            // Set properties for the left-side label
            leftLabel.Text = left;

            if (isHeader)
            {
                leftLabel.Font = new Font("Segoe UI Variable Display Semib", 20, FontStyle.Bold);
                leftLabel.ForeColor = Color.White;
                leftLabel.BackColor = Color.FromArgb(31, 56, 73);
            }
            else
            {
                if (right == date.ToShortDateString())
                {
                    leftLabel.ForeColor = Color.YellowGreen;
                }
                else
                {
                    leftLabel.ForeColor = Color.Gainsboro;
                }
            }

            leftLabel.Font = new Font("Segoe UI Variable Display Semib", 12, FontStyle.Regular);
            leftLabel.AutoSize = true;
            leftLabel.MaximumSize = new Size(500, 0);
            leftLabel.MinimumSize = new Size(500, 0);
            leftLabel.Margin = new Padding(0, 0, 0, 15);
            leftLabel.TextAlign = ContentAlignment.MiddleCenter;
            leftLabel.Padding = new Padding(5);
            if(index == 0)
            {
                leftLabel.BackColor = Color.FromArgb(31, 56, 73);
            }
            else
            {
                leftLabel.BackColor = Color.FromArgb(49, 89, 117);
            }


            // Set properties for the right-side label
            rightLabel.Text = right;
            if (isHeader)
            {
                rightLabel.Font = new Font("Segoe UI Variable Display Semib", 20, FontStyle.Bold);
                rightLabel.ForeColor = Color.White;
                rightLabel.BackColor = Color.FromArgb(31, 56, 73);
            }
            else
            {
                if (right == date.ToShortDateString())
                {
                    rightLabel.ForeColor = Color.YellowGreen;
                }
                else
                {
                    rightLabel.ForeColor = Color.Gainsboro;
                }
            }
            rightLabel.Font = new Font("Segoe UI Variable Display Semib", 12, FontStyle.Regular);
            rightLabel.AutoSize = true;
            rightLabel.Margin = new Padding(0, 0, 0, 15);
            rightLabel.MaximumSize = new Size(220, leftLabel.PreferredHeight);
            rightLabel.MinimumSize = new Size(220, leftLabel.PreferredHeight);
            rightLabel.TextAlign = ContentAlignment.MiddleCenter;
            if (index == 0)
            {
                rightLabel.BackColor = Color.FromArgb(31, 56, 73);
                index = 1;
            }
            else
            {
                index = 0;
                rightLabel.BackColor = Color.FromArgb(49, 89, 117);
            }

            // Add the labels to the panel's Controls collection
            mainPanel.Controls.Add(leftLabel);
            mainPanel.Controls.Add(rightLabel);
        }
    }
}
