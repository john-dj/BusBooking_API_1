using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking_API.Repos.Interface
{
    public interface IBookingRepository
    {
        Task<decimal> GetFarePerSeatAsync(int scheduleId);
        Task<bool> AreSeatsAvailableAsync(int scheduleId, List<string> seatNumbers);
        Task<int> CreateBookingAsync(Booking booking);
        Task BlockSeatsAsync(int scheduleId, List<string> seatNumbers);
        Task<List<SeatLayout>> GetSeatLayoutAsync(int scheduleId);
    }
}
