using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking_API.Services.Interface
{
    public class IBookingService
    {
        Task<BookingResponse> BookSeatsAsync(int userId, CreateBookingRequest request);
        Task<List<SeatLayout>> FetchSeatLayoutAsync(int scheduleId);
    }
}
