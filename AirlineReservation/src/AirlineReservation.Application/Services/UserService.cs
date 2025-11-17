using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservation.src.AirlineReservation.Application.Interfaces;
using AirlineReservation.src.AirlineReservation.Domain.Entities;
using AirlineReservation.src.AirlineReservation.Shared.Utils;

namespace AirlineReservation.src.AirlineReservation.Application.Services
{
    internal class UserService
    {
        private readonly IRepository<User> _userRepo;
        private readonly PasswordHasher _passwordHasher = new PasswordHasher();
        private readonly Validation _validator = new(showMessage: false);
        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;

        }

        public IEnumerable<User> GetAllUsers() => _userRepo.GetAll();

        // Đăng ký (hash password trước khi lưu)
        public void Register(string fullName, string email, string phone, string password)
        {
            if (!_validator.IsValidFullName(fullName))
                throw new Exception("Họ tên không hợp lệ.");
            if (!_validator.IsValidEmail(email))
                throw new Exception("Email không hợp lệ.");
            if (!_validator.IsValidPhoneNumber(phone))
                throw new Exception("Số điện thoại không hợp lệ.");
            if (!_validator.IsValidPassword(password))
                throw new Exception("Mật khẩu không hợp lệ.");

            if (_userRepo.GetAll().Any(u => u.Email == email))
                throw new Exception("Email đã tồn tại.");

            var user = new User
            {
                UserId = Guid.NewGuid(),
                FullName = fullName,
                Email = email,
                Phone = phone,
                PasswordHash = _passwordHasher.HashPassword(password),
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsVerified = true
            };

            _userRepo.Add(user);
            _userRepo.Save();
        }

        public User? Login(string email, string password)
        {
            var user = _userRepo.GetAll().FirstOrDefault(u => u.Email == email);
            if (user == null) return null;

            bool match = _passwordHasher.VerifyPassword(password, user.PasswordHash);
            return match ? user : null;
        }
    }   

}
