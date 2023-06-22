using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewConnect.EmployeeClass
{
    public partial class printPayslip : Form
    {
        public static printPayslip printPay;
        public printPayslip()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            payslipForm pay = new payslipForm();

            if (pay.printPage())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }

        private void printPayslip_Load(object sender, EventArgs e)
        {
            printPay = this;
            printPreviewControl1.Document = doc;
        }
        public PrintDocument doc { get; set; }
    }
}
