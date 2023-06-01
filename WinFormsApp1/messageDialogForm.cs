using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class messageDialogForm : Form
    {
        public messageDialogForm()
        {
            InitializeComponent();
            KeyDown += messageDialogForm_KeyDown;
            KeyDown += bodyLabel_KeyDown;
            KeyDown += titleLabel_KeyDown;
        }
        public String title { get; set; }
        public String message { get; set; }
        private void messageDialog_Load(object sender, EventArgs e)
        {
            titleLabel.Text = title;
            bodyLabel.Text = message;
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
    }
}
