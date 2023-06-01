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
        static bool[] isValid = new bool[8];
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
            String[] data = { firstnameTB.Text, middlenameTB.Text, surnameTB.Text, addressTB.Text,
                            cityTB.Text, postalTB.Text, stateTB.Text};
            // Debugging purposes
            if (globalVariables.isDebuging)
                pageHelper.changePage(new page2(), adminPanel.panel);
            // End of debugging

            if(!isValid.Contains(false))
            {
                globalVariables.firstname = firstnameTB.Text;
                globalVariables.middlename = middlenameTB.Text;
                globalVariables.lastname = surnameTB.Text;
                globalVariables.streetAdd = addressTB.Text;
                globalVariables.city = cityTB.Text;
                globalVariables.postal = postalTB.Text;
                globalVariables.state = stateTB.Text;
                globalVariables.permAdd = permAddCheckBox.Checked;

                if (string.IsNullOrWhiteSpace(address2TB.Text))
                    globalVariables.streetAdd2 = "NONE";
                else
                    globalVariables.streetAdd2 = address2TB.Text;
                pageHelper.changePage(new page2(), adminPanel.panel, 500);
            }
            else 
            {
                pageHelper.loading();

                validationHelper.textBoxValidation_Alpha(surnameTB, "Surname", errorProvider);
                validationHelper.textBoxValidation_Alpha(firstnameTB, "First Name", errorProvider);
                validationHelper.textBoxValidation_Alpha(middlenameTB, "Middle Name", errorProvider);
                validationHelper.textBoxValidation_Address(addressTB, "Address", errorProvider);
                validationHelper.textBoxValidation_Address_optional(address2TB, "Address", errorProvider, true);
                validationHelper.textBoxValidation_Alpha(cityTB, "City", errorProvider);
                validationHelper.textBoxValidation_Alpha(stateTB, "State", errorProvider);
                validationHelper.textBoxValidation_Numeric(postalTB, "Postal", errorProvider);

                pageHelper.errorDetails();
            }
        }

        
        private void surnameTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[0] = false;
            if (validationHelper.textBoxValidation_Alpha(surnameTB, "Surname", errorProvider))
                isValid[0] = true;
        }

        private void firstnameTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[1] = false;
            if (validationHelper.textBoxValidation_Alpha(firstnameTB, "First Name", errorProvider))
                isValid[1] = true;
        }

        private void middlenameTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[2] = false;
            if (validationHelper.textBoxValidation_Alpha(middlenameTB, "Middle Name", errorProvider))
                isValid[2] = true;
        }

        private void addressTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[3] = false;
            if (validationHelper.textBoxValidation_Address(addressTB, "Address", errorProvider))
                isValid[3] = true;
        }

        private void cityTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[4] = false;
            if (validationHelper.textBoxValidation_Alpha(cityTB, "City", errorProvider))
                isValid[4] = true;
        }

        private void stateTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[5] = false;
            if (validationHelper.textBoxValidation_Alpha(stateTB, "State", errorProvider))
                isValid[5] = true;
        }

        private void postalTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[6] = false;
            if (validationHelper.textBoxValidation_Numeric(postalTB, "Postal", errorProvider))
                isValid[6] = true;
        }

        private void page1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < isValid.Length; i++)
            {
                isValid[i] = false;
            }
        }

        private void address2TB_Validating(object sender, CancelEventArgs e)
        {
            isValid[7] = false;
            if (validationHelper.textBoxValidation_Address_optional(address2TB, "Address", errorProvider, true))
                isValid[7] = true;
        }
    }
}
