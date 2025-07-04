using BusBooking_API.Models;

namespace BusBooking_API.Repos.Implementation
{
    public interface IBookingRepository
    {
        Task<int> CreateAsync(Booking booking);
        Task<List<Booking>> GetByUserAsync(int userId);
    }
}
