using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Helper;

namespace WinFormsApp1.ManagerClass.addEmployee.pages
{
    public partial class page1 : Form
    {
        public page1()
        {
            InitializeComponent();
            
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
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
        private void nextBtn_Click(object sender, EventArgs e)
        {
            String[] data = { firstnameTB.Text, middlenameTB.Text, surnameTB.Text, 
                addressTB.Text, cityTB.Text, postalTB.Text, stateTB.Text};

            // Debugging purposes
            if (globalVariables.isDebuging)
                pageHelper.changePage(new page2(), managerAddEmployee.panel);
            else
            // End of debugging

            if (data.Any(string.IsNullOrWhiteSpace))
            {
                MessageBox.Show("Incomplete data");
            }
            else
            {
                pageHelper.changePage(new page2(), managerAddEmployee.panel);
                globalVariables.firstname = data[0];
                globalVariables.middlename = data[1];
                globalVariables.lastname = data[2];
                globalVariables.streetAdd = data[3];
                globalVariables.city = data[4];
                globalVariables.postal = data[5];
                globalVariables.state = data[6];
                globalVariables.permAdd = permAddCheckBox.Checked;

                if (string.IsNullOrWhiteSpace(address2TB.Text))
                    globalVariables.streetAdd2 = " ";
                else
                    globalVariables.streetAdd2 = address2TB.Text;
            }
        }

        private void surnameTB_Validating(object sender, CancelEventArgs e)
        {
            //Checks if its empty
            if (userInterfaceHelper.checkFieldBlank(surnameTB.Text))
                errorProvider.SetError(surnameTB, "Please don't leave a blank message");

            // Checks if its alpha only
            else if (!userInterfaceHelper.checkFieldAlpha(surnameTB.Text))
                errorProvider.SetError(surnameTB, "Symbols and numbers are not allowed");

            // Clears the error
            else
                errorProvider.SetError(surnameTB, null);
        }

        private void firstnameTB_Validating(object sender, CancelEventArgs e)
        {
            //Checks if its empty
            if (userInterfaceHelper.checkFieldBlank(firstnameTB.Text))
                errorProvider.SetError(firstnameTB, "Please don't leave a blank message");

            // Checks if its alpha only
            else if (!userInterfaceHelper.checkFieldAlpha(firstnameTB.Text))
                errorProvider.SetError(firstnameTB, "Symbols and numbers are not allowed");

            // Clears the error
            else
                errorProvider.SetError(firstnameTB, null);
        }

        private void middlenameTB_Validating(object sender, CancelEventArgs e)
        {
            //Checks if its empty
            if (userInterfaceHelper.checkFieldBlank(middlenameTB.Text))
                errorProvider.SetError(middlenameTB, "Please don't leave a blank message");

            // Checks if its alpha only
            else if (!userInterfaceHelper.checkFieldAlpha(middlenameTB.Text))
                errorProvider.SetError(middlenameTB, "Symbols and numbers are not allowed");

            // Clears the error
            else
                errorProvider.SetError(middlenameTB, null);
        }

        private void addressTB_Validating(object sender, CancelEventArgs e)
        {
            //Checks if its empty
            if (userInterfaceHelper.checkFieldBlank(addressTB.Text))
                errorProvider.SetError(addressTB, "Please don't leave a blank message");

            // Checks if its alphanumeric only
            else if (!userInterfaceHelper.checkFieldAlphaNumeric(addressTB.Text))
                errorProvider.SetError(addressTB, "Only alphanumeric are allowed");

            // Clears the error
            else
                errorProvider.SetError(addressTB, null);
        }

        private void cityTB_Validating(object sender, CancelEventArgs e)
        {
            //Checks if its empty
            if (userInterfaceHelper.checkFieldBlank(cityTB.Text))
                errorProvider.SetError(cityTB, "Please don't leave a blank message");

            // Checks if its alpha only
            else if (!userInterfaceHelper.checkFieldAlpha(cityTB.Text))
                errorProvider.SetError(cityTB, "Symbols and numbers are not allowed");

            // Clears the error
            else
                errorProvider.SetError(cityTB, null);
        }

        private void stateTB_Validating(object sender, CancelEventArgs e)
        {
            //Checks if its empty
            if (userInterfaceHelper.checkFieldBlank(stateTB.Text))
                errorProvider.SetError(stateTB, "Please don't leave a blank message");

            // Checks if its alpha only
            else if (!userInterfaceHelper.checkFieldAlpha(stateTB.Text))
                errorProvider.SetError(stateTB, "Symbols and numbers are not allowed");

            // Clears the error
            else
                errorProvider.SetError(stateTB, null);
        }

        private void postalTB_Validating(object sender, CancelEventArgs e)
        {
            //Checks if its empty
            if (userInterfaceHelper.checkFieldBlank(postalTB.Text))
                errorProvider.SetError(postalTB, "Please don't leave a blank message");

            // Checks if its numeric only
            else if (!userInterfaceHelper.checkFieldNumeric(postalTB.Text))
                errorProvider.SetError(postalTB, "Only numbers are allowed");
            // Clears the error
            else
                errorProvider.SetError(postalTB, null);
        }
    }
}
