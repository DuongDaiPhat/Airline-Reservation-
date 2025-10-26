using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AirlineReservation.src.AirlineReservation.Shared.Utils
{
    public class Validation
    {
        private readonly bool _showMessage;
        public Validation(bool showMessage = true) => _showMessage = showMessage;

        private void Show(string msg)
        {
            if (_showMessage)
                MessageBox.Show(msg, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-z]{2,}$";
            if (!Regex.IsMatch(email ?? "", pattern, RegexOptions.IgnoreCase))
            {
                Show("Email không hợp lệ.");
                return false;
            }
            return true;
        }

        public bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{10,20}$";
            if (!Regex.IsMatch(password ?? "", pattern))
            {
                Show("Mật khẩu phải 10–20 ký tự, có ít nhất 1 chữ hoa, 1 số, 1 ký tự đặc biệt.");
                return false;
            }
            return true;
        }

        public bool IsValidPhoneNumber(string phone)
        {
            string pattern = @"^(0\d{9}|\+84\d{9})$";
            if (!Regex.IsMatch(phone ?? "", pattern))
            {
                Show("Số điện thoại không hợp lệ.");
                return false;
            }
            return true;
        }

        public bool IsValidFullName(string name)
        {
            string pattern = @"^[a-zA-ZÀ-ỹ\s]{2,}$";
            if (!Regex.IsMatch(name ?? "", pattern))
            {
                Show("Họ tên không hợp lệ.");
                return false;
            }
            return true;
        }
    }
}
