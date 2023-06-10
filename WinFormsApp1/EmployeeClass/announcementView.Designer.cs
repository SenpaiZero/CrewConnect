namespace WinFormsApp1.EmployeeClass
{
    partial class announcementView
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2vScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            this.mainPanel = new System.Windows.Forms.FlowLayoutPanel();
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
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI Variable Display", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(242, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(410, 65);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "ANNOUNCEMENT";
            // 
            // guna2vScrollBar1
            // 
            this.guna2vScrollBar1.AutoScroll = true;
            this.guna2vScrollBar1.BindingContainer = this.mainPanel;
            this.guna2vScrollBar1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(115)))), ((int)(((byte)(150)))));
            this.guna2vScrollBar1.InUpdate = false;
            this.guna2vScrollBar1.LargeChange = 10;
            this.guna2vScrollBar1.Location = new System.Drawing.Point(795, 97);
            this.guna2vScrollBar1.Name = "guna2vScrollBar1";
            this.guna2vScrollBar1.ScrollbarSize = 21;
            this.guna2vScrollBar1.Size = new System.Drawing.Size(21, 477);
            this.guna2vScrollBar1.TabIndex = 0;
            this.guna2vScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(95)))), ((int)(((byte)(122)))));
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(102)))), ((int)(((byte)(133)))));
            this.mainPanel.Location = new System.Drawing.Point(75, 97);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(741, 477);
            this.mainPanel.TabIndex = 0;
            // 
            // announcementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(72)))), ((int)(((byte)(93)))));
            this.ClientSize = new System.Drawing.Size(885, 645);
            this.Controls.Add(this.guna2vScrollBar1);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "announcementView";
            this.Text = "announcementView";
            this.Load += new System.EventHandler(this.announcementView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2vScrollBar1;
        private FlowLayoutPanel mainPanel;
    }
}