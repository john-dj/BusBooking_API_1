using BusBooking_API.Models;

namespace BusBooking_API.Services.Interface
{
    public interface IBookingService
    {
        Task<int> CreateBookingAsync(CreateBookingRequest request, int userId);
        Task<List<Booking>> GetBookingsByUserAsync(int userId);
    }
}
