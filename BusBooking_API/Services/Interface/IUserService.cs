using BusBooking_API.DTOs;

namespace BusBooking_API.Services.Interface
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }
}
