using BusBooking_API.Models;

namespace BusBooking_API.Repos.Interface
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task SaveRefreshTokenAsync(int userId, string token);
        Task<User> GetUserByRefreshTokenAsync(string token);
    }
}
