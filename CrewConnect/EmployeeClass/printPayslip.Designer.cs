namespace CrewConnect.EmployeeClass
{
    partial class printPayslip
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.okBtn = new Guna.UI2.WinForms.Guna2Button();
            this.cancelBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.Transparent;
            this.okBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(185)))), ((int)(((byte)(209)))));
            this.okBtn.BorderRadius = 20;
            this.okBtn.BorderThickness = 1;
            this.okBtn.CustomizableEdges = customizableEdges1;
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.okBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.okBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.okBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.okBtn.FillColor = System.Drawing.Color.Transparent;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.okBtn.ForeColor = System.Drawing.Color.White;
            this.okBtn.Location = new System.Drawing.Point(553, 679);
            this.okBtn.Name = "okBtn";
            this.okBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.okBtn.Size = new System.Drawing.Size(246, 39);
            this.okBtn.TabIndex = 46;
            this.okBtn.Text = "PRINT";
            this.okBtn.UseTransparentBackground = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Transparent;
            this.cancelBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(185)))), ((int)(((byte)(209)))));
            this.cancelBtn.BorderRadius = 20;
            this.cancelBtn.BorderThickness = 1;
            this.cancelBtn.CustomizableEdges = customizableEdges3;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cancelBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cancelBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cancelBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cancelBtn.FillColor = System.Drawing.Color.Transparent;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.ForeColor = System.Drawing.Color.White;
            this.cancelBtn.Location = new System.Drawing.Point(301, 679);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.cancelBtn.Size = new System.Drawing.Size(246, 39);
            this.cancelBtn.TabIndex = 45;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseTransparentBackground = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.okBtn);
            this.guna2Panel1.Controls.Add(this.cancelBtn);
            this.guna2Panel1.Controls.Add(this.printPreviewControl1);
            this.guna2Panel1.CustomizableEdges = customizableEdges5;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(30, 30, 30, 70);
            this.guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges6;
            this.guna2Panel1.Size = new System.Drawing.Size(1118, 730);
            this.guna2Panel1.TabIndex = 47;
            this.guna2Panel1.UseTransparentBackground = true;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.AutoZoom = false;
            this.printPreviewControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(113)))), ((int)(((byte)(147)))));
            this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPreviewControl1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.printPreviewControl1.Location = new System.Drawing.Point(30, 30);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(1058, 630);
            this.printPreviewControl1.TabIndex = 0;
            this.printPreviewControl1.TabStop = false;
            this.printPreviewControl1.Zoom = 1D;
            this.printPreviewControl1.Click += new System.EventHandler(this.printPreviewControl1_Click);
            // 
            // printPayslip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(72)))), ((int)(((byte)(93)))));
            this.ClientSize = new System.Drawing.Size(1118, 730);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "printPayslip";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "printPayslip";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.printPayslip_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button okBtn;
        private Guna.UI2.WinForms.Guna2Button cancelBtn;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private PrintPreviewControl printPreviewControl1;
    }
}