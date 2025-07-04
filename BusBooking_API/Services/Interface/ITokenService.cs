using BusBooking_API.Models;

namespace BusBooking_API.Services.Interface
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken();
    }
}
