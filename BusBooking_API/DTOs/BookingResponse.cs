using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking_API.DTOs
{
    public class BookingResponse
    {
        public int BookingId { get; set; }
        public decimal TotalFare { get; set; }
        public List<string> BookedSeats { get; set; }
    }
}
