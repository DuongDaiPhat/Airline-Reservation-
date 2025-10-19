namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.UserControls.User
{
    partial class uc_FlightPicker
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

        #region Component Designer generated code

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSwap = new Guna.UI2.WinForms.Guna2CircleButton();
            txtTo = new Guna.UI2.WinForms.Guna2TextBox();
            txtFrom = new Guna.UI2.WinForms.Guna2TextBox();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            SuspendLayout();
            // 
            // btnSwap
            // 
            btnSwap.BackColor = Color.Transparent;
            btnSwap.BorderThickness = 1;
            btnSwap.DisabledState.BorderColor = Color.DarkGray;
            btnSwap.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSwap.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSwap.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSwap.FillColor = Color.White;
            btnSwap.Font = new Font("Segoe UI", 9F);
            btnSwap.ForeColor = Color.White;
            btnSwap.Image = Properties.Resources.swap;
            btnSwap.Location = new Point(211, 34);
            btnSwap.Name = "btnSwap";
            btnSwap.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnSwap.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnSwap.Size = new Size(54, 52);
            btnSwap.TabIndex = 11;
            btnSwap.UseTransparentBackground = true;
            // 
            // txtTo
            // 
            txtTo.BorderRadius = 10;
            txtTo.CustomizableEdges = customizableEdges2;
            txtTo.DefaultText = "AA";
            txtTo.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTo.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTo.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTo.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTo.Font = new Font("Segoe UI", 9F);
            txtTo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTo.IconLeft = Properties.Resources.arrival_icon;
            txtTo.IconLeftOffset = new Point(20, 0);
            txtTo.Location = new Point(248, 35);
            txtTo.Margin = new Padding(3, 4, 3, 4);
            txtTo.Name = "txtTo";
            txtTo.PlaceholderText = "";
            txtTo.SelectedText = "";
            txtTo.ShadowDecoration.CustomizableEdges = customizableEdges3;
            txtTo.Size = new Size(239, 51);
            txtTo.TabIndex = 10;
            txtTo.TextOffset = new Point(10, 0);
            // 
            // txtFrom
            // 
            txtFrom.BorderRadius = 10;
            txtFrom.CustomizableEdges = customizableEdges4;
            txtFrom.DefaultText = "AA";
            txtFrom.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFrom.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFrom.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFrom.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFrom.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFrom.Font = new Font("Segoe UI", 9F);
            txtFrom.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFrom.IconLeft = Properties.Resources.take_off_icon;
            txtFrom.IconLeftOffset = new Point(10, 0);
            txtFrom.Location = new Point(3, 35);
            txtFrom.Margin = new Padding(3, 4, 3, 4);
            txtFrom.Name = "txtFrom";
            txtFrom.PlaceholderText = "";
            txtFrom.SelectedText = "";
            txtFrom.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtFrom.Size = new Size(239, 51);
            txtFrom.TabIndex = 9;
            txtFrom.TextOffset = new Point(10, 0);
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.Location = new Point(248, 1);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(37, 27);
            guna2HtmlLabel3.TabIndex = 8;
            guna2HtmlLabel3.Text = "Đến";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.Location = new Point(3, 1);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(24, 27);
            guna2HtmlLabel2.TabIndex = 7;
            guna2HtmlLabel2.Text = "Từ";
            // 
            // guna2Panel1
            // 
            guna2Panel1.CustomizableEdges = customizableEdges6;
            guna2Panel1.Location = new Point(3, 93);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2Panel1.Size = new Size(484, 233);
            guna2Panel1.TabIndex = 12;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // uc_FlightPicker
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(guna2Panel1);
            Controls.Add(btnSwap);
            Controls.Add(txtTo);
            Controls.Add(txtFrom);
            Controls.Add(guna2HtmlLabel3);
            Controls.Add(guna2HtmlLabel2);
            Name = "uc_FlightPicker";
            Size = new Size(492, 329);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleButton btnSwap;
        private Guna.UI2.WinForms.Guna2TextBox txtTo;
        private Guna.UI2.WinForms.Guna2TextBox txtFrom;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
    }
}
