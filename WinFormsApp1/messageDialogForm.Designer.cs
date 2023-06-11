namespace CrewConnect
{
    partial class messageDialogForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.titleLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.bodyLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.okBtn = new Guna.UI2.WinForms.Guna2Button();
            this.noBtn = new Guna.UI2.WinForms.Guna2Button();
            this.yesBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.AutoSize = false;
            this.titleLabel.AutoSizeHeightOnly = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Variable Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(63)))));
            this.titleLabel.IsSelectionEnabled = false;
            this.titleLabel.Location = new System.Drawing.Point(12, 74);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(582, 50);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "TITLE";
            this.titleLabel.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.titleLabel.Click += new System.EventHandler(this.titleLabel_Click);
            this.titleLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.titleLabel_KeyDown);
            // 
            // bodyLabel
            // 
            this.bodyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.bodyLabel.AutoSize = false;
            this.bodyLabel.BackColor = System.Drawing.Color.Transparent;
            this.bodyLabel.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bodyLabel.ForeColor = System.Drawing.Color.DimGray;
            this.bodyLabel.IsSelectionEnabled = false;
            this.bodyLabel.Location = new System.Drawing.Point(24, 126);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.bodyLabel.Size = new System.Drawing.Size(553, 196);
            this.bodyLabel.TabIndex = 1;
            this.bodyLabel.Text = "MESSAGE";
            this.bodyLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.bodyLabel.Click += new System.EventHandler(this.bodyLabel_Click);
            this.bodyLabel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bodyLabel_KeyDown);
            // 
            // okBtn
            // 
            this.okBtn.BorderColor = System.Drawing.Color.IndianRed;
            this.okBtn.BorderRadius = 25;
            this.okBtn.BorderThickness = 2;
            this.okBtn.CustomizableEdges = customizableEdges5;
            this.okBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.okBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.okBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.okBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.okBtn.FillColor = System.Drawing.Color.Transparent;
            this.okBtn.Font = new System.Drawing.Font("Segoe UI Variable Display", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.okBtn.ForeColor = System.Drawing.Color.DimGray;
            this.okBtn.Location = new System.Drawing.Point(189, 328);
            this.okBtn.Name = "okBtn";
            this.okBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            this.okBtn.Size = new System.Drawing.Size(225, 56);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // noBtn
            // 
            this.noBtn.BorderColor = System.Drawing.Color.IndianRed;
            this.noBtn.BorderRadius = 25;
            this.noBtn.BorderThickness = 2;
            this.noBtn.CustomizableEdges = customizableEdges3;
            this.noBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.noBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.noBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.noBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.noBtn.FillColor = System.Drawing.Color.Transparent;
            this.noBtn.Font = new System.Drawing.Font("Segoe UI Variable Display", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.noBtn.ForeColor = System.Drawing.Color.DimGray;
            this.noBtn.Location = new System.Drawing.Point(76, 328);
            this.noBtn.Name = "noBtn";
            this.noBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.noBtn.Size = new System.Drawing.Size(225, 56);
            this.noBtn.TabIndex = 3;
            this.noBtn.Text = "NO";
            this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
            // 
            // yesBtn
            // 
            this.yesBtn.BorderColor = System.Drawing.Color.IndianRed;
            this.yesBtn.BorderRadius = 25;
            this.yesBtn.BorderThickness = 2;
            this.yesBtn.CustomizableEdges = customizableEdges1;
            this.yesBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.yesBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.yesBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.yesBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.yesBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.yesBtn.FillColor = System.Drawing.Color.Transparent;
            this.yesBtn.Font = new System.Drawing.Font("Segoe UI Variable Display", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yesBtn.ForeColor = System.Drawing.Color.DimGray;
            this.yesBtn.Location = new System.Drawing.Point(307, 328);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.yesBtn.Size = new System.Drawing.Size(225, 56);
            this.yesBtn.TabIndex = 4;
            this.yesBtn.Text = "YES";
            this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
            // 
            // messageDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 450);
            this.Controls.Add(this.yesBtn);
            this.Controls.Add(this.noBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.bodyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "messageDialogForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "messageDialog";
            this.Load += new System.EventHandler(this.messageDialog_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageDialogForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2HtmlLabel titleLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel bodyLabel;
        private Guna.UI2.WinForms.Guna2Button okBtn;
        private Guna.UI2.WinForms.Guna2Button yesBtn;
        private Guna.UI2.WinForms.Guna2Button noBtn;
    }
}