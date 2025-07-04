using BusBooking_API.DTOs;
using BusBooking_API.Models;

namespace BusBooking_API.Services.Interface
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> SearchSchedulesAsync(ScheduleSearchRequest request);
        Task<List<SeatLayout>> GetSeatLayoutAsync(int scheduleId);
        Task<ScheduleDto> GetScheduleDetailsAsync(int scheduleId);
    }
}
