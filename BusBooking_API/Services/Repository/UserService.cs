using BusBooking_API.DTOs;
using BusBooking_API.Models;
using BusBooking_API.Repos.Interface;
using BusBooking_API.Services.Interface;

namespace BusBooking_API.Services.Repository
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        public async Task<string> RegisterAsync(RegisterRequest request)
        {
            var existing = await _userRepo.GetByEmailAsync(request.Email);
            if (existing != null) return "User already exists.";

            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = "User"
            };

            await _userRepo.AddAsync(user);
            return "Registered Successfully.";
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepo.GetByEmailAsync(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            var token = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            await _userRepo.SaveRefreshTokenAsync(user.Id, refreshToken);

            return new AuthResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                Email = user.Email,
                FullName = user.FullName
            };
        }
    }
}
