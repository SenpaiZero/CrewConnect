﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewConnect
{
    public partial class messageDialogForm : Form
    {
        public messageDialogForm()
        {
            InitializeComponent();
            isOkDialog = false;
            KeyDown += messageDialogForm_KeyDown;
            KeyDown += bodyLabel_KeyDown;
            KeyDown += titleLabel_KeyDown;
        }
        public bool isOkDialog { get; set; }
        public String title { get; set; }
        public String message { get; set; }
        private void messageDialog_Load(object sender, EventArgs e)
        {
            TopMost = true;
            titleLabel.Text = title;
            bodyLabel.Text = message;
            if(isOkDialog == true)
            {
                okBtn.Enabled = false;
                okBtn.Visible= false;

                noBtn.Enabled = true;
                noBtn.Visible= true;
                yesBtn.Enabled = true;
                yesBtn.Visible= true;
                return;
            }
            okBtn.Enabled = true;
            okBtn.Visible = true;
            noBtn.Enabled = false;
            noBtn.Visible = false;
            yesBtn.Enabled = false;
            yesBtn.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void messageDialogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void titleLabel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void bodyLabel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void bodyLabel_Click(object sender, EventArgs e)
        {

        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void noBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
