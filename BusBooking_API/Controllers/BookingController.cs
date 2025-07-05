using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusBooking_API.DTOs;
using BusBooking_API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BusBooking_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> BookTicket([FromBody] CreateBookingRequest request)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _service.BookSeatsAsync(userId, request);
            return Ok(result);
        }

        [HttpGet("{scheduleId}/seats")]
        public async Task<IActionResult> GetSeatLayout(int scheduleId)
        {
            var result = await _service.FetchSeatLayoutAsync(scheduleId);
            return Ok(result);
        }
    }
}
