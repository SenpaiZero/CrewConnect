using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewConnect.Helper;
using System.Runtime.InteropServices;

namespace CrewConnect
{
    public partial class background : Form
    {
        private static loginForm log;
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);
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
            TopMost = true;
            try
            {
                log = new loginForm();
                log.Owner = this;
                if (!log.InvokeRequired)
                    log.ShowDialog();

                base.OnLoad(e);

                // Find the taskbar window and hide it
                int hwndTaskbar = FindWindow("Shell_TrayWnd", "");
                ShowWindow(hwndTaskbar, SW_HIDE);
            }
            catch(Exception ex)
            {
                messageDialogForm msg = new messageDialogForm();
                msg.title = "AN ERROR OCCURED";
                msg.message = ex.Message;
                msg.StartPosition= FormStartPosition.CenterScreen;
                msg.ShowDialog();
            }
            

        }

        private void background_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void background_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            // Show the taskbar again when the form is closed
            int hwndTaskbar = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwndTaskbar, SW_SHOW);
        }

    }
}
