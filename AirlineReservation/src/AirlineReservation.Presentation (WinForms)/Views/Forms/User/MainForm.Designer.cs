namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.User
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2Panel panelHeader;
        private Guna.UI2.WinForms.Guna2Panel panelContent;
        private Label lblTitle;
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panelHeader = new Guna.UI2.WinForms.Guna2Panel();
            lblTitle = new Label();
            panelContent = new Guna.UI2.WinForms.Guna2Panel();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTitle);
            panelHeader.CustomizableEdges = customizableEdges1;
            panelHeader.FillColor = Color.White;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            panelHeader.ShadowDecoration.Depth = 8;
            panelHeader.ShadowDecoration.Enabled = true;
            panelHeader.Size = new Size(1280, 99);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(224, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Dashboard nhân viên";
            // 
            // panelContent
            // 
            panelContent.CustomizableEdges = customizableEdges3;
            panelContent.FillColor = Color.FromArgb(245, 247, 250);
            panelContent.Location = new Point(0, 105);
            panelContent.Name = "panelContent";
            panelContent.ShadowDecoration.CustomizableEdges = customizableEdges4;
            panelContent.Size = new Size(1280, 654);
            panelContent.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1280, 761);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Airline Reservation System";
            Load += MainForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}