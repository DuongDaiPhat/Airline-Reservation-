using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.Staff;
using Guna.UI2.WinForms;
using ScottPlot;
using ScottPlot.WinForms;

// alias tránh xung đột
using Color = System.Drawing.Color;
using Label = System.Windows.Forms.Label;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.UserControls
{
    public partial class EmployeeDashboard : UserControl
    {
        // ==== Lịch ====
        private FlowLayoutPanel flowDays;
        private DateTime currentMonth;
        private readonly List<Guna2Button> dayButtons = new();
        private readonly Random rand = new Random();
        private bool isFlightPanelVisible = false;
        public EmployeeDashboard()
        {
            InitializeComponent();
            SetupCalendar();
            LoadChartData();
        }



        // =================== LỊCH TÙY CHỈNH ===================
        private void SetupCalendar()
        {
            // xóa FlowLayoutPanel cũ (nếu có)
            foreach (var ctrl in panelCalendar.Controls.OfType<FlowLayoutPanel>().ToList())
                panelCalendar.Controls.Remove(ctrl);

            currentMonth = DateTime.Now;
            lblCalendarTitle.Text = "Lịch theo dõi hàng ngày";
            guna2HtmlLabel9.Text = $"Tháng {currentMonth:MM, yyyy}";

            // panel chứa ngày
            flowDays = new FlowLayoutPanel()
            {
                Location = new Point(25, 85),
                Size = new Size(395, 250),
                BackColor = Color.Transparent,
                WrapContents = true,
                AutoScroll = true,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0),
            };
            panelCalendar.Controls.Add(flowDays);

            // ====== tạo sẵn 31 ô ngày (tái sử dụng, không tạo lại mỗi tháng) ======
            for (int i = 0; i < 31; i++)
            {
                var btn = new Guna2Button()
                {
                    Width = 52,
                    Height = 55,
                    BorderRadius = 8,
                    FillColor = Color.FromArgb(245, 247, 250),
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI Semibold", 10),
                    Text = (i + 1).ToString(),
                    Margin = new Padding(4),
                };

                var lblSub = new Label()
                {
                    Font = new Font("Segoe UI", 8),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(15, 36)
                };
                btn.Controls.Add(lblSub);

                // click chọn ngày
                btn.Click += (s, e) =>
                {
                    foreach (var b in dayButtons)
                    {
                        b.FillColor = Color.FromArgb(245, 247, 250);
                        b.ForeColor = Color.Black;
                    }

                    btn.FillColor = Color.FromArgb(33, 150, 243);
                    btn.ForeColor = Color.White;

                    if (btn.Tag is DateTime selected)
                        UpdateDayDetails(selected);
                };

                dayButtons.Add(btn);
                flowDays.Controls.Add(btn);
            }

            // render tháng hiện tại
            RenderMonth(currentMonth);

            // nút điều hướng tháng
            prevBtn.Click += (s, e) =>
            {
                currentMonth = currentMonth.AddMonths(-1);
                guna2HtmlLabel9.Text = $"Tháng {currentMonth:MM, yyyy}";
                RenderMonth(currentMonth);
            };

            nextBtn.Click += (s, e) =>
            {
                currentMonth = currentMonth.AddMonths(1);
                guna2HtmlLabel9.Text = $"Tháng {currentMonth:MM, yyyy}";
                RenderMonth(currentMonth);
            };
        }

        private void RenderMonth(DateTime month)
        {
            int days = DateTime.DaysInMonth(month.Year, month.Month);
            DateTime today = DateTime.Today;

            for (int i = 0; i < dayButtons.Count; i++)
            {
                var btn = dayButtons[i];
                var lblSub = btn.Controls[0] as Label;

                if (i < days)
                {
                    btn.Visible = true;
                    btn.Text = (i + 1).ToString();
                    lblSub!.Text = $"{rand.Next(20, 26)}cb";
                    lblSub.ForeColor = Color.FromArgb(117, 117, 117);
                    btn.Tag = new DateTime(month.Year, month.Month, i + 1);

                    // reset màu mặc định
                    btn.FillColor = Color.FromArgb(245, 247, 250);
                    btn.ForeColor = Color.Black;
                    btn.BorderThickness = 0;

                    // đánh dấu hôm nay
                    if ((DateTime)btn.Tag == today)
                    {
                        btn.BorderThickness = 2;
                        btn.BorderColor = Color.FromArgb(33, 150, 243);
                    }
                }
                else
                {
                    btn.Visible = false;
                }
            }
        }

        private void UpdateDayDetails(DateTime selected)
        {
            guna2HtmlLabel10.Text = $"Ngày {selected:dd/MM/yyyy}";
            lblCalFlightsValue.Text = rand.Next(15, 30).ToString();
            lblCalPassengersValue.Text = rand.Next(1200, 2000).ToString();
            lblCalCancelledValue.Text = rand.Next(5, 20).ToString();
        }

        // =================== BIỂU ĐỒ ===================
        private void LoadChartData()
        {
            chartTicketStats.Plot.Clear();

            double[] x = { 0, 1, 2, 3, 4, 5, 6 };
            string[] labels = { "13/10", "14/10", "15/10", "16/10", "17/10", "18/10", "19/10" };
            double[] totalTickets = { 310, 325, 298, 340, 315, 305, 330 };
            double[] cancelledTickets = { 8, 12, 15, 10, 9, 11, 13 };

            var s1 = chartTicketStats.Plot.Add.Scatter(x, totalTickets);
            s1.LegendText = "Tổng vé";
            s1.Color = new ScottPlot.Color(33, 150, 243);
            s1.LineWidth = 3;

            var s2 = chartTicketStats.Plot.Add.Scatter(x, cancelledTickets);
            s2.LegendText = "Vé hủy";
            s2.Color = new ScottPlot.Color(244, 67, 54);
            s2.LineWidth = 3;

            chartTicketStats.Plot.Axes.Bottom.TickGenerator =
                new ScottPlot.TickGenerators.NumericManual(x, labels);
            chartTicketStats.Plot.Legend.IsVisible = true;
            chartTicketStats.Refresh();
        }

        // =================== DASHBOARD DATA ===================
        public void UpdateDashboardData(int flightsToday, int remainingFlights,
            int cancelledTickets, int totalPassengers)
        {
            lblFlightsTodayValue.Text = flightsToday.ToString();
            lblRemainingFlightsValue.Text = remainingFlights.ToString();
            lblRemainingFlightsDesc.Text = $"{flightsToday - remainingFlights} chuyến đã cất cánh";
            lblCancelledTicketsValue.Text = cancelledTickets.ToString();

            int totalTickets = totalPassengers + cancelledTickets;
            double percentage = totalTickets > 0 ? (double)cancelledTickets / totalTickets * 100 : 0;
            lblCancelledTicketsDesc.Text = $"{percentage:F1}% tổng số vé";

            lblPassengersValue.Text = totalPassengers.ToString("N0");
            lblPassengersDesc.Text = $"Trên {flightsToday} chuyến bay";
        }

        // Cập nhật biểu đồ với dữ liệu thực tế
        public void UpdateChartData(Dictionary<string, (int total, int cancelled)> weeklyData)
        {
            chartTicketStats.Plot.Clear();

            var dates = weeklyData.Keys.ToArray();
            var totalTickets = weeklyData.Values.Select(v => (double)v.total).ToArray();
            var cancelledTickets = weeklyData.Values.Select(v => (double)v.cancelled).ToArray();
            double[] positions = Enumerable.Range(0, dates.Length).Select(i => (double)i).ToArray();

            var s1 = chartTicketStats.Plot.Add.Scatter(positions, totalTickets);
            s1.LegendText = "Tổng vé";
            s1.Color = new ScottPlot.Color(33, 150, 243);
            s1.LineWidth = 3;

            var s2 = chartTicketStats.Plot.Add.Scatter(positions, cancelledTickets);
            s2.LegendText = "Vé hủy";
            s2.Color = new ScottPlot.Color(244, 67, 54);
            s2.LineWidth = 3;

            chartTicketStats.Plot.Axes.Bottom.TickGenerator =
                new ScottPlot.TickGenerators.NumericManual(positions, dates);
            chartTicketStats.Refresh();
        }

        // Async load
        public async Task LoadDashboardDataAsync()
        {
            await Task.Delay(300);
            UpdateDashboardData(24, 18, 12, 1847);

            var weeklyData = new Dictionary<string, (int total, int cancelled)>
            {
                { "13/10", (310, 8) },
                { "14/10", (325, 12) },
                { "15/10", (298, 15) },
                { "16/10", (340, 10) },
                { "17/10", (315, 9) },
                { "18/10", (305, 11) },
                { "19/10", (330, 13) }
            };

            UpdateChartData(weeklyData);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var popup = new AirlineReservation.Presentation__WinForms_.Views.Forms.Staff.FlightListPopup();

            var screenPos = this.PointToScreen(Point.Empty);
            popup.ShowPopup(screenPos);
        }

    }
}
