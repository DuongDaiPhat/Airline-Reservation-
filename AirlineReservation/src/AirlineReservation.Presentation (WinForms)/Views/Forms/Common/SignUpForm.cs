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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += SignUpForm_Load;
        }

        public void SignUpForm_Load(object sender, EventArgs e)
        {
            logo.Image = Properties.Resources.logo_whitetext;
            theme.Image = Properties.Resources.theme;
            vector.Image = Properties.Resources.earth;
            form.BackColor = Color.White;

            Bitmap icon = new Bitmap(vector.Image);
            icon.RotateFlip(RotateFlipType.RotateNoneFlipX);
            vector.Image = icon;
            vector.SendToBack();

        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            SignInForm signInForm = new SignInForm();
            signInForm.Show();
            this.Hide();
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            // hộp thoại tb thành công 
            DialogResult result = MessageBox.Show(
                "Đăng ký thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.OK)
            {

                SignInForm signin = new SignInForm();
                signin.Show();
                this.Hide();
            }
        }
    }
}
