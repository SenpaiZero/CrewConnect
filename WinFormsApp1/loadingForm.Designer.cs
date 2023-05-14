namespace WinFormsApp1
{
    partial class loadingForm
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.loading = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // loading
            // 
            this.loading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loading.AutoStart = true;
            this.loading.Location = new System.Drawing.Point(100, 46);
            this.loading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loading.Name = "loading";
            this.loading.ProgressColor = System.Drawing.Color.IndianRed;
            this.loading.ShadowDecoration.CustomizableEdges = customizableEdges1;
            this.loading.Size = new System.Drawing.Size(55, 46);
            this.loading.TabIndex = 1;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Symbol", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(72, 96);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(120, 27);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "PLEASE WAIT";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pleaseWaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 156);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.loading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "pleaseWaitForm";
            this.Text = "pleaseWaitForm";
            this.Load += new System.EventHandler(this.pleaseWaitForm_Load);
            this.Shown += new System.EventHandler(this.pleaseWaitForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator loading;
        private System.Windows.Forms.Timer timer1;
    }
}