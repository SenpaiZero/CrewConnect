using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewConnect
{
    public partial class loadingForm : Form
    {
        public loadingForm()
        {
            InitializeComponent();
        }
        Stopwatch stopwatch = new Stopwatch();
        public int loadingTime = 1000; 
        private void pleaseWaitForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();

            stopwatch.Start();
        }

        private void pleaseWaitForm_Shown(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds > loadingTime) 
            {
                timer1.Stop();
                stopwatch.Stop();

                this.Close();
                
            }
        }
    }
}
