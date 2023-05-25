using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Helper;

namespace WinFormsApp1.ManagerClass.addEmployee.pages
{
    public partial class page4 : Form
    {
        bool[] isValid = new bool[8];
        public page4()
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

        private void prevBtn_Click(object sender, EventArgs e)
        {
            pageHelper.changePage(new page3(), adminPanel.panel);
        }

        private void page4_Load(object sender, EventArgs e)
        {
            validationHelper.comboBoxFirstLoad = true;
            for (int i = 0; i < isValid.Length; i++)
            {
                isValid[i] = false;
            }

            String[] contacts =
            {
                "CONTRACTS", "PERMANENT", "PART-TIME"
            };
            contractCB.Items.Clear();
            userInterfaceHelper.comboBoxValue(contractCB, contacts);

            validationHelper.comboBoxFirstLoad = false;

        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            pageHelper.loading();
            previewInfo1 prev = new previewInfo1();
            String[] data = { bankNameTB.Text, branchTB.Text, companyAddTB.Text, companyNameTB.Text,
                bsbTB.Text, accountNumTB.Text, contractCB.Text};

            // Debuggin Purposes
            if (globalVariables.isDebuging)
                prev.ShowDialog();
            else
            // End of debugging 

            if (!data.Any(string.IsNullOrWhiteSpace) && !isValid.Contains(false))
            {
                globalVariables.bankName = data[0];
                globalVariables.branch = data[1];
                globalVariables.companyAdd = data[2];
                globalVariables.companyName = data[3];
                globalVariables.BSB = data[4];
                globalVariables.accountNum = data[5];
                globalVariables.contract = data[5];
                prev.ShowDialog();
            }
            else
            {

                validationHelper.textBoxValidation_Alpha(companyNameTB, "Company Name", errorProvider1);
                validationHelper.textBoxValidation_Alpha(companyAddTB, "Company Address", errorProvider1);
                validationHelper.textBoxValidation_Alpha(branchTB, "Branch", errorProvider1);
                validationHelper.textBoxValidation_Alpha(bankNameTB, "Bank Name", errorProvider1);
                validationHelper.textBoxValidation_Numeric(salaryTB, "Salary", errorProvider1);
                validationHelper.textBoxValidation_Numeric(accountNumTB, "Account Number", errorProvider1);
                validationHelper.textBoxValidation_Numeric(bsbTB, "BSB", errorProvider1);
                validationHelper.comboBoxValidation(contractCB, "CONTRACT", errorProvider1);
                pageHelper.errorDetails();
            }

        }

        private void bankNameTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[0] = false;
            if (validationHelper.textBoxValidation_Alpha(bankNameTB, "Bank Name", errorProvider1))
                isValid[0] = true;
        }

        private void branchTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[1] = false;
            if (validationHelper.textBoxValidation_Alpha(branchTB, "Branch", errorProvider1))
                isValid[1] = true;
        }

        private void companyAddTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[2] = false;
            if (validationHelper.textBoxValidation_Alpha(companyAddTB, "Company Address", errorProvider1))
                isValid[2] = true;
        }

        private void companyNameTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[3] = false;
            if (validationHelper.textBoxValidation_Alpha(companyNameTB, "Company Name", errorProvider1))
                isValid[3] = true;
        }

        private void bsbTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[4] = false;
            if (validationHelper.textBoxValidation_Numeric(bsbTB, "BSB", errorProvider1))
                isValid[4] = true;
        }

        private void accountNumTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[5] = false;
            if (validationHelper.textBoxValidation_Numeric(accountNumTB, "Account Number", errorProvider1))
                isValid[5] = true;
        }

        private void salaryTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[6] = false;
            if (validationHelper.textBoxValidation_Numeric(salaryTB, "Salary", errorProvider1))
                isValid[6] = true;
        }

        private void contractCB_SelectedValueChanged(object sender, EventArgs e)
        {
            isValid[7] = false;
            if (validationHelper.comboBoxValidation(contractCB, "CONTRACT", errorProvider1))
                isValid[7] = true;
        }
    }
}
