using BusBooking_API.DTOs;
using BusBooking_API.Models;

namespace BusBooking_API.Repos.Interface
{
    public interface IScheduleRepository
    {
        Task<List<ScheduleDto>> SearchSchedulesAsync(string source, string destination, DateTime travelDate);
        Task<List<SeatLayout>> GetSeatLayoutAsync(int scheduleId);
        Task<ScheduleDto> GetScheduleDetailsAsync(int scheduleId);
    }
}
