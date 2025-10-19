using AirlineReservation.src.AirlineReservation.Domain.Entities;
using AirlineReservation.src.AirlineReservation.Domain.Entities.Flights;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation.src.AirlineReservation.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        // DbSet cho bảng Flight
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình bảng Flight
            modelBuilder.Entity<Flight>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.FlightNumber).IsRequired().HasMaxLength(20);
                entity.Property(f => f.Departure).IsRequired().HasMaxLength(50);
                entity.Property(f => f.Arrival).IsRequired().HasMaxLength(50);
                entity.Property(f => f.DepartureTime).IsRequired();
            });
        }
    }
}
