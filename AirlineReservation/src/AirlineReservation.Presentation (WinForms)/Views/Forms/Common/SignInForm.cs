using AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.User;
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

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Views.Forms.Common
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += SignInForm_Load;
        }
        public void SignInForm_Load(object sender, EventArgs e)
        {
            logo.Image = Properties.Resources.logo_whitetext;
            theme.Image = Properties.Resources.theme;
            vector.Image = Properties.Resources.earth;
            form.BackColor = Color.White;

            pictureBox1.Image = Properties.Resources.google;
            pictureBox2.Image = Properties.Resources.github;
            pictureBox3.Image = Properties.Resources.microsoft;

            Bitmap icon = new Bitmap(vector.Image);
            icon.RotateFlip(RotateFlipType.RotateNoneFlipX);
            vector.Image = icon;
            vector.SendToBack();

        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
            this.Hide();
        }


        private void SignInBtn_Click(object sender, EventArgs e)
        {
            // hộp thoại tb đăng nhập thành công
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
