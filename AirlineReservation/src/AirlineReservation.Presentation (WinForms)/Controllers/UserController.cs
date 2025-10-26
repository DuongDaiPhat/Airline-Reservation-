using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservation.src.AirlineReservation.Application.Services;
using AirlineReservation.src.AirlineReservation.Domain.Entities;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Controllers
{
    internal class UserController
    {
        private readonly UserService _userService;

        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        public void Register(string fullName, string email, string phone, string password)
            => _service.Register(fullName, email, phone, password);

        public User? Login(string email, string password)
            => _service.Login(email, password);
    }
}
