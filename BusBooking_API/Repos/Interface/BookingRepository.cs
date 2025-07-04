using BusBooking_API.Models;
using BusBooking_API.Repos.Implementation;
using BusBooking_API.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusBooking_API.Repos.Interface
{
    public class BookingRepository :IBookingRepository
    {
        private readonly BusBookingContext _context;
        public BookingRepository(BusBookingContext context) => _context = context;

        public async Task<int> CreateAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking.Id;
        }

        public async Task<List<Booking>> GetByUserAsync(int userId)
        {
            return await _context.Bookings.Where(b => b.UserId == userId).ToListAsync();
        }
    }
}
