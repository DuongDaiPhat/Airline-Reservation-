using AirlineReservation.src.AirlineReservation.Infrastructure.Data;
using AirlineReservation.src.AirlineReservation.Shared.Utils;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirlineReservation.src.AirlineReservation.Domain.Entities;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.Common
{
    public partial class SignUpForm : Form
    {
        private readonly Validation validation = new Validation();
        private readonly PasswordHasher hasher = new PasswordHasher();
        private readonly AirlineReservationDbContext dbContext;
        public SignUpForm(AirlineReservationDbContext db)
        {
            InitializeComponent();
            dbContext = db;
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.Load += SignUpForm_Load;
        }

        //public void SignUpForm_Load(object sender, EventArgs e)
        //{
        //    logo.Image = Properties.Resources.logo_whitetext;
        //    theme.Image = Properties.Resources.theme;
        //    vector.Image = Properties.Resources.earth;
        //    form.BackColor = Color.White;

        //    Bitmap icon = new Bitmap(vector.Image);
        //    icon.RotateFlip(RotateFlipType.RotateNoneFlipX);
        //    vector.Image = icon;
        //    vector.SendToBack();

        //}

        private void SignIn_Click(object sender, EventArgs e)
        {
            using var db = Connection.GetDbContext();
            SignInForm signInForm = new SignInForm(db);
            signInForm.Show();
            this.Hide();
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            if (emailTB.Text == "" && userNameTB.Text == "" && numberTB.Text == "" && passwordTB.Text == "" && confirmPasswordTB.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin yêu câu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!validation.IsValidGoogleEmail(emailTB.Text)) return;
            if (!validation.IsValidPhoneNumber(numberTB.Text)) return;
            if (!validation.IsValidPassword(passwordTB.Text)) return;
            if (!Equals(passwordTB.Text, confirmPasswordTB.Text))
            {
                MessageBox.Show("Mật khẩu không đồng bộ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var db = Connection.GetDbContext();

            // 1. Tạo User mới
            var newUser = new User
            {
                UserId = Guid.NewGuid(),
                FullName = userNameTB.Text.Trim(),
                Email = emailTB.Text.Trim(),
                Phone = numberTB.Text.Trim(),
                PasswordHash = hasher.HashPassword(passwordTB.Text),
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsVerified = false
            };
            db.Users.Add(newUser);

            // 2. Gán Role mặc định = 3 - Khách hàng
            var userRole = new UserRole
            {
                UserId = newUser.UserId,
                RoleId = 3,
                AssignedAt = DateTime.Now,
                AssignedBy = Guid.Parse("C3F4E0AA-3736-4A30-A17A-688E9DEB5E18")
            };
            db.UserRoles.Add(userRole);

            // 3. Lưu thay đổi vào DB
            db.SaveChanges();

            // 4. Hộp thoại tb thành công 
            DialogResult result = MessageBox.Show(
                "Đăng ký thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.OK)
            {
                SignInForm signin = new SignInForm(db);
                signin.Show();
                this.Hide();
            }
        }
    }
}
