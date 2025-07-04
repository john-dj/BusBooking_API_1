using Microsoft.EntityFrameworkCore;

namespace BusBooking_API.Models
{
    public class BusBookingContext : DbContext
    {
        public BusBookingContext(DbContextOptions<BusBookingContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Buses> Buses { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SeatLayout> SeatLayouts { get; set; }
    }

}
