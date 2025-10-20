using AirlineReservation.src.AirlineReservation.Infrastructure.Data;
using AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.Users;
using AirlineReservation.src.AirlineReservation.Shared.Utils;
using Guna.UI2.WinForms;
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
        private readonly Validation validation = new Validation();
        private readonly PasswordHasher hasher = new PasswordHasher();
        private readonly AirlineReservationDbContext dbContext;

        public SignInForm(AirlineReservationDbContext db)
        {

            InitializeComponent();
            dbContext = db;
            this.StartPosition = FormStartPosition.CenterScreen;
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
            // 1. Validate thông tin đầu vào
            if (emailTB.Text == "" && passwordTB.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin yêu câu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!validation.IsValidGoogleEmail(emailTB.Text) ) return;
            if (!validation.IsValidPassword(passwordTB.Text)) return;

            // 2. Lấy user từ DB theo email
            var user = dbContext.Users.SingleOrDefault(t => t.Email == emailTB.Text.Trim());
            if (user == null)
            {
                MessageBox.Show("Email không tồn tại trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Kiểm tra mật khẩu
            if (!hasher.VerifyPassword(passwordTB.Text, user.PasswordHash))
            {
                MessageBox.Show("Sai mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. hộp thoại tb đăng nhập thành công
            DialogResult result = MessageBox.Show(
                "Đăng nhập thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.OK)
            {
                UserForm userForm = new UserForm();
                userForm.Show();
                this.Hide();
            }
        }

        private void ForgotPS_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }
    }
}
