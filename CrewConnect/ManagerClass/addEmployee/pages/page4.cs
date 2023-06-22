using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewConnect.Helper;

namespace CrewConnect.ManagerClass.addEmployee.pages
{
    public partial class page4 : Form
    {
        public static page4 p4;
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
            if (globalVariables.isEdit)
            {
                pageHelper.changePage(new page4(), adminPanel.panel);
                previewInfo1 prev = new previewInfo1();
                if (prev.ShowDialog() == DialogResult.OK)
                {
                    pageHelper.changePage(new page1(), adminPanel.panel);
                }
                return;
            }
            pageHelper.loading(mainsPanel);
            pageHelper.f.Close();
            pageHelper.changePage(new page3(), adminPanel.panel);
        }

        private void page4_Load(object sender, EventArgs e)
        {
            p4 = this;
            validationHelper.comboBoxFirstLoad = true;

            for (int i = 0; i < isValid.Length; i++)
            {
                if(!globalVariables.isEdit)
                    isValid[i] = false;
                else
                    isValid[i] = true;
            }

            String[] contacts =
            {
                "CONTRACTS", "FULLTIME", "PART-TIME"
            };
            contractCB.Items.Clear();
            userInterfaceHelper.comboBoxValue(contractCB, contacts);
            contractCB.SelectedIndex = 0;

            if(globalVariables.isEdit)
            {
                contractCB.SelectedIndex = contractCB.Items.IndexOf(contractCB.SelectedItem);
                bankNameTB.Text = globalVariables.bankName;
                branchTB.Text = globalVariables.branch;
                companyAddTB.Text = globalVariables.companyAdd;
                companyNameTB.Text = globalVariables.accountName;
                accountNumTB.Text = globalVariables.accountNum;
                bsbTB.Text = globalVariables.BSB;
                salaryTB.Text = globalVariables.salary;
            }

            errorProvider1.Clear();
            validationHelper.comboBoxFirstLoad = false;

        }

        private void finishBtn_Click(object sender, EventArgs e)
        {
            pageHelper.loading(mainsPanel);
            previewInfo1 prev = new previewInfo1();
            String[] data = { bankNameTB.Text, branchTB.Text, companyAddTB.Text, companyNameTB.Text,
                bsbTB.Text, accountNumTB.Text, contractCB.Text, salaryTB.Text};


            if (!data.Any(string.IsNullOrWhiteSpace) && !isValid.Contains(false))
            {
                globalVariables.bankName = data[0];
                globalVariables.branch = data[1];
                globalVariables.companyAdd = data[2];
                globalVariables.accountName = data[3];
                globalVariables.BSB = data[4];
                globalVariables.accountNum = data[5];
                globalVariables.contract = data[6];
                globalVariables.salary = data[7];
                if (prev.ShowDialog() == DialogResult.OK)
                {
                    pageHelper.changePage(new page1(), adminPanel.panel);
                }
            }
            else
            {

                validationHelper.textBoxValidation_Alpha(companyNameTB, "Company Name", errorProvider1);
                validationHelper.textBoxValidation_Address(companyAddTB, "Company Address", errorProvider1);
                validationHelper.textBoxValidation_Alpha(branchTB, "Branch", errorProvider1);
                validationHelper.textBoxValidation_Alpha(bankNameTB, "Bank Name", errorProvider1);
                validationHelper.textBoxValidation_Numeric(salaryTB, "Salary", errorProvider1, 2);
                validationHelper.textBoxValidation_Numeric(accountNumTB, "Account Number", errorProvider1, 10);
                validationHelper.textBoxValidation_Numeric(bsbTB, "BSB", errorProvider1, 6);
                validationHelper.comboBoxValidation(contractCB, "CONTRACTS", errorProvider1);
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
            if (validationHelper.textBoxValidation_Address(companyAddTB, "Company Address", errorProvider1))
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
            if (bsbTB.Text.Length < 6)
                return;
            if (validationHelper.textBoxValidation_Numeric(bsbTB, "BSB", errorProvider1, 6))
                isValid[4] = true;
        }

        private void accountNumTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[5] = false;
            if (accountNumTB.Text.Length < 10)
                return;
            if (validationHelper.textBoxValidation_Numeric(accountNumTB, "Account Number", errorProvider1, 10))
                isValid[5] = true;
        }

        private void salaryTB_Validating(object sender, CancelEventArgs e)
        {
            isValid[6] = false;
            if (validationHelper.textBoxValidation_Numeric(salaryTB, "Salary", errorProvider1, 2))
                isValid[6] = true;
        }

        private void contractCB_SelectedValueChanged(object sender, EventArgs e)
        {
            isValid[7] = false;
            if (validationHelper.comboBoxValidation(contractCB, "CONTRACTS", errorProvider1))
                isValid[7] = true;
        }

        private void mainsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public bool isFocus()
        {
            if(bankNameTB.Focused || branchTB.Focused || companyAddTB.Focused || accountNumTB.Focused
                || bsbTB.Focused || companyNameTB.Focused || salaryTB.Focused)
            {
                return true;
            }
            return false;
        }
        private void onKeyEnter(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Space)
            {
                this.Parent.Focus();
            }

            if (e.KeyCode == Keys.Enter)
                finishBtn.PerformClick();
            else if (e.KeyCode == Keys.Escape)
                prevBtn.PerformClick();
        }

        private void bsbTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
