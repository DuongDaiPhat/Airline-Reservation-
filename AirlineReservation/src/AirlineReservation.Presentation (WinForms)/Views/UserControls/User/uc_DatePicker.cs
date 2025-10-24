using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static Guna.UI2.WinForms.Suite.Descriptions;

namespace FlightBooking
{
    [DesignerCategory("Code")]
    public class FlightDatePickerUC : UserControl
    {
        private Guna2Panel mainPanel;
        private Guna2RadioButton rbOneWay;
        private Guna2RadioButton rbRoundTrip;
        private Guna2Panel datePanel1;
        private Guna2Panel datePanel2;
        private Label lblDepartureTitle;
        private Label lblReturnTitle;
        private Label lblDepartureDate;
        private Label lblReturnDate;
        private Guna2Button btnSearch;
        private Guna2Panel calendarContainer;
        private FlowLayoutPanel monthsPanel;

        private DateTime? departureDate;
        private DateTime? returnDate;
        private bool isSelectingDeparture = true;
        private bool isRoundTrip = false;

        public FlightDatePickerUC()
        {
            InitializeControls();
            SetupUI();
            SetupEvents();
        }

        private void InitializeControls()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(800, 650);
            this.ResumeLayout(false);
        }

        private void SetupUI()
        {
            // Main Panel
            mainPanel = new Guna2Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Radio buttons panel
            var radioPanel = new Guna2Panel
            {
                Location = new Point(20, 20),
                Size = new Size(760, 40),
                BackColor = Color.Transparent
            };

            rbOneWay = new Guna2RadioButton
            {
                Text = "Một chiều",
                Location = new Point(10, 10),
                Checked = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(64, 64, 64)
            };

            rbRoundTrip = new Guna2RadioButton
            {
                Text = "Khứ hồi",
                Location = new Point(150, 10),
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(64, 64, 64),
                CheckedState = { FillColor = Color.FromArgb(0, 150, 255) }
            };

            radioPanel.Controls.Add(rbOneWay);
            radioPanel.Controls.Add(rbRoundTrip);

            // Date selection panels
            var dateContainer = new Guna2Panel
            {
                Location = new Point(20, 70),
                Size = new Size(680, 60),
                BackColor = Color.Transparent
            };

            datePanel1 = CreateDatePanel("Ngày khởi hành", "21 thg 10 2025", 0);
            datePanel2 = CreateDatePanel("Ngày về", "23 thg 10 2025", 340);
            datePanel2.Enabled = false;
            datePanel2.FillColor = Color.FromArgb(240, 240, 240);

            dateContainer.Controls.Add(datePanel1);
            dateContainer.Controls.Add(datePanel2);

            // Search button
            //btnSearch = new Guna2Button
            //{
            //    Location = new Point(710, 70),
            //    Size = new Size(70, 60),
            //    BorderRadius = 8,
            //    FillColor = Color.FromArgb(255, 87, 34),
            //    Image = Properties.Resources.SearchIcon, // Bạn cần thêm icon
            //    ImageSize = new Size(24, 24),
            //    Cursor = Cursors.Hand
            //};

            // Calendar container
            calendarContainer = new Guna2Panel
            {
                Location = new Point(20, 145),
                Size = new Size(760, 480),
                AutoScroll = true,
                BorderColor = Color.FromArgb(230, 230, 230),
                BorderThickness = 1,
                BorderRadius = 8
            };

            // Months panel (horizontal scroll)
            monthsPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                AutoScroll = true,
                WrapContents = false,
                BackColor = Color.White
            };

            calendarContainer.Controls.Add(monthsPanel);

            // Add all controls
            mainPanel.Controls.Add(radioPanel);
            mainPanel.Controls.Add(dateContainer);
            mainPanel.Controls.Add(btnSearch);
            mainPanel.Controls.Add(calendarContainer);
            this.Controls.Add(mainPanel);

