using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.Staff
{
    public partial class FlightListPopup : Form
    {
        private bool isExpanded = false;

        public FlightListPopup()
        {
            InitializeComponent();
            ApplyShadow();
            LoadFlightList();
        }

        private void ApplyShadow()
        {
            var shadow = new Guna2ShadowForm();
            shadow.SetShadowForm(this);
        }

        private Guna2ShadowPanel CreateFlightCard(string code, string fromCode, string toCode,
            string fromCity, string toCity, string timeRange, string status, int passengers, int cancelled)
        {
            var card = new Guna2ShadowPanel
            {
                Width = 410,
                Height = 130,
                Radius = 10,
                FillColor = Color.White,
                ShadowColor = Color.LightGray,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 10, 0, 0),
                Cursor = Cursors.Hand
            };

            // ===== Mã chuyến bay =====
            var lblCode = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 150, 243),
                Text = code,
                Location = new Point(16, 15),
                AutoSize = true
            };
            card.Controls.Add(lblCode);

            // ===== Giờ bay =====
            var lblTime = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold),
                ForeColor = Color.Silver,
                Text = timeRange,
                Location = new Point(16, 40),
                AutoSize = true
            };
            card.Controls.Add(lblTime);

            // ===== Chip trạng thái =====
            var chip = new Guna2ShadowPanel
            {
                BackColor = Color.Transparent,
                Radius = 3,
                FillColor = status.Contains("cất") ? Color.FromArgb(240, 240, 240)
                         : status.Contains("sẵn") ? Color.FromArgb(223, 247, 231)
                         : status.Contains("máy bay") ? Color.FromArgb(223, 242, 255)
                         : Color.FromArgb(255, 243, 224),
                ShadowColor = Color.LightGray,
                Size = new Size(121, 35),
                Location = new Point(241, 10)
            };
            var lblStatus = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold),
                ForeColor = Color.Gray,
                Text = status,
                Location = new Point(25, 6),
                AutoSize = true,
                TextAlignment = ContentAlignment.MiddleCenter
            };
            chip.Controls.Add(lblStatus);
            card.Controls.Add(chip);

            // ===== Icon mũi tên chip (→) =====
            var picArrowChip = new Guna2PictureBox
            {
                Image = Properties.Resources.next, // icon ">"
                ImageRotate = 0F,
                Location = new Point(368, 16),
                SizeMode = PictureBoxSizeMode.AutoSize,
                BackColor = Color.Transparent
            };
            card.Controls.Add(picArrowChip);

            // ===== Mã sân bay đi (HNG) =====
            var lblFromCode = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 13F),
                Text = fromCode,
                Location = new Point(16, 65),
                AutoSize = true
            };
            card.Controls.Add(lblFromCode);

            // ===== Icon → =====
            var picRightArrow = new Guna2PictureBox
            {
                Image = Properties.Resources.right_arrow, // icon nhỏ giữa
                ImageRotate = 0F,
                Location = new Point(63, 69),
                SizeMode = PictureBoxSizeMode.AutoSize,
                BackColor = Color.Transparent
            };
            card.Controls.Add(picRightArrow);

            // ===== Mã sân bay đến (HCM) =====
            var lblToCode = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 13F),
                Text = toCode,
                Location = new Point(85, 65),
                AutoSize = true
            };
            card.Controls.Add(lblToCode);

            // ===== Tổng hành khách =====
            var lblPassengers = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 13F),
                Text = $"{passengers} HK",
                Location = new Point(335, 65),
                AutoSize = true
            };
            card.Controls.Add(lblPassengers);

            // ===== Thành phố đi =====
            var lblFromCity = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold),
                ForeColor = Color.Silver,
                Text = fromCity,
                Location = new Point(16, 96),
                AutoSize = true
            };
            card.Controls.Add(lblFromCity);

            // ===== Thành phố đến =====
            var lblToCity = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold),
                ForeColor = Color.Silver,
                Text = toCity,
                Location = new Point(85, 96),
                AutoSize = true
            };
            card.Controls.Add(lblToCity);

            // ===== Số vé hủy =====
            var lblCancelled = new Guna2HtmlLabel
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold),
                ForeColor = Color.IndianRed,
                Text = $"{cancelled} Hủy",
                Location = new Point(353, 96),
                AutoSize = true
            };
            card.Controls.Add(lblCancelled);

            return card;
        }

        private void LoadFlightList()
        {
            guna2GradientPanel1.Controls.Clear();

            string[,] flights =
            {
        {"VN101", "HNG", "HCM", "Hà Nội", "TP.Hồ Chí Minh", "06:30 - 08:45", "Đã cất cánh", "185", "2"},
        {"VN202", "SGN", "DAD", "TP.HCM", "Đà Nẵng", "07:15 - 08:30", "Đã cất cánh", "165", "1"},
        {"VN303", "DAD", "HAN", "Đà Nẵng", "Hà Nội", "09:00 - 10:30", "Sẵn sàng", "178", "3"},
        {"VN404", "HAN", "PQC", "Hà Nội", "Phú Quốc", "10:30 - 12:45", "Sẵn sàng", "192", "0"},
        {"VN505", "SGN", "CXR", "TP.HCM", "Nha Trang", "11:00 - 12:15", "Đang lên máy bay", "156", "2"},
        {"VN606", "HAN", "DLI", "Hà Nội", "Đà Lạt", "13:30 - 15:00", "Chờ phê duyệt", "88", "1"},
    };

            int y = 10;
            for (int i = 0; i < flights.GetLength(0); i++)
            {
                var card = CreateFlightCard(
                    flights[i, 0],  // code
                    flights[i, 1],  // from code
                    flights[i, 2],  // to code
                    flights[i, 3],  // from city
                    flights[i, 4],  // to city
                    flights[i, 5],  // time range
                    flights[i, 6],  // status
                    int.Parse(flights[i, 7]), // passengers
                    int.Parse(flights[i, 8])  // cancelled
                );

                card.Location = new Point(10, y);
                y += card.Height + 10;
                guna2GradientPanel1.Controls.Add(card);
            }

            guna2GradientPanel1.AutoScroll = true;
        }

        public async void ShowPopup(Point position)
        {
            this.Location = new Point(position.X + 1280, position.Y + 60);
            this.Show();

            int targetX = position.X + 1280;
            while (this.Left > targetX)
            {
                this.Left -= 40;
                await Task.Delay(2);
            }
            this.Left = targetX;
        }


        // ====== Hiệu ứng đóng ======
        public async void ClosePopup()
        {
            int targetX = this.Left + 800;
            while (this.Left < targetX)
            {
                this.Left += 40;
                await Task.Delay(1);
            }
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            ClosePopup();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }
    }
}
