namespace WinFormsApp1.ManagerClass.addEmployee
{
    partial class capturePicture
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.selfPic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.captureBtn = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.camListCB = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cancelBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.selfPic)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimationInterval = 150;
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.guna2BorderlessForm1.BorderRadius = 50;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.DragForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // selfPic
            // 
            this.selfPic.BorderRadius = 25;
            customizableEdges7.BottomLeft = false;
            customizableEdges7.BottomRight = false;
            this.selfPic.CustomizableEdges = customizableEdges7;
            this.selfPic.ImageFlip = Guna.UI2.WinForms.Enums.FlipOrientation.Horizontal;
            this.selfPic.ImageRotate = 0F;
            this.selfPic.Location = new System.Drawing.Point(195, 86);
            this.selfPic.Name = "selfPic";
            this.selfPic.ShadowDecoration.CustomizableEdges = customizableEdges8;
            this.selfPic.Size = new System.Drawing.Size(400, 400);
            this.selfPic.TabIndex = 0;
            this.selfPic.TabStop = false;
            // 
            // captureBtn
            // 
            this.captureBtn.BorderRadius = 25;
            customizableEdges5.TopLeft = false;
            customizableEdges5.TopRight = false;
            this.captureBtn.CustomizableEdges = customizableEdges5;
            this.captureBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.captureBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.captureBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.captureBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.captureBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.captureBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(94)))), ((int)(((byte)(121)))));
            this.captureBtn.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.captureBtn.ForeColor = System.Drawing.Color.White;
            this.captureBtn.Location = new System.Drawing.Point(288, 544);
            this.captureBtn.Name = "captureBtn";
            this.captureBtn.ShadowDecoration.CustomizableEdges = customizableEdges6;
            this.captureBtn.Size = new System.Drawing.Size(225, 56);
            this.captureBtn.TabIndex = 2;
            this.captureBtn.Text = "CAPTURE";
            this.captureBtn.Click += new System.EventHandler(this.captureBtn_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Variable Display", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(255, -2);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(272, 82);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "CAPTURE";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // camListCB
            // 
            this.camListCB.BackColor = System.Drawing.Color.Transparent;
            this.camListCB.BorderRadius = 25;
            customizableEdges3.TopLeft = false;
            customizableEdges3.TopRight = false;
            this.camListCB.CustomizableEdges = customizableEdges3;
            this.camListCB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.camListCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.camListCB.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.camListCB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.camListCB.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.camListCB.ForeColor = System.Drawing.Color.Gray;
            this.camListCB.ItemHeight = 40;
            this.camListCB.Location = new System.Drawing.Point(195, 492);
            this.camListCB.Name = "camListCB";
            this.camListCB.ShadowDecoration.CustomizableEdges = customizableEdges4;
            this.camListCB.Size = new System.Drawing.Size(400, 46);
            this.camListCB.TabIndex = 48;
            this.camListCB.SelectedIndexChanged += new System.EventHandler(this.camListCB_SelectedIndexChanged);
            // 
            // cancelBtn
            // 
            this.cancelBtn.CustomizableEdges = customizableEdges1;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cancelBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cancelBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cancelBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cancelBtn.FillColor = System.Drawing.Color.Transparent;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.ForeColor = System.Drawing.Color.Coral;
            this.cancelBtn.Location = new System.Drawing.Point(348, 606);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            this.cancelBtn.Size = new System.Drawing.Size(112, 26);
            this.cancelBtn.TabIndex = 49;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // capturePicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(78)))));
            this.ClientSize = new System.Drawing.Size(796, 641);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.camListCB);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.captureBtn);
            this.Controls.Add(this.selfPic);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "capturePicture";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "capturePicture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.capturePicture_FormClosing);
            this.Load += new System.EventHandler(this.capturePicture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selfPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button captureBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button cancelBtn;
        private Guna.UI2.WinForms.Guna2ComboBox camListCB;
        private Guna.UI2.WinForms.Guna2PictureBox selfPic;
    }
}