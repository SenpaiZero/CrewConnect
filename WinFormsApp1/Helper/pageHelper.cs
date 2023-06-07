using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Helper
{
    internal class pageHelper
    {
        public static Form f;
        public void loadForm(object Form, Guna2Panel mainPanel)
        {
            f = Form as Form;
            f.TopLevel = false;
            mainPanel.Controls.Add(f);
            mainPanel.Tag = f;
            f.Show();
        }

        public static void changePage(object Form, Guna2Panel mainPanel)
        {
            pageHelper ph = new pageHelper();
            ph.loadForm(Form, mainPanel);
            f.BringToFront();
        }
        // Change page with loading
        public static void changePage(object Form, Guna2Panel mainPanel, int loadingTime)
        {
            loadingForm load = new loadingForm();
            load.loadingTime = loadingTime;
            load.StartPosition = FormStartPosition.CenterParent;
            load.ShowDialog();

            pageHelper ph = new pageHelper();
            ph.loadForm(Form, mainPanel);
            f.BringToFront();
        }

        public static void loading(Control parentControl)
        {
            loadingForm load = new loadingForm();
            load.loadingTime = 500;
            load.StartPosition = FormStartPosition.Manual;

            Point listTableLocationOnForm = parentControl.Parent.PointToScreen(parentControl.Location);
            int loadingFormX = listTableLocationOnForm.X + (parentControl.Width - load.Width) / 2;
            int loadingFormY = listTableLocationOnForm.Y + (parentControl.Height - load.Height) / 2;
            load.Location = new Point(loadingFormX, loadingFormY);
            load.ShowDialog();
        }

        public static void errorDetails()
        {
            messageDialogForm msg = new messageDialogForm();
            msg.title = "INCOMPLETE DATA";
            msg.message = "Make sure you fill up the incomplete \nfields";
            msg.ShowDialog();
        }
    }
}
