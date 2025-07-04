using BusBooking_API.Models;
using BusBooking_API.Repos.Implementation;
using BusBooking_API.Services.Interface;

namespace BusBooking_API.Services.Repository
{
    public class BookingService :IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        public BookingService(IBookingRepository bookingRepo) => _bookingRepo = bookingRepo;

        public async Task<int> CreateBookingAsync(CreateBookingRequest request, int userId)
        {
            var booking = new Booking
            {
                UserId = userId,
                ScheduleId = request.ScheduleId,
                NoOfSeats = request.NoOfSeats,
                TotalFare = request.TotalFare,
                BookingDate = DateTime.UtcNow
            };
            return await _bookingRepo.CreateAsync(booking);
        }

        public async Task<List<Booking>> GetBookingsByUserAsync(int userId)
        {
            return await _bookingRepo.GetByUserAsync(userId);
        }
    }
}
