namespace WinFormsApp1.ManagerClass.addEmployee.pages
{
    partial class page1
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.mainsPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // mainsPanel
            // 
            this.mainsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainsPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainsPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(72)))), ((int)(((byte)(93)))));
            this.mainsPanel.BorderRadius = 20;
            this.mainsPanel.CustomizableEdges = customizableEdges1;
            this.mainsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainsPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(72)))), ((int)(((byte)(93)))));
            this.mainsPanel.Location = new System.Drawing.Point(0, 0);
            this.mainsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainsPanel.Name = "mainsPanel";
            this.mainsPanel.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.mainsPanel.Size = new System.Drawing.Size(933, 652);
            this.mainsPanel.TabIndex = 5;
            this.mainsPanel.UseTransparentBackground = true;
            // 
            // page1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 652);
            this.Controls.Add(this.mainsPanel);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "page1";
            this.Text = "page1";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel mainsPanel;
    }
}