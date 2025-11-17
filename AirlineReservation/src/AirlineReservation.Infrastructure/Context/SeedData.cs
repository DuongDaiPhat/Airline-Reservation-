using AirlineReservation.src.AirlineReservation.Domain.Entities;
using AirlineReservation.src.AirlineReservation.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace AirlineReservation.src.AirlineReservation.Infrastructure.Context
{
    public static class SeedData
    {
        private readonly static PasswordHasher hasher = new PasswordHasher();
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Roles
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

            // SeatClasses
            modelBuilder.Entity<SeatClass>().HasData(
                new SeatClass
                {
                    SeatClassId = 1,
                    ClassName = "Economy",
                    DisplayName = "Economy",
                    PriceMultiplier = 1.00m,
                    BaggageAllowanceKg = 20,
                    CabinBaggageAllowanceKg = 7,
                    Description = "Standard economy seating",
                    Features = "Standard seats, in-flight entertainment, basic meals"
                },
                new SeatClass
                {
                    SeatClassId = 2,
                    ClassName = "Premium Economy",
                    DisplayName = "Premium Economy",
                    PriceMultiplier = 1.50m,
                    BaggageAllowanceKg = 25,
                    CabinBaggageAllowanceKg = 10,
                    Description = "Premium economy seating",
                    Features = "Wider seats, comfortable legroom, priority boarding, premium meals"
                },
                new SeatClass
                {
                    SeatClassId = 3,
                    ClassName = "Business",
                    DisplayName = "Business",
                    PriceMultiplier = 2.50m,
                    BaggageAllowanceKg = 30,
                    CabinBaggageAllowanceKg = 12,
                    Description = "Business class with enhanced comfort",
                    Features = "180-degree lie-flat seats, luxury lounge, 5-star meals, priority check-in"
                },
                new SeatClass
                {
                    SeatClassId = 4,
                    ClassName = "First",
                    DisplayName = "First",
                    PriceMultiplier = 4.00m,
                    BaggageAllowanceKg = 40,
                    CabinBaggageAllowanceKg = 15,
                    Description = "Premium first-class experience",
                    Features = "Separate cabins, massage chairs, butler service, varied menu, in-flight spa"
                });

            // Users
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = Guid.Parse("d3f9a7c2-8b1e-4f3a-9c2a-7e4f9a1b2c3d"),
                    FullName = "ADMIN",
                    Email = "admin@gmail.com",
                    Phone = "0999999999",
                    PasswordHash = hasher.HashPassword("Admin@12345"),
                    IsVerified = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 10, 20, 0, 0, 0, 0)
                },
                new User
                {
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FullName = "Khanh",
                    Email = "khanh@gmail.com",
                    Phone = "0900000001",
                    PasswordHash = hasher.HashPassword("Khanh@12345"),
                    IsVerified = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 10, 21, 0, 0, 0, 0)
                },
                new User
                {
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    FullName = "Vinh",
                    Email = "vinh@gmail.com",
                    Phone = "0900000002",
                    PasswordHash = hasher.HashPassword("Vinh@12345"),
                    IsVerified = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 10, 21, 0, 0, 0, 0)
                },
                new User
                {
                    UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    FullName = "Phát",
                    Email = "phat@gmail.com",
                    Phone = "0900000003",
                    PasswordHash = hasher.HashPassword("Phat@12345"),
                    IsVerified = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 10, 21, 0, 0, 0, 0)
                },
                new User
                {
                    UserId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    FullName = "Kha",
                    Email = "kha@gmail.com",
                    Phone = "0900000004",
                    PasswordHash = hasher.HashPassword("Kha@123456"),
                    IsVerified = true,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 10, 21, 0, 0, 0, 0)
                }
            );

            // UserRoles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserId = Guid.Parse("d3f9a7c2-8b1e-4f3a-9c2a-7e4f9a1b2c3d"),
                    RoleId = 1, // Admin
                    AssignedAt = new DateTime(2025, 10, 20, 0, 0, 0, 0),
                    AssignedBy = null
                },
                new UserRole
                {
                    UserId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    RoleId = 3, // Khách hàng
                    AssignedAt = new DateTime(2025, 10, 21, 0, 0, 0, 0),
                    AssignedBy = Guid.Parse("d3f9a7c2-8b1e-4f3a-9c2a-7e4f9a1b2c3d")
                },
                new UserRole
                {
                    UserId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    RoleId = 3,
                    AssignedAt = new DateTime(2025, 10, 21, 0, 0, 0, 0),
                    AssignedBy = Guid.Parse("d3f9a7c2-8b1e-4f3a-9c2a-7e4f9a1b2c3d")
                },
                new UserRole
                {
                    UserId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    RoleId = 3,
                    AssignedAt = new DateTime(2025, 10, 21, 0, 0, 0, 0),
                    AssignedBy = Guid.Parse("d3f9a7c2-8b1e-4f3a-9c2a-7e4f9a1b2c3d")
                },
                new UserRole
                {
                    UserId = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                    RoleId = 3,
                    AssignedAt = new DateTime(2025, 10, 21, 0, 0, 0, 0),
                    AssignedBy = Guid.Parse("d3f9a7c2-8b1e-4f3a-9c2a-7e4f9a1b2c3d")
                }
            );

        }
    }
}