            // Create calendars
            CreateCalendars();
        }

        private Guna2Panel CreateDatePanel(string title, string defaultDate, int x)
        {
            var panel = new Guna2Panel
            {
                Location = new Point(x, 0),
                Size = new Size(330, 60),
                BorderColor = Color.FromArgb(200, 200, 200),
                BorderThickness = 1,
                BorderRadius = 8,
                Cursor = Cursors.Hand,
                FillColor = Color.White
            };

            var iconLabel = new Label
            {
                Location = new Point(15, 20),
                Size = new Size(24, 24),
                Text = "📅",
                Font = new Font("Segoe UI", 12)
            };

            var titleLabel = new Label
            {
                Text = title,
                Location = new Point(50, 10),
                Size = new Size(270, 20),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray
            };

            var dateLabel = new Label
            {
                Text = defaultDate,
                Location = new Point(50, 30),
                Size = new Size(270, 24),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64)
            };

            panel.Controls.Add(iconLabel);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(dateLabel);

            if (title == "Ngày khởi hành")
                lblDepartureDate = dateLabel;
            else
                lblReturnDate = dateLabel;

            return panel;
        }

        private void CreateCalendars()
        {
            DateTime currentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            for (int i = 0; i < 3; i++)
            {
                var monthCalendar = CreateMonthCalendar(currentMonth.AddMonths(i));
                monthsPanel.Controls.Add(monthCalendar);
            }
        }

        private Panel CreateMonthCalendar(DateTime month)
        {
            var panel = new Panel
            {
                Size = new Size(370, 450),
                Margin = new Padding(5)
            };

            // Month header
            var headerLabel = new Label
            {
                Text = $"tháng {month.Month} năm {month.Year}",
                Location = new Point(10, 10),
                Size = new Size(350, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(headerLabel);

            // Day headers
            string[] dayNames = { "CN", "Th 2", "Th 3", "Th 4", "Th 5", "Th 6", "Th 7" };
            for (int i = 0; i < 7; i++)
            {
                var dayHeader = new Label
                {
                    Text = dayNames[i],
                    Location = new Point(10 + i * 50, 50),
                    Size = new Size(45, 25),
                    Font = new Font("Segoe UI", 9),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = i == 0 ? Color.Red : Color.Gray
                };
                panel.Controls.Add(dayHeader);
            }

            // Days
            DateTime firstDay = new DateTime(month.Year, month.Month, 1);
            int startDay = (int)firstDay.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
            DateTime today = DateTime.Now.Date;

            int row = 0;
            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime currentDate = new DateTime(month.Year, month.Month, day);
                int col = (startDay + day - 1) % 7;
                if (col == 0 && day > 1) row++;

                var dayButton = new Guna2Button
                {
                    Text = day.ToString(),
                    Location = new Point(10 + col * 50, 85 + row * 55),
                    Size = new Size(45, 50),
                    BorderRadius = 8,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Tag = currentDate,
                    Cursor = Cursors.Hand,
                    FillColor = Color.White,
                    ForeColor = Color.FromArgb(64, 64, 64),
                    BorderThickness = 1,
                    BorderColor = Color.FromArgb(230, 230, 230)
                };

                // Disable past dates
                if (currentDate < today)
                {
                    dayButton.Enabled = false;
                    dayButton.ForeColor = Color.LightGray;
                    dayButton.Cursor = Cursors.Default;
                }
                else
                {
                    dayButton.Click += DayButton_Click;
                    dayButton.MouseEnter += (s, e) =>
                    {
                        if (dayButton.Enabled)
                            dayButton.FillColor = Color.FromArgb(230, 240, 255);
                    };
                    dayButton.MouseLeave += (s, e) =>
                    {
                        if (dayButton.Enabled && !IsDateSelected((DateTime)dayButton.Tag))
                            dayButton.FillColor = Color.White;
                    };
                }

                // Highlight today
                if (currentDate == today)
                {
                    dayButton.BorderColor = Color.FromArgb(0, 150, 255);
                    dayButton.BorderThickness = 2;
                }

                // Add price label (optional)
                var priceLabel = new Label
                {
                    Text = GetRandomPrice(),
                    Location = new Point(15 + col * 50, 120 + row * 55),
                    Size = new Size(40, 15),
                    Font = new Font("Segoe UI", 7),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent
                };
                panel.Controls.Add(priceLabel);
                panel.Controls.Add(dayButton);
            }

            return panel;
        }

        private void SetupEvents()
        {
            rbOneWay.CheckedChanged += (s, e) =>
            {
                if (rbOneWay.Checked)
                {
                    isRoundTrip = false;
                    datePanel2.Enabled = false;
                    datePanel2.FillColor = Color.FromArgb(240, 240, 240);
                    returnDate = null;
                    lblReturnDate.Text = "Chọn ngày về";
                }
            };

            rbRoundTrip.CheckedChanged += (s, e) =>
            {
                if (rbRoundTrip.Checked)
                {
                    isRoundTrip = true;
                    datePanel2.Enabled = true;
                    datePanel2.FillColor = Color.White;
                }
            };

            datePanel1.Click += (s, e) =>
            {
                isSelectingDeparture = true;
                datePanel1.BorderColor = Color.FromArgb(0, 150, 255);
                datePanel1.BorderThickness = 2;
                datePanel2.BorderThickness = 1;
                datePanel2.BorderColor = Color.FromArgb(200, 200, 200);
            };

            datePanel2.Click += (s, e) =>
            {
                if (isRoundTrip)
                {
                    isSelectingDeparture = false;
                    datePanel2.BorderColor = Color.FromArgb(0, 150, 255);
                    datePanel2.BorderThickness = 2;
                    datePanel1.BorderThickness = 1;
                    datePanel1.BorderColor = Color.FromArgb(200, 200, 200);
                }
            };

            btnSearch.Click += BtnSearch_Click;
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            var button = sender as Guna2Button;
            DateTime selectedDate = (DateTime)button.Tag;

            if (isSelectingDeparture)
            {
                departureDate = selectedDate;
                lblDepartureDate.Text = selectedDate.ToString("dd 'thg' MM yyyy");
                button.FillColor = Color.FromArgb(0, 150, 255);
                button.ForeColor = Color.White;

                // Auto switch to return date if round trip
                if (isRoundTrip)
                {
                    isSelectingDeparture = false;
                    datePanel1.BorderThickness = 1;
                    datePanel1.BorderColor = Color.FromArgb(200, 200, 200);
                    datePanel2.BorderColor = Color.FromArgb(0, 150, 255);
                    datePanel2.BorderThickness = 2;
                }
            }
            else if (isRoundTrip)
            {
                if (departureDate.HasValue && selectedDate <= departureDate.Value)
                {
                    MessageBox.Show("Ngày về phải sau ngày đi!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                returnDate = selectedDate;
                lblReturnDate.Text = selectedDate.ToString("dd 'thg' MM yyyy");
                button.FillColor = Color.FromArgb(0, 150, 255);
                button.ForeColor = Color.White;
            }
        }

        private bool IsDateSelected(DateTime date)
        {
            return (departureDate.HasValue && departureDate.Value.Date == date.Date) ||
                   (returnDate.HasValue && returnDate.Value.Date == date.Date);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!departureDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày khởi hành!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isRoundTrip && !returnDate.HasValue)
            {
                MessageBox.Show("Vui lòng chọn ngày về!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string message = $"Ngày đi: {departureDate.Value:dd/MM/yyyy}";
            if (isRoundTrip)
                message += $"\nNgày về: {returnDate.Value:dd/MM/yyyy}";

            MessageBox.Show(message, "Thông tin chuyến bay", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetRandomPrice()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            double price = rand.Next(1500, 5000) / 1000.0;
            return price.ToString("0.000") + "K";
        }

        // Public properties
        public DateTime? DepartureDate => departureDate;
        public DateTime? ReturnDate => returnDate;
        public bool IsRoundTrip => isRoundTrip;
    }
}