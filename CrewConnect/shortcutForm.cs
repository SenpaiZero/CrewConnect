using CrewConnect.EmployeeClass;
using CrewConnect.Helper;
using CrewConnect.ManagerClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewConnect
{
    public partial class shortcutForm : Form
    {
        public shortcutForm()
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

        private void shortcutForm_Load(object sender, EventArgs e)
        {
            shortcutHelp();
            TopMost = true;
        }

        public void showAsSide(Form form)
        {
            // Retrieve the location of the current form
            Point currentFormLocation = form.Location;

            // Calculate the desired position for the new form
            int newX = currentFormLocation.X + form.Width + 10; // Adjust the offset as needed
            int newY = currentFormLocation.Y;

            // Set the start position and location of the new form
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(newX, newY);
        }

        void shortcutHelp()
        {

            sf = this;
            if (isClose)
                return;

            flowLayoutPanel1.Controls.Clear();
            TableLayoutPanel hotkeyData = new TableLayoutPanel()
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            // Add the TableLayoutPanel to the FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(hotkeyData);

            // Set the column count and other properties of the TableLayoutPanel
            hotkeyData.ColumnCount = 3;
            hotkeyData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            hotkeyData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            hotkeyData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));

            hotkeyData.RowCount = Names.Length + 2;
            // Create header labels
            Label headerName = new Label
            {
                Text = "NAME",
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI Variable Display", 12, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0, 0, 0, 10)
            };

            Label headerCategory = new Label
            {
                Text = "CATEGORY",
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI Variable Display", 12, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0, 0, 0, 10)
            };

            Label headerKeys = new Label
            {
                Text = "KEYS",
                ForeColor = Color.WhiteSmoke,
                Font = new Font("Segoe UI Variable Display", 12, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Anchor = AnchorStyles.None,
                Margin = new Padding(0, 0, 0, 10)
            };

            // Add header labels to the TableLayout
            hotkeyData.Controls.Add(headerName, 0, 0); // Name header, column 0, row 0
            hotkeyData.Controls.Add(headerKeys, 1, 0); // Keys header, column 2, row 0
            hotkeyData.Controls.Add(headerCategory, 2, 0); // Category header, column 1, row 0

            for (int i = 0; i < Names.Length; i++)
            {
                Label labelName = new Label()
                {
                    Text = Names[i],
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Segoe UI Variable Display", 11, FontStyle.Regular),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Anchor = AnchorStyles.None,
                    Margin = new Padding(0, 0, 0, 10)
                };
                Label labelCategory = new Label()
                {
                    Text = Category[i],
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Segoe UI Variable Display", 11, FontStyle.Regular),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Anchor = AnchorStyles.None,
                    Margin = new Padding(0, 0, 0, 10)
                };
                Label labelKeys = new Label()
                {
                    Text = Key[i],
                    ForeColor = Color.WhiteSmoke,
                    Font = new Font("Segoe UI Variable Display", 11, FontStyle.Regular),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Anchor = AnchorStyles.None,
                    Margin = new Padding(0, 0, 0, 10)
                };

                // Add labels to the TableLayout
                hotkeyData.Controls.Add(labelName, 0, i+1); // Name column, row i
                hotkeyData.Controls.Add(labelKeys, 1, i + 1); // Keys column, row i
                hotkeyData.Controls.Add(labelCategory, 2, i+1); // Category column, row i
            }

            hotkeyData.Dock = DockStyle.Fill;
        }

        bool isClose = false;
        public string[] Names { get; set; }
        public string[] Key { get; set; }
        public string[] Category { get; set; }

        public static shortcutForm sf;
        public void closeForm()
        {
            sf.Close();
        }
        private void shortcutForm_Deactivate(object sender, EventArgs e)
        {

        }


        private void shortcutForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (loginForm.shortcut != null) loginForm.shortcut = null;
            if (adminPanel.shortcut != null) adminPanel.shortcut = null;
            if (EmployeePanel.shortcut != null) EmployeePanel.shortcut = null;

            userInterfaceHelper.closeShortcut();
            this.Dispose();
        }
    }
}
