using BusBooking_API.Models;
using BusBooking_API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BusBooking_API.Controllers
{
    [Authorize] // Requires JWT token
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService) => _bookingService = bookingService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var bookingId = await _bookingService.CreateBookingAsync(request, userId);
            return Ok(new { bookingId });
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var bookings = await _bookingService.GetBookingsByUserAsync(userId);
            return Ok(bookings);
        }
    }
}
