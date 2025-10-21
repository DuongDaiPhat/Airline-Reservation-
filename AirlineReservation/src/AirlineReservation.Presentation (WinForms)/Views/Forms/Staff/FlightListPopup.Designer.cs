namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.Staff
{
    partial class FlightListPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblTitle = new Label();
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            guna2vScrollBar1 = new Guna.UI2.WinForms.Guna2VScrollBar();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            guna2ShadowPanel2.SuspendLayout();
            guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.BorderRadius = 8;
            btnClose.Cursor = Cursors.Hand;
            btnClose.CustomizableEdges = customizableEdges7;
            btnClose.FillColor = Color.Transparent;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnClose.ForeColor = Color.Gray;
            btnClose.Location = new Point(922, 9);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnClose.Size = new Size(37, 26);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 150, 243);
            lblTitle.Location = new Point(40, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(193, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Danh sách chuyến bay";
            lblTitle.Click += lblTitle_Click;
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(lblTitle);
            guna2ShadowPanel2.FillColor = Color.White;
            guna2ShadowPanel2.Location = new Point(91, 25);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.ShadowColor = Color.DarkGray;
            guna2ShadowPanel2.Size = new Size(274, 52);
            guna2ShadowPanel2.TabIndex = 5;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            guna2Elipse1.TargetControl = this;
            // 
            // guna2GradientPanel1
            // 
            guna2GradientPanel1.AutoScroll = true;
            guna2GradientPanel1.Controls.Add(guna2vScrollBar1);
            guna2GradientPanel1.CustomizableEdges = customizableEdges11;
            guna2GradientPanel1.Location = new Point(9, 83);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2GradientPanel1.Size = new Size(454, 558);
            guna2GradientPanel1.TabIndex = 6;
            // 
            // guna2vScrollBar1
            // 
            guna2vScrollBar1.InUpdate = false;
            guna2vScrollBar1.LargeChange = 10;
            guna2vScrollBar1.Location = new Point(441, 0);
            guna2vScrollBar1.Name = "guna2vScrollBar1";
            guna2vScrollBar1.ScrollbarSize = 10;
            guna2vScrollBar1.Size = new Size(10, 558);
            guna2vScrollBar1.TabIndex = 7;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.CustomizableEdges = customizableEdges9;
            guna2PictureBox1.Image = Properties.Resources.reject;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(428, 9);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges10;
            guna2PictureBox1.Size = new Size(32, 32);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            guna2PictureBox1.TabIndex = 7;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.Click += BtnClose_Click;
            // 
            // FlightListPopup
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(472, 650);
            Controls.Add(guna2PictureBox1);
            Controls.Add(guna2GradientPanel1);
            Controls.Add(guna2ShadowPanel2);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FlightListPopup";
            Padding = new Padding(6);
            StartPosition = FormStartPosition.Manual;
            Text = "FlightListPopup";
            TopMost = true;
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2VScrollBar guna2vScrollBar1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}