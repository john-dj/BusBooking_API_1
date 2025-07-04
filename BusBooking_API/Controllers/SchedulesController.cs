using BusBooking_API.DTOs;
using BusBooking_API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _service;
        public SchedulesController(IScheduleService service)
        {
            _service = service;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchSchedules([FromBody] ScheduleSearchRequest request)
        {
            var result = await _service.SearchSchedulesAsync(request);
            return Ok(result);
        }

        [HttpGet("{scheduleId}")]
        public async Task<IActionResult> GetScheduleDetails(int scheduleId)
        {
            var schedule = await _service.GetScheduleDetailsAsync(scheduleId);
            if (schedule == null) return NotFound();
            return Ok(schedule);
        }

        [HttpGet("{scheduleId}/seats")]
        public async Task<IActionResult> GetSeatLayout(int scheduleId)
        {
            var seats = await _service.GetSeatLayoutAsync(scheduleId);
            return Ok(seats);
        }
    }
}
