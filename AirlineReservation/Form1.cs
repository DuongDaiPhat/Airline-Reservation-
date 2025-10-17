using AirlineReservation.src.AirlineReservation.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AirlineReservation
{
    public partial class Form1 : Form
    {
        private readonly ApplicationDbContext _db;
        // inject DbContext qua constructor
        public Form1(ApplicationDbContext db)
        {
            InitializeComponent();
            _db = db;

            this.Load += Form1_Load; // gán event khi form load
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // L?y d? li?u t? b?ng Flights
            var flights = _db.Flights
                .AsNoTracking()
                .Select(f => new
                {
                    f.Id,
                    f.FlightNumber,
                    f.Departure,
                    f.Arrival,
                    f.DepartureTime
                })
                .ToList();

            // Gán vào DataGridView
            data.DataSource = flights;
        }
    }
}
