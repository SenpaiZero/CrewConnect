namespace WinFormsApp1.ManagerClass
{
    partial class adminPanel
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.header = new Guna.UI2.WinForms.Guna2Panel();
            this.positionLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.minimiseBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.maximiseBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.exitBtn = new Guna.UI2.WinForms.Guna2CircleButton();
            this.mainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.addBtn = new Guna.UI2.WinForms.Guna2Button();
            this.listBtn = new Guna.UI2.WinForms.Guna2Button();
            this.settingBtn = new Guna.UI2.WinForms.Guna2Button();
            this.announcementBtn = new Guna.UI2.WinForms.Guna2Button();
            this.closeBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.nameLabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.header.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 25;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(38)))), ((int)(((byte)(60)))));
            this.header.Controls.Add(this.positionLabel);
            this.header.Controls.Add(this.minimiseBtn);
            this.header.Controls.Add(this.maximiseBtn);
            this.header.Controls.Add(this.exitBtn);
            this.header.CustomizableEdges = customizableEdges7;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.ShadowDecoration.CustomizableEdges = customizableEdges8;
            this.header.Size = new System.Drawing.Size(1162, 89);
            this.header.TabIndex = 2;
            this.header.Paint += new System.Windows.Forms.PaintEventHandler(this.header_Paint);
            // 
            // positionLabel
            // 
            this.positionLabel.BackColor = System.Drawing.Color.Transparent;
            this.positionLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.positionLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.positionLabel.Location = new System.Drawing.Point(75, 29);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(95, 39);
            this.positionLabel.TabIndex = 11;
            this.positionLabel.Text = "ADMIN";
            // 
            // minimiseBtn
            // 
            this.minimiseBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimiseBtn.BorderColor = System.Drawing.Color.GreenYellow;
            this.minimiseBtn.BorderThickness = 2;
            this.minimiseBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.minimiseBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.minimiseBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.minimiseBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.minimiseBtn.FillColor = System.Drawing.Color.Transparent;
            this.minimiseBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minimiseBtn.ForeColor = System.Drawing.Color.White;
            this.minimiseBtn.Location = new System.Drawing.Point(1078, 12);
            this.minimiseBtn.Name = "minimiseBtn";
            this.minimiseBtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.minimiseBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.minimiseBtn.Size = new System.Drawing.Size(21, 20);
            this.minimiseBtn.TabIndex = 10;
            this.minimiseBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.minimiseBtn.UseTransparentBackground = true;
            // 
            // maximiseBtn
            // 
            this.maximiseBtn.BackColor = System.Drawing.Color.Transparent;
            this.maximiseBtn.BorderColor = System.Drawing.Color.GreenYellow;
            this.maximiseBtn.BorderThickness = 2;
            this.maximiseBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.maximiseBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.maximiseBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.maximiseBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.maximiseBtn.FillColor = System.Drawing.Color.Transparent;
            this.maximiseBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maximiseBtn.ForeColor = System.Drawing.Color.White;
            this.maximiseBtn.Location = new System.Drawing.Point(1104, 12);
            this.maximiseBtn.Name = "maximiseBtn";
            this.maximiseBtn.ShadowDecoration.CustomizableEdges = customizableEdges5;
            this.maximiseBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.maximiseBtn.Size = new System.Drawing.Size(21, 20);
            this.maximiseBtn.TabIndex = 9;
            this.maximiseBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.maximiseBtn.UseTransparentBackground = true;
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.BorderColor = System.Drawing.Color.GreenYellow;
            this.exitBtn.BorderThickness = 2;
            this.exitBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitBtn.FillColor = System.Drawing.Color.Transparent;
            this.exitBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Location = new System.Drawing.Point(1130, 12);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            this.exitBtn.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.exitBtn.Size = new System.Drawing.Size(21, 20);
            this.exitBtn.TabIndex = 8;
            this.exitBtn.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.exitBtn.UseTransparentBackground = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(72)))), ((int)(((byte)(93)))));
            this.mainPanel.BorderRadius = 20;
            this.mainPanel.CustomizableEdges = customizableEdges2;
            this.mainPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(72)))), ((int)(((byte)(93)))));
            this.mainPanel.Location = new System.Drawing.Point(267, 41);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.ShadowDecoration.CustomizableEdges = customizableEdges3;
            this.mainPanel.Size = new System.Drawing.Size(885, 652);
            this.mainPanel.TabIndex = 4;
            this.mainPanel.UseTransparentBackground = true;
            // 
            // addBtn
            // 
            this.addBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addBtn.AutoRoundedCorners = true;
            this.addBtn.BackColor = System.Drawing.Color.Transparent;
            this.addBtn.BorderRadius = 39;
            this.addBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            customizableEdges9.BottomRight = false;
            customizableEdges9.TopRight = false;
            this.addBtn.CustomizableEdges = customizableEdges9;
            this.addBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(72)))), ((int)(((byte)(93)))));
            this.addBtn.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.HoverState.Font = new System.Drawing.Font("Segoe UI Historic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addBtn.Image = global::WinFormsApp1.Properties.Resources.add;
            this.addBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.addBtn.ImageOffset = new System.Drawing.Point(10, 0);
            this.addBtn.ImageSize = new System.Drawing.Size(32, 32);
            this.addBtn.Location = new System.Drawing.Point(11, 117);
            this.addBtn.Name = "addBtn";
            this.addBtn.ShadowDecoration.CustomizableEdges = customizableEdges10;
            this.addBtn.Size = new System.Drawing.Size(261, 81);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "ADD EMPLOYEE";
            this.addBtn.TextOffset = new System.Drawing.Point(15, 0);
            this.addBtn.UseTransparentBackground = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // listBtn
            // 
            this.listBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.listBtn.AutoRoundedCorners = true;
            this.listBtn.BackColor = System.Drawing.Color.Transparent;
            this.listBtn.BorderRadius = 39;
            this.listBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            customizableEdges11.BottomRight = false;
            customizableEdges11.TopRight = false;
            this.listBtn.CustomizableEdges = customizableEdges11;
            this.listBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.listBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.listBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.listBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.listBtn.FillColor = System.Drawing.Color.Transparent;
            this.listBtn.Font = new System.Drawing.Font("Segoe UI Historic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listBtn.ForeColor = System.Drawing.Color.White;
            this.listBtn.HoverState.Font = new System.Drawing.Font("Segoe UI Historic", 11.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listBtn.Image = global::WinFormsApp1.Properties.Resources.remove;
            this.listBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.listBtn.ImageOffset = new System.Drawing.Point(10, 0);
            this.listBtn.ImageSize = new System.Drawing.Size(32, 32);
            this.listBtn.Location = new System.Drawing.Point(11, 223);
            this.listBtn.Name = "listBtn";
            this.listBtn.ShadowDecoration.CustomizableEdges = customizableEdges12;
            this.listBtn.Size = new System.Drawing.Size(261, 81);
            this.listBtn.TabIndex = 6;
            this.listBtn.Text = "LIST EMPLOYEE";
            this.listBtn.TextOffset = new System.Drawing.Point(15, 0);
            this.listBtn.UseTransparentBackground = true;
            this.listBtn.Click += new System.EventHandler(this.rmvBtn_Click);
            // 
            // settingBtn
            // 
            this.settingBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.settingBtn.AutoRoundedCorners = true;
            this.settingBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingBtn.BorderRadius = 39;
            this.settingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            customizableEdges13.BottomRight = false;
            customizableEdges13.TopRight = false;
            this.settingBtn.CustomizableEdges = customizableEdges13;
            this.settingBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.settingBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.settingBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.settingBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.settingBtn.FillColor = System.Drawing.Color.Transparent;
            this.settingBtn.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.settingBtn.ForeColor = System.Drawing.Color.White;
            this.settingBtn.HoverState.Font = new System.Drawing.Font("Segoe UI Historic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.settingBtn.Image = global::WinFormsApp1.Properties.Resources.quote_request;
            this.settingBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.settingBtn.ImageOffset = new System.Drawing.Point(10, 0);
            this.settingBtn.ImageSize = new System.Drawing.Size(32, 32);
            this.settingBtn.Location = new System.Drawing.Point(11, 323);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.ShadowDecoration.CustomizableEdges = customizableEdges14;
            this.settingBtn.Size = new System.Drawing.Size(261, 81);
            this.settingBtn.TabIndex = 7;
            this.settingBtn.Text = "SETTINGS";
            this.settingBtn.UseTransparentBackground = true;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // announcementBtn
            // 
            this.announcementBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.announcementBtn.AutoRoundedCorners = true;
            this.announcementBtn.BackColor = System.Drawing.Color.Transparent;
            this.announcementBtn.BorderRadius = 39;
            this.announcementBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            customizableEdges15.BottomRight = false;
            customizableEdges15.TopRight = false;
            this.announcementBtn.CustomizableEdges = customizableEdges15;
            this.announcementBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.announcementBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.announcementBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.announcementBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.announcementBtn.FillColor = System.Drawing.Color.Transparent;
            this.announcementBtn.Font = new System.Drawing.Font("Segoe UI Historic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.announcementBtn.ForeColor = System.Drawing.Color.White;
            this.announcementBtn.HoverState.Font = new System.Drawing.Font("Segoe UI Historic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.announcementBtn.Image = global::WinFormsApp1.Properties.Resources.megaphone;
            this.announcementBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.announcementBtn.ImageOffset = new System.Drawing.Point(10, 0);
            this.announcementBtn.ImageSize = new System.Drawing.Size(32, 32);
            this.announcementBtn.Location = new System.Drawing.Point(11, 410);
            this.announcementBtn.Name = "announcementBtn";
            this.announcementBtn.ShadowDecoration.CustomizableEdges = customizableEdges16;
            this.announcementBtn.Size = new System.Drawing.Size(261, 81);
            this.announcementBtn.TabIndex = 9;
            this.announcementBtn.Text = "ANNOUNCEMENT";
            this.announcementBtn.TextOffset = new System.Drawing.Point(15, 0);
            this.announcementBtn.UseTransparentBackground = true;
            this.announcementBtn.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.closeBtn.HoverState.ImageSize = new System.Drawing.Size(35, 35);
            this.closeBtn.Image = global::WinFormsApp1.Properties.Resources.exit;
            this.closeBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.closeBtn.ImageRotate = 0F;
            this.closeBtn.ImageSize = new System.Drawing.Size(25, 25);
            this.closeBtn.Location = new System.Drawing.Point(11, 646);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.closeBtn.ShadowDecoration.CustomizableEdges = customizableEdges1;
            this.closeBtn.Size = new System.Drawing.Size(49, 46);
            this.closeBtn.TabIndex = 10;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = false;
            this.nameLabel.AutoSizeHeightOnly = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.nameLabel.Location = new System.Drawing.Point(55, 646);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(209, 26);
            this.nameLabel.TabIndex = 12;
            this.nameLabel.Text = "Santos, Ygi Martin";
            this.nameLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Variable Display", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Salmon;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(126, 671);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(61, 22);
            this.guna2HtmlLabel2.TabIndex = 13;
            this.guna2HtmlLabel2.Text = "LOGOUT";
            this.guna2HtmlLabel2.Click += new System.EventHandler(this.guna2HtmlLabel2_Click);
            this.guna2HtmlLabel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2HtmlLabel2_MouseDown);
            // 
            // adminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.ClientSize = new System.Drawing.Size(1162, 701);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.header);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.listBtn);
            this.Controls.Add(this.settingBtn);
            this.Controls.Add(this.announcementBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "adminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "managerAddEmployee";
            this.Load += new System.EventHandler(this.managerAddEmployee_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.adminPanel_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.adminPanel_MouseUp);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel header;
        private Guna.UI2.WinForms.Guna2Button addBtn;
        private Guna.UI2.WinForms.Guna2Button announcementBtn;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button settingBtn;
        private Guna.UI2.WinForms.Guna2Button listBtn;
        private Guna.UI2.WinForms.Guna2CircleButton minimiseBtn;
        private Guna.UI2.WinForms.Guna2CircleButton maximiseBtn;
        private Guna.UI2.WinForms.Guna2CircleButton exitBtn;
        private Guna.UI2.WinForms.Guna2ImageButton closeBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel positionLabel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel nameLabel;
        private Guna.UI2.WinForms.Guna2Panel mainPanel;
    }
}