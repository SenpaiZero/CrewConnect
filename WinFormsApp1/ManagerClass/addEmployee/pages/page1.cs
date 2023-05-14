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
            pageHelper.changePage(new page2(), managerAddEmployee.panel);
            globalVariables.firstname = firstnameTB.Text;
            globalVariables.middlename = middlenameTB.Text;
            globalVariables.lastname = surnameTB.Text;
            globalVariables.streetAdd = addressTB.Text;
            globalVariables.city = cityTB.Text;
            globalVariables.postal = postalTB.Text;
            globalVariables.state = stateTB.Text;
            globalVariables.permAdd = permAddCheckBox.Checked;

            if (string.IsNullOrEmpty(address2TB.Text))
                globalVariables.streetAdd2 = " ";
            else
                globalVariables.streetAdd2 = address2TB.Text;
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
