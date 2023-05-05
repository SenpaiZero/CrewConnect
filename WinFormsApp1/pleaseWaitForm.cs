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

namespace WinFormsApp1
{
    public partial class pleaseWaitForm : Form
    {
        public pleaseWaitForm()
        {
            InitializeComponent();
        }
        public static bool isDone = false;
        Stopwatch stopwatch = new Stopwatch();
        private void pleaseWaitForm_Load(object sender, EventArgs e)
        {
            timer1.Interval = 500;
            timer1.Start();
            isDone = true;

            stopwatch.Start();
        }

        private void pleaseWaitForm_Shown(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stopwatch.ElapsedMilliseconds > 1000) 
            {
                bool isConditionMet = true;

                if (isConditionMet)
                {
                    // Stop the timer and perform any actions you need to do
                    timer1.Stop();
                    stopwatch.Stop();
                    isDone = false;

                    this.Close();
                }
            }
        }
    }
}
