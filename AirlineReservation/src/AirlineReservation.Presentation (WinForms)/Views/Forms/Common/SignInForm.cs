using AirlineReservation.src.AirlineReservation.Infrastructure.Context;
using AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Helpers;
using AirlineReservation.src.AirlineReservation.Shared.Utils;
using Guna.UI2.WinForms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.Common
{
    public partial class SignInForm : Form
    {
        private readonly Validation _validation = new Validation();

        public SignInForm(AirlineReservationDbContext db)
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1280, 800);
            //this.Load += SignInForm_Load;
        }
        //public void SignInForm_Load(object sender, EventArgs e)
        //{
        //    logo.Image = Properties.Resources.logo_whitetext;
        //    theme.Image = Properties.Resources.theme;
        //    vector.Image = Properties.Resources.earth;
        //    form.BackColor = Color.White;

        //    pictureBox1.Image = Properties.Resources.google;
        //    pictureBox2.Image = Properties.Resources.github;
        //    pictureBox3.Image = Properties.Resources.microsoft;

        //    Bitmap icon = new Bitmap(vector.Image);
        //    icon.RotateFlip(RotateFlipType.RotateNoneFlipX);
        //    vector.Image = icon;
        //    vector.SendToBack();

        //}

        private void SignUp_Click(object sender, EventArgs e)
        {
            using var db = Connection.GetDbContext();
            SignUpForm signUpForm = new SignUpForm(db);
            signUpForm.Show();
            this.Hide();
        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 1. Kiểm tra input
                if (string.IsNullOrWhiteSpace(emailTB.Text) || string.IsNullOrWhiteSpace(passwordTB.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!_validation.IsValidEmail(emailTB.Text)) return;
                if (!_validation.IsValidPassword(passwordTB.Text)) return;

                // 🔹 2. Gọi controller để đăng nhập
                var user = Provider.UserController.Login(emailTB.Text.Trim(), passwordTB.Text.Trim());

                // 🔹 3. Xử lý kết quả
                if (user == null)
                {
                    MessageBox.Show("Sai email hoặc mật khẩu.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!user.IsActive)
                {
                    MessageBox.Show("Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 4. Đăng nhập thành công
                MessageBox.Show($"Xin chào {user.FullName}!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //// Ví dụ: nếu bạn có Dashboard riêng cho từng role
                //if (user.UserRoles.Any(r => r.Role.RoleName == "Admin"))
                //{
                //    AdminDashboard adminDashboard = new AdminDashboard();
                //    adminDashboard.Show();
                //}
                //else
                //{
                //    StaffDashboard staffDashboard = new StaffDashboard();
                //    staffDashboard.Show();
                //}
                Form1 mainForm = new Form1();
                mainForm.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ForgotPS_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
