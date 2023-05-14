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

namespace WinFormsApp1.ManagerClass.addEmployee
{
    public partial class previewInfo1 : Form
    {
        public previewInfo1()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void previewInfo1_Load(object sender, EventArgs e)
        {
            page1LoadData();
            page2LoadData();
        }

        void page1LoadData()
        {
            fullNameLabel.Text = $"{globalVariables.lastname.ToUpper()}, " +
                $"{globalVariables.firstname.ToUpper()} {globalVariables.middlename.ToUpper()}";
            addLabel.Text = userInterfaceHelper.limitLabelDisplay(globalVariables.streetAdd, 43);

            if (string.IsNullOrEmpty(globalVariables.streetAdd2))
                add2Label.Text = "NONE";
            else
                add2Label.Text = userInterfaceHelper.limitLabelDisplay(globalVariables.streetAdd2, 42);

            cityLabel.Text = globalVariables.state;
            postalLabel.Text = globalVariables.postal;
            if(globalVariables.permAdd.HasValue)
                permAddCB.Checked = globalVariables.permAdd.Value;
            else
                permAddCB.Checked = false;
        }

        void page2LoadData()
        {
            bdayLabel.Text = $"{globalVariables.month} {globalVariables.day}, {globalVariables.year}".ToUpper();
            ageLabel.Text = globalVariables.age.ToString();
            bloodtypeLabel.Text = globalVariables.bloodType;
            genderLabel.Text = globalVariables.gender;
            nationalityLabel.Text = globalVariables.nationality;
        }

        void page3LoadData()
        {
            
        }
    }
}
