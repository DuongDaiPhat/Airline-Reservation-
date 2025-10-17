using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservation.src.AirlineReservation.Domain.Entities.Flights
{
    public class Flight
    {
            public int Id { get; set; }
            public string FlightNumber { get; set; }
            public string Departure { get; set; }
            public string Arrival { get; set; }
            public DateTime DepartureTime { get; set; }
    }
}
