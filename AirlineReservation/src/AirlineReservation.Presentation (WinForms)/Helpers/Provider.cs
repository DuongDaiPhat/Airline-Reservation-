using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirlineReservation.src.AirlineReservation.Application.Services;
using AirlineReservation.src.AirlineReservation.Domain.Entities;
using AirlineReservation.src.AirlineReservation.Infrastructure.Context;
using AirlineReservation.src.AirlineReservation.Infrastructure.Repositories;
using AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Controllers;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservation.src.AirlineReservation.Presentation__WinForms_.Helpers
{
    internal class Provider
    {
        private static readonly AirlineReservationDbContext _dbContext;
        private static readonly BaseRepository<User> _userRepo; 
        private static readonly UserService _userService;
        private static readonly UserController _userController;

        static Provider()
        {
            var conn = AppConfigHelper.GetConnectionString("AirlineReservationDatabase");
            var options = new DbContextOptionsBuilder<AirlineReservationDbContext>()
                .UseSqlServer(conn)
                .Options;

            _dbContext = new AirlineReservationDbContext(options);
            _userRepo = new BaseRepository<User>(_dbContext);
            _userService = new UserService(_userRepo);
            _userController = new UserController(_userService);
        }
        public static UserController UserController => _userController;
    }
}
