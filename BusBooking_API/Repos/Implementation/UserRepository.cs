using BusBooking_API.Models;
using BusBooking_API.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusBooking_API.Repos.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly BusBookingContext _context;
        public UserRepository(BusBookingContext context) => _context = context;

        public async Task<User> GetByEmailAsync(string email) =>
            await _context.Users.Include(u => u.RefreshTokens)
                                .FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task SaveRefreshTokenAsync(int userId, string token)
        {
            _context.RefreshTokens.Add(new RefreshToken
            {
                Token = token,
                UserId = userId,
                ExpiryDate = DateTime.UtcNow.AddDays(7)
            });
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByRefreshTokenAsync(string token)
        {
            return await _context.Users.Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token && t.ExpiryDate > DateTime.UtcNow));
        }
    }
}
