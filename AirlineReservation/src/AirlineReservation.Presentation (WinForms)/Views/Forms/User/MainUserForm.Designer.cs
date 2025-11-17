namespace AirlineReservation.Presentation__WinForms_.Views.Forms.User
{
    partial class MainUserForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            userFormPanelHeader = new Guna.UI2.WinForms.Guna2Panel();
            userFormPanelContent = new Guna.UI2.WinForms.Guna2Panel();
            UserFormFlowLayoutPanel = new FlowLayoutPanel();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            userFormPanelContent.SuspendLayout();
            SuspendLayout();
            // 
            // userFormPanelHeader
            // 
            userFormPanelHeader.CustomizableEdges = customizableEdges1;
            userFormPanelHeader.Dock = DockStyle.Top;
            userFormPanelHeader.Location = new Point(0, 0);
            userFormPanelHeader.Name = "userFormPanelHeader";
            userFormPanelHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            userFormPanelHeader.Size = new Size(1262, 73);
            userFormPanelHeader.TabIndex = 0;
            // 
            // userFormPanelContent
            // 
            userFormPanelContent.Controls.Add(UserFormFlowLayoutPanel);
            userFormPanelContent.CustomizableEdges = customizableEdges3;
            userFormPanelContent.Dock = DockStyle.Fill;
            userFormPanelContent.Location = new Point(0, 73);
            userFormPanelContent.Name = "userFormPanelContent";
            userFormPanelContent.ShadowDecoration.CustomizableEdges = customizableEdges4;
            userFormPanelContent.Size = new Size(1262, 680);
            userFormPanelContent.TabIndex = 1;
            // 
            // UserFormFlowLayoutPanel
            // 
            UserFormFlowLayoutPanel.Dock = DockStyle.Fill;
            UserFormFlowLayoutPanel.Location = new Point(0, 0);
            UserFormFlowLayoutPanel.Name = "UserFormFlowLayoutPanel";
            UserFormFlowLayoutPanel.Size = new Size(1262, 680);
            UserFormFlowLayoutPanel.TabIndex = 0;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // MainUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 753);
            Controls.Add(userFormPanelContent);
            Controls.Add(userFormPanelHeader);
            Name = "MainUserForm";
            Text = "MainUserForm";
            userFormPanelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel userFormPanelHeader;
        private Guna.UI2.WinForms.Guna2Panel userFormPanelContent;
        private FlowLayoutPanel UserFormFlowLayoutPanel;
        private AirlineReservation.Presentation__WinForms_.Views.UserControls.User.uc_UserFormHeader userFormHeader1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private AirlineReservation.Presentation__WinForms_.Views.UserControls.User.uc_SearchingForm bookingForm1;
    }
}