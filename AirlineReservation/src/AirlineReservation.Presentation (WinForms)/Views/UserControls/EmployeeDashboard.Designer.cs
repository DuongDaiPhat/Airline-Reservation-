using Guna.UI2.WinForms;
using ScottPlot.WinForms;
using System.Drawing;
using System.Windows.Forms;

// alias tránh trùng tên
using Label = System.Windows.Forms.Label;
using Color = System.Drawing.Color;
using Orientation = System.Windows.Forms.Orientation;
using System.Numerics;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.UserControls
{
    partial class EmployeeDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblFlightsToday, lblRemainingFlights, lblCancelledTickets, lblPassengers;
        private Label lblFlightsTodayValue, lblRemainingFlightsValue, lblCancelledTicketsValue, lblPassengersValue;
        private Label lblFlightsTodayDesc, lblRemainingFlightsDesc, lblCancelledTicketsDesc, lblPassengersDesc;
        private Guna2CirclePictureBox iconFlights, iconRemaining, iconCancelled, iconPassengers;
        private Guna2Panel panelChart;
        private ScottPlot.WinForms.FormsPlot chartTicketStats;
        private Label lblChartTitle;
        private Label lblChartSubtitle;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeDashboard));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblFlightsToday = new Label();
            lblFlightsTodayValue = new Label();
            lblFlightsTodayDesc = new Label();
            lblRemainingFlights = new Label();
            lblRemainingFlightsValue = new Label();
            lblRemainingFlightsDesc = new Label();
            lblCancelledTickets = new Label();
            lblCancelledTicketsValue = new Label();
            lblCancelledTicketsDesc = new Label();
            lblPassengers = new Label();
            lblPassengersValue = new Label();
            lblPassengersDesc = new Label();
            iconFlights = new Guna2CirclePictureBox();
            iconRemaining = new Guna2CirclePictureBox();
            iconCancelled = new Guna2CirclePictureBox();
            iconPassengers = new Guna2CirclePictureBox();
            panelChart = new Guna2Panel();
            lblChartTitle = new Label();
            lblChartSubtitle = new Label();
            chartTicketStats = new FormsPlot();
            panelHeader = new Guna2Panel();
            Card1 = new Guna2ShadowPanel();
            soChuyenBayHomNay = new Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna2HtmlLabel();
            pictureBox1 = new PictureBox();
            Card4 = new Guna2ShadowPanel();
            guna2HtmlLabel7 = new Guna2HtmlLabel();
            guna2HtmlLabel4 = new Guna2HtmlLabel();
            pictureBox4 = new PictureBox();
            Card3 = new Guna2ShadowPanel();
            guna2HtmlLabel6 = new Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna2HtmlLabel();
            pictureBox2 = new PictureBox();
            Card2 = new Guna2ShadowPanel();
            guna2HtmlLabel5 = new Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna2HtmlLabel();
            pictureBox3 = new PictureBox();
            lblCalCancelledValue = new Label();
            lblCalPassengersValue = new Label();
            lblCalFlightsValue = new Label();
            lblCalCancelled = new Label();
            lblCalPassengers = new Label();
            lblCalFlights = new Label();
            lblCalendarTitle = new Label();
            panelCalendar = new Guna2Panel();
            guna2ShadowPanel2 = new Guna2ShadowPanel();
            guna2HtmlLabel10 = new Guna2HtmlLabel();
            guna2HtmlLabel9 = new Guna2HtmlLabel();
            prevBtn = new Guna2PictureBox();
            nextBtn = new Guna2PictureBox();
            guna2HtmlLabel8 = new Guna2HtmlLabel();
            guna2Button1 = new Guna2Button();
            ((System.ComponentModel.ISupportInitialize)iconFlights).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconRemaining).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconCancelled).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPassengers).BeginInit();
            panelChart.SuspendLayout();
            panelHeader.SuspendLayout();
            Card1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            Card4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            Card3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            Card2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panelCalendar.SuspendLayout();
            guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)prevBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nextBtn).BeginInit();
            SuspendLayout();
            // 
            // lblFlightsToday
            // 
            lblFlightsToday.Location = new Point(0, 0);
            lblFlightsToday.Name = "lblFlightsToday";
            lblFlightsToday.Size = new Size(100, 23);
            lblFlightsToday.TabIndex = 0;
            // 
            // lblFlightsTodayValue
            // 
            lblFlightsTodayValue.Location = new Point(0, 0);
            lblFlightsTodayValue.Name = "lblFlightsTodayValue";
            lblFlightsTodayValue.Size = new Size(100, 23);
            lblFlightsTodayValue.TabIndex = 0;
            // 
            // lblFlightsTodayDesc
            // 
            lblFlightsTodayDesc.Location = new Point(0, 0);
            lblFlightsTodayDesc.Name = "lblFlightsTodayDesc";
            lblFlightsTodayDesc.Size = new Size(100, 23);
            lblFlightsTodayDesc.TabIndex = 0;
            // 
            // lblRemainingFlights
            // 
            lblRemainingFlights.Location = new Point(0, 0);
            lblRemainingFlights.Name = "lblRemainingFlights";
            lblRemainingFlights.Size = new Size(100, 23);
            lblRemainingFlights.TabIndex = 0;
            // 
            // lblRemainingFlightsValue
            // 
            lblRemainingFlightsValue.Location = new Point(0, 0);
            lblRemainingFlightsValue.Name = "lblRemainingFlightsValue";
            lblRemainingFlightsValue.Size = new Size(100, 23);
            lblRemainingFlightsValue.TabIndex = 0;
            // 
            // lblRemainingFlightsDesc
            // 
            lblRemainingFlightsDesc.Location = new Point(0, 0);
            lblRemainingFlightsDesc.Name = "lblRemainingFlightsDesc";
            lblRemainingFlightsDesc.Size = new Size(100, 23);
            lblRemainingFlightsDesc.TabIndex = 0;
            // 
            // lblCancelledTickets
            // 
            lblCancelledTickets.Location = new Point(0, 0);
            lblCancelledTickets.Name = "lblCancelledTickets";
            lblCancelledTickets.Size = new Size(100, 23);
            lblCancelledTickets.TabIndex = 0;
            // 
            // lblCancelledTicketsValue
            // 
            lblCancelledTicketsValue.Location = new Point(0, 0);
            lblCancelledTicketsValue.Name = "lblCancelledTicketsValue";
            lblCancelledTicketsValue.Size = new Size(100, 23);
            lblCancelledTicketsValue.TabIndex = 0;
            // 
            // lblCancelledTicketsDesc
            // 
            lblCancelledTicketsDesc.Location = new Point(0, 0);
            lblCancelledTicketsDesc.Name = "lblCancelledTicketsDesc";
            lblCancelledTicketsDesc.Size = new Size(100, 23);
            lblCancelledTicketsDesc.TabIndex = 0;
            // 
            // lblPassengers
            // 
            lblPassengers.Location = new Point(0, 0);
            lblPassengers.Name = "lblPassengers";
            lblPassengers.Size = new Size(100, 23);
            lblPassengers.TabIndex = 0;
            // 
            // lblPassengersValue
            // 
            lblPassengersValue.Location = new Point(0, 0);
            lblPassengersValue.Name = "lblPassengersValue";
            lblPassengersValue.Size = new Size(100, 23);
            lblPassengersValue.TabIndex = 0;
            // 
            // lblPassengersDesc
            // 
            lblPassengersDesc.Location = new Point(0, 0);
            lblPassengersDesc.Name = "lblPassengersDesc";
            lblPassengersDesc.Size = new Size(100, 23);
            lblPassengersDesc.TabIndex = 0;
            // 
            // iconFlights
            // 
            iconFlights.ImageRotate = 0F;
            iconFlights.Location = new Point(0, 0);
            iconFlights.Name = "iconFlights";
            iconFlights.ShadowDecoration.CustomizableEdges = customizableEdges1;
            iconFlights.Size = new Size(64, 64);
            iconFlights.TabIndex = 0;
            iconFlights.TabStop = false;
            // 
            // iconRemaining
            // 
            iconRemaining.ImageRotate = 0F;
            iconRemaining.Location = new Point(0, 0);
            iconRemaining.Name = "iconRemaining";
            iconRemaining.ShadowDecoration.CustomizableEdges = customizableEdges2;
            iconRemaining.Size = new Size(64, 64);
            iconRemaining.TabIndex = 0;
            iconRemaining.TabStop = false;
            // 
            // iconCancelled
            // 
            iconCancelled.ImageRotate = 0F;
            iconCancelled.Location = new Point(0, 0);
            iconCancelled.Name = "iconCancelled";
            iconCancelled.ShadowDecoration.CustomizableEdges = customizableEdges3;
            iconCancelled.Size = new Size(64, 64);
            iconCancelled.TabIndex = 0;
            iconCancelled.TabStop = false;
            // 
            // iconPassengers
            // 
            iconPassengers.ImageRotate = 0F;
            iconPassengers.Location = new Point(0, 0);
            iconPassengers.Name = "iconPassengers";
            iconPassengers.ShadowDecoration.CustomizableEdges = customizableEdges4;
            iconPassengers.Size = new Size(64, 64);
            iconPassengers.TabIndex = 0;
            iconPassengers.TabStop = false;
            // 
            // panelChart
            // 
            panelChart.BackColor = Color.Transparent;
            panelChart.BorderRadius = 16;
            panelChart.Controls.Add(lblChartTitle);
            panelChart.Controls.Add(lblChartSubtitle);
            panelChart.Controls.Add(chartTicketStats);
            panelChart.CustomizableEdges = customizableEdges5;
            panelChart.FillColor = Color.White;
            panelChart.Location = new Point(33, 194);
            panelChart.Name = "panelChart";
            panelChart.ShadowDecoration.CustomizableEdges = customizableEdges6;
            panelChart.ShadowDecoration.Depth = 8;
            panelChart.ShadowDecoration.Enabled = true;
            panelChart.ShadowDecoration.Shadow = new Padding(0, 2, 6, 6);
            panelChart.Size = new Size(717, 447);
            panelChart.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblChartTitle.Location = new Point(25, 20);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(230, 25);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "Biểu đồ hủy vé theo ngày";
            // 
            // lblChartSubtitle
            // 
            lblChartSubtitle.AutoSize = true;
            lblChartSubtitle.Font = new Font("Segoe UI", 12F);
            lblChartSubtitle.ForeColor = Color.FromArgb(117, 117, 117);
            lblChartSubtitle.Location = new Point(25, 45);
            lblChartSubtitle.Name = "lblChartSubtitle";
            lblChartSubtitle.Size = new Size(122, 21);
            lblChartSubtitle.TabIndex = 1;
            lblChartSubtitle.Text = "7 ngày gần nhất";
            // 
            // chartTicketStats
            // 
            chartTicketStats.DisplayScale = 1F;
            chartTicketStats.Location = new Point(25, 90);
            chartTicketStats.Name = "chartTicketStats";
            chartTicketStats.Size = new Size(648, 286);
            chartTicketStats.TabIndex = 2;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(Card1);
            panelHeader.Controls.Add(Card4);
            panelHeader.Controls.Add(Card3);
            panelHeader.Controls.Add(Card2);
            panelHeader.CustomizableEdges = customizableEdges7;
            panelHeader.FillColor = Color.Transparent;
            panelHeader.Location = new Point(30, 12);
            panelHeader.Name = "panelHeader";
            panelHeader.ShadowDecoration.CustomizableEdges = customizableEdges8;
            panelHeader.Size = new Size(1217, 130);
            panelHeader.TabIndex = 0;
            // 
            // Card1
            // 
            Card1.BackColor = Color.Transparent;
            Card1.Controls.Add(soChuyenBayHomNay);
            Card1.Controls.Add(guna2HtmlLabel1);
            Card1.Controls.Add(pictureBox1);
            Card1.FillColor = Color.White;
            Card1.Location = new Point(3, 0);
            Card1.Name = "Card1";
            Card1.Radius = 13;
            Card1.ShadowColor = Color.DarkGray;
            Card1.Size = new Size(252, 130);
            Card1.TabIndex = 3;
            // 
            // soChuyenBayHomNay
            // 
            soChuyenBayHomNay.BackColor = Color.Transparent;
            soChuyenBayHomNay.Font = new Font("Segoe UI", 20F);
            soChuyenBayHomNay.Location = new Point(22, 39);
            soChuyenBayHomNay.Name = "soChuyenBayHomNay";
            soChuyenBayHomNay.Size = new Size(33, 39);
            soChuyenBayHomNay.TabIndex = 3;
            soChuyenBayHomNay.Text = "20";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = SystemColors.Highlight;
            guna2HtmlLabel1.Location = new Point(22, 11);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(148, 22);
            guna2HtmlLabel1.TabIndex = 2;
            guna2HtmlLabel1.Text = "Chuyến bay hôm nay";
            guna2HtmlLabel1.UseGdiPlusTextRendering = true;
            guna2HtmlLabel1.UseSystemCursors = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.aeroplane;
            pictureBox1.Location = new Point(187, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Card4
            // 
            Card4.BackColor = Color.Transparent;
            Card4.Controls.Add(guna2HtmlLabel7);
            Card4.Controls.Add(guna2HtmlLabel4);
            Card4.Controls.Add(pictureBox4);
            Card4.FillColor = Color.White;
            Card4.Location = new Point(962, 0);
            Card4.Name = "Card4";
            Card4.Radius = 13;
            Card4.RightToLeft = RightToLeft.No;
            Card4.ShadowColor = Color.DarkGray;
            Card4.Size = new Size(252, 130);
            Card4.TabIndex = 2;
            // 
            // guna2HtmlLabel7
            // 
            guna2HtmlLabel7.BackColor = Color.Transparent;
            guna2HtmlLabel7.Font = new Font("Segoe UI", 20F);
            guna2HtmlLabel7.Location = new Point(22, 39);
            guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            guna2HtmlLabel7.Size = new Size(33, 39);
            guna2HtmlLabel7.TabIndex = 4;
            guna2HtmlLabel7.Text = "20";
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel4.ForeColor = SystemColors.Highlight;
            guna2HtmlLabel4.Location = new Point(22, 11);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(122, 22);
            guna2HtmlLabel4.TabIndex = 3;
            guna2HtmlLabel4.Text = "Tổng khách hàng";
            guna2HtmlLabel4.UseGdiPlusTextRendering = true;
            guna2HtmlLabel4.UseSystemCursors = true;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.check;
            pictureBox4.Location = new Point(187, 11);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(32, 32);
            pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // Card3
            // 
            Card3.BackColor = Color.Transparent;
            Card3.Controls.Add(guna2HtmlLabel6);
            Card3.Controls.Add(guna2HtmlLabel3);
            Card3.Controls.Add(pictureBox2);
            Card3.FillColor = Color.White;
            Card3.Location = new Point(645, 0);
            Card3.Name = "Card3";
            Card3.Radius = 13;
            Card3.ShadowColor = Color.DarkGray;
            Card3.Size = new Size(252, 130);
            Card3.TabIndex = 1;
            // 
            // guna2HtmlLabel6
            // 
            guna2HtmlLabel6.BackColor = Color.Transparent;
            guna2HtmlLabel6.Font = new Font("Segoe UI", 20F);
            guna2HtmlLabel6.Location = new Point(22, 39);
            guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            guna2HtmlLabel6.Size = new Size(33, 39);
            guna2HtmlLabel6.TabIndex = 4;
            guna2HtmlLabel6.Text = "20";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel3.ForeColor = SystemColors.Highlight;
            guna2HtmlLabel3.Location = new Point(22, 11);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(136, 22);
            guna2HtmlLabel3.TabIndex = 3;
            guna2HtmlLabel3.Text = "Vé đã hủy hôm nay";
            guna2HtmlLabel3.UseGdiPlusTextRendering = true;
            guna2HtmlLabel3.UseSystemCursors = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.spam;
            pictureBox2.Location = new Point(187, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(32, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // Card2
            // 
            Card2.BackColor = Color.Transparent;
            Card2.Controls.Add(guna2HtmlLabel5);
            Card2.Controls.Add(guna2HtmlLabel2);
            Card2.Controls.Add(pictureBox3);
            Card2.FillColor = Color.White;
            Card2.Location = new Point(326, 0);
            Card2.Name = "Card2";
            Card2.Radius = 13;
            Card2.ShadowColor = Color.DarkGray;
            Card2.Size = new Size(252, 130);
            Card2.TabIndex = 1;
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Segoe UI", 20F);
            guna2HtmlLabel5.Location = new Point(22, 39);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(33, 39);
            guna2HtmlLabel5.TabIndex = 4;
            guna2HtmlLabel5.Text = "20";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel2.ForeColor = SystemColors.Highlight;
            guna2HtmlLabel2.Location = new Point(22, 11);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(133, 22);
            guna2HtmlLabel2.TabIndex = 3;
            guna2HtmlLabel2.Text = "Chuyến bay còn lại";
            guna2HtmlLabel2.UseGdiPlusTextRendering = true;
            guna2HtmlLabel2.UseSystemCursors = true;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.wall_clock;
            pictureBox3.Location = new Point(187, 11);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(32, 32);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // lblCalCancelledValue
            // 
            lblCalCancelledValue.AutoSize = true;
            lblCalCancelledValue.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblCalCancelledValue.ForeColor = Color.FromArgb(244, 67, 54);
            lblCalCancelledValue.Location = new Point(320, 67);
            lblCalCancelledValue.Name = "lblCalCancelledValue";
            lblCalCancelledValue.Size = new Size(31, 25);
            lblCalCancelledValue.TabIndex = 8;
            lblCalCancelledValue.Text = "12";
            // 
            // lblCalPassengersValue
            // 
            lblCalPassengersValue.AutoSize = true;
            lblCalPassengersValue.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblCalPassengersValue.ForeColor = Color.FromArgb(76, 175, 80);
            lblCalPassengersValue.Location = new Point(178, 67);
            lblCalPassengersValue.Name = "lblCalPassengersValue";
            lblCalPassengersValue.Size = new Size(52, 25);
            lblCalPassengersValue.TabIndex = 7;
            lblCalPassengersValue.Text = "1847";
            // 
            // lblCalFlightsValue
            // 
            lblCalFlightsValue.AutoSize = true;
            lblCalFlightsValue.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblCalFlightsValue.ForeColor = Color.FromArgb(33, 150, 243);
            lblCalFlightsValue.Location = new Point(35, 67);
            lblCalFlightsValue.Name = "lblCalFlightsValue";
            lblCalFlightsValue.Size = new Size(34, 25);
            lblCalFlightsValue.TabIndex = 6;
            lblCalFlightsValue.Text = "24";
            // 
            // lblCalCancelled
            // 
            lblCalCancelled.AutoSize = true;
            lblCalCancelled.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCalCancelled.ForeColor = Color.DodgerBlue;
            lblCalCancelled.Location = new Point(320, 42);
            lblCalCancelled.Name = "lblCalCancelled";
            lblCalCancelled.Size = new Size(58, 21);
            lblCalCancelled.TabIndex = 5;
            lblCalCancelled.Text = "Vé hủy";
            // 
            // lblCalPassengers
            // 
            lblCalPassengers.AutoSize = true;
            lblCalPassengers.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCalPassengers.ForeColor = Color.DodgerBlue;
            lblCalPassengers.Location = new Point(176, 42);
            lblCalPassengers.Name = "lblCalPassengers";
            lblCalPassengers.Size = new Size(94, 21);
            lblCalPassengers.TabIndex = 4;
            lblCalPassengers.Text = "Hành khách";
            // 
            // lblCalFlights
            // 
            lblCalFlights.AutoSize = true;
            lblCalFlights.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCalFlights.ForeColor = Color.DodgerBlue;
            lblCalFlights.Location = new Point(35, 42);
            lblCalFlights.Name = "lblCalFlights";
            lblCalFlights.Size = new Size(94, 21);
            lblCalFlights.TabIndex = 3;
            lblCalFlights.Text = "Chuyến bay";
            // 
            // lblCalendarTitle
            // 
            lblCalendarTitle.AutoSize = true;
            lblCalendarTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblCalendarTitle.ForeColor = Color.FromArgb(33, 33, 33);
            lblCalendarTitle.Location = new Point(25, 20);
            lblCalendarTitle.Name = "lblCalendarTitle";
            lblCalendarTitle.Size = new Size(217, 25);
            lblCalendarTitle.TabIndex = 0;
            lblCalendarTitle.Text = "Lịch theo dõi hàng ngày";
            // 
            // panelCalendar
            // 
            panelCalendar.BackColor = Color.Transparent;
            panelCalendar.BorderRadius = 16;
            panelCalendar.Controls.Add(guna2ShadowPanel2);
            panelCalendar.Controls.Add(guna2HtmlLabel9);
            panelCalendar.Controls.Add(prevBtn);
            panelCalendar.Controls.Add(nextBtn);
            panelCalendar.Controls.Add(lblCalendarTitle);
            panelCalendar.CustomizableEdges = customizableEdges13;
            panelCalendar.FillColor = Color.White;
            panelCalendar.ForeColor = SystemColors.MenuHighlight;
            panelCalendar.Location = new Point(802, 194);
            panelCalendar.Name = "panelCalendar";
            panelCalendar.ShadowDecoration.CustomizableEdges = customizableEdges14;
            panelCalendar.ShadowDecoration.Depth = 8;
            panelCalendar.ShadowDecoration.Enabled = true;
            panelCalendar.ShadowDecoration.Shadow = new Padding(0, 2, 6, 6);
            panelCalendar.Size = new Size(445, 447);
            panelCalendar.TabIndex = 2;
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(guna2HtmlLabel10);
            guna2ShadowPanel2.Controls.Add(lblCalFlights);
            guna2ShadowPanel2.Controls.Add(lblCalCancelledValue);
            guna2ShadowPanel2.Controls.Add(lblCalPassengersValue);
            guna2ShadowPanel2.Controls.Add(lblCalFlightsValue);
            guna2ShadowPanel2.Controls.Add(lblCalCancelled);
            guna2ShadowPanel2.Controls.Add(lblCalPassengers);
            guna2ShadowPanel2.FillColor = Color.Snow;
            guna2ShadowPanel2.Location = new Point(25, 347);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 10;
            guna2ShadowPanel2.ShadowColor = Color.Black;
            guna2ShadowPanel2.Size = new Size(411, 100);
            guna2ShadowPanel2.TabIndex = 14;
            // 
            // guna2HtmlLabel10
            // 
            guna2HtmlLabel10.BackColor = Color.Transparent;
            guna2HtmlLabel10.Location = new Point(35, 12);
            guna2HtmlLabel10.Name = "guna2HtmlLabel10";
            guna2HtmlLabel10.Size = new Size(92, 17);
            guna2HtmlLabel10.TabIndex = 9;
            guna2HtmlLabel10.Text = "Ngày 20/10/2025";
            // 
            // guna2HtmlLabel9
            // 
            guna2HtmlLabel9.BackColor = Color.Transparent;
            guna2HtmlLabel9.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel9.Location = new Point(35, 55);
            guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            guna2HtmlLabel9.Size = new Size(134, 27);
            guna2HtmlLabel9.TabIndex = 13;
            guna2HtmlLabel9.Text = "Tháng 10, 2025";
            // 
            // prevBtn
            // 
            prevBtn.CustomizableEdges = customizableEdges9;
            prevBtn.Image = (Image)resources.GetObject("prevBtn.Image");
            prevBtn.ImageRotate = 0F;
            prevBtn.Location = new Point(310, 21);
            prevBtn.Name = "prevBtn";
            prevBtn.ShadowDecoration.CustomizableEdges = customizableEdges10;
            prevBtn.Size = new Size(24, 24);
            prevBtn.SizeMode = PictureBoxSizeMode.AutoSize;
            prevBtn.TabIndex = 12;
            prevBtn.TabStop = false;
            // 
            // nextBtn
            // 
            nextBtn.CustomizableEdges = customizableEdges11;
            nextBtn.Image = Properties.Resources.next;
            nextBtn.ImageRotate = 0F;
            nextBtn.Location = new Point(385, 21);
            nextBtn.Name = "nextBtn";
            nextBtn.ShadowDecoration.CustomizableEdges = customizableEdges12;
            nextBtn.Size = new Size(24, 24);
            nextBtn.SizeMode = PictureBoxSizeMode.AutoSize;
            nextBtn.TabIndex = 11;
            nextBtn.TabStop = false;
            // 
            // guna2HtmlLabel8
            // 
            guna2HtmlLabel8.BackColor = Color.Transparent;
            guna2HtmlLabel8.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2HtmlLabel8.ForeColor = SystemColors.GrayText;
            guna2HtmlLabel8.Location = new Point(27, 264);
            guna2HtmlLabel8.Name = "guna2HtmlLabel8";
            guna2HtmlLabel8.Size = new Size(113, 32);
            guna2HtmlLabel8.TabIndex = 9;
            guna2HtmlLabel8.Text = "20/10/2025";
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 8;
            guna2Button1.CustomizableEdges = customizableEdges15;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.FillColor = Color.FromArgb(33, 150, 243);
            guna2Button1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(1027, 148);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2Button1.Size = new Size(220, 40);
            guna2Button1.TabIndex = 3;
            guna2Button1.Text = "✈ Danh sách chuyến bay";
            guna2Button1.Click += guna2Button1_Click;
            // 
            // EmployeeDashboard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(250, 250, 250);
            Controls.Add(guna2Button1);
            Controls.Add(panelHeader);
            Controls.Add(panelChart);
            Controls.Add(panelCalendar);
            Name = "EmployeeDashboard";
            Padding = new Padding(30, 20, 30, 30);
            Size = new Size(1280, 650);
            ((System.ComponentModel.ISupportInitialize)iconFlights).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconRemaining).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconCancelled).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPassengers).EndInit();
            panelChart.ResumeLayout(false);
            panelChart.PerformLayout();
            panelHeader.ResumeLayout(false);
            Card1.ResumeLayout(false);
            Card1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            Card4.ResumeLayout(false);
            Card4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            Card3.ResumeLayout(false);
            Card3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            Card2.ResumeLayout(false);
            Card2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panelCalendar.ResumeLayout(false);
            panelCalendar.PerformLayout();
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)prevBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)nextBtn).EndInit();
            ResumeLayout(false);
        }

        private void CreateCard(Guna2Panel card, Label title, Label value, Label desc,
            Guna2CirclePictureBox icon, string titleText, string valueText, string descText,
            Point location, Color textColor, Color bgColor)
        {
            card.Location = location;
            card.Size = new Size(330, 120);
            card.BorderRadius = 16;
            card.FillColor = Color.White;
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Depth = 6;
            card.ShadowDecoration.Shadow = new Padding(0, 2, 4, 4);

            title.Text = titleText;
            title.Font = new Font("Segoe UI", 10F);
            title.ForeColor = Color.FromArgb(117, 117, 117);
            title.Location = new Point(20, 20);
            title.AutoSize = true;

            value.Text = valueText;
            value.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            value.ForeColor = textColor;
            value.Location = new Point(20, 45);
            value.AutoSize = true;

            desc.Text = descText;
            desc.Font = new Font("Segoe UI", 9F);
            desc.ForeColor = Color.FromArgb(158, 158, 158);
            desc.Location = new Point(20, 90);
            desc.AutoSize = true;
            desc.Visible = !string.IsNullOrEmpty(descText);

            icon.Size = new Size(60, 60);
            icon.Location = new Point(250, 30);
            icon.FillColor = bgColor;
            icon.BackColor = Color.Transparent;
            icon.SizeMode = PictureBoxSizeMode.Zoom;

            card.Controls.Add(title);
            card.Controls.Add(value);
            card.Controls.Add(desc);
            card.Controls.Add(icon);
        }
        private Guna2Panel panelHeader;
        private Guna2ShadowPanel Card1;
        private Guna2ShadowPanel Card4;
        private Guna2ShadowPanel Card3;
        private Guna2ShadowPanel Card2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private Guna2HtmlLabel guna2HtmlLabel1;
        private Guna2HtmlLabel guna2HtmlLabel4;
        private Guna2HtmlLabel guna2HtmlLabel3;
        private Guna2HtmlLabel guna2HtmlLabel2;
        private Guna2HtmlLabel soChuyenBayHomNay;
        private Guna2HtmlLabel guna2HtmlLabel7;
        private Guna2HtmlLabel guna2HtmlLabel6;
        private Guna2HtmlLabel guna2HtmlLabel5;
        private Label lblCalCancelledValue;
        private Label lblCalPassengersValue;
        private Label lblCalFlightsValue;
        private Label lblCalCancelled;
        private Label lblCalPassengers;
        private Label lblCalFlights;
        private Label lblCalendarTitle;
        private Guna2Panel panelCalendar;
        private Guna2HtmlLabel guna2HtmlLabel8;
        private Guna2PictureBox nextBtn;
        private Guna2PictureBox prevBtn;
        private Guna2ShadowPanel guna2ShadowPanel2;
        private Guna2HtmlLabel guna2HtmlLabel9;
        private Guna2HtmlLabel guna2HtmlLabel10;
        private Guna2Button guna2Button1;
    }
}