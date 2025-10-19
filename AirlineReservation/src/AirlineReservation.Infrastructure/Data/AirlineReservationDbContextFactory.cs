using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AirlineReservation.src.AirlineReservation.Infrastructure.Data
{
    public class AirlineReservationDbContextFactory : IDesignTimeDbContextFactory<AirlineReservationDbContext>
    {
        public AirlineReservationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var connectionString = config.GetConnectionString("AirlineReservationDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<AirlineReservationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new AirlineReservationDbContext(optionsBuilder.Options);
        }
    }
}
