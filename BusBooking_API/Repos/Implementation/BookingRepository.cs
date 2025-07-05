using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking_API.Repos.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BusBookingContext _context;

        public BookingRepository(BusBookingContext context) => _context = context;

        public async Task<decimal> GetFarePerSeatAsync(int scheduleId) =>
            (await _context.Schedules.FindAsync(scheduleId))?.Fare ?? 0;

        public async Task<bool> AreSeatsAvailableAsync(int scheduleId, List<string> seatNumbers) =>
            await _context.SeatLayouts
                .Where(s => s.ScheduleId == scheduleId && seatNumbers.Contains(s.SeatNumber) && s.IsAvailable)
                .CountAsync() == seatNumbers.Count;

        public async Task<int> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking.Id;
        }

        public async Task BlockSeatsAsync(int scheduleId, List<string> seatNumbers)
        {
            var seats = await _context.SeatLayouts
                .Where(s => s.ScheduleId == scheduleId && seatNumbers.Contains(s.SeatNumber))
                .ToListAsync();

            foreach (var seat in seats)
                seat.IsAvailable = false;

            await _context.SaveChangesAsync();
        }

        public async Task<List<SeatLayout>> GetSeatLayoutAsync(int scheduleId)
        {
            return await _context.SeatLayouts
                .Where(s => s.ScheduleId == scheduleId)
                .ToListAsync();
        }
    }
}
