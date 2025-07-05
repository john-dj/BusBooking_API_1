using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking_API.DTOs
{
    public class CreateBookingRequest
    {
        public int ScheduleId { get; set; }
        public List<string> SeatNumbers { get; set; }
    }
}
