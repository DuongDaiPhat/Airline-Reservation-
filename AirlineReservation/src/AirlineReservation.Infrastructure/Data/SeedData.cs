using AirlineReservation.src.AirlineReservation.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservation.src.AirlineReservation.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    RoleName = "Admin",
                    Description = "System administrator with full privileges",
                    IsActive = true
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "Staff",
                    Description = "Operational staff role",
                    IsActive = true
                },
                new Role
                {
                    RoleId = 3,
                    RoleName = "Customer",
                    Description = "Registered customer role",
                    IsActive = true
                });

            modelBuilder.Entity<SeatClass>().HasData(
                new SeatClass
                {
                    SeatClassId = 1,
                    ClassName = "Economy",
                    DisplayName = "Economy",
                    PriceMultiplier = 1.00m,
                    BaggageAllowanceKg = 20,
                    CabinBaggageAllowanceKg = 7,
                    Description = "Standard economy seating"
                },
                new SeatClass
                {
                    SeatClassId = 2,
                    ClassName = "Business",
                    DisplayName = "Business",
                    PriceMultiplier = 1.75m,
                    BaggageAllowanceKg = 30,
                    CabinBaggageAllowanceKg = 10,
                    Description = "Business class with enhanced comfort"
                },
                new SeatClass
                {
                    SeatClassId = 3,
                    ClassName = "First",
                    DisplayName = "First",
                    PriceMultiplier = 2.50m,
                    BaggageAllowanceKg = 40,
                    CabinBaggageAllowanceKg = 15,
                    Description = "Premium first-class experience"
                });
        }
    }
}
