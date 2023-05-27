﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class background : Form
    {
        private loginForm log;
        public background()
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
        private void background_Load(object sender, EventArgs e)
        {
            log = new loginForm();
            log.Owner = this;
            log.ShowDialog();
        }

        private void background_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}