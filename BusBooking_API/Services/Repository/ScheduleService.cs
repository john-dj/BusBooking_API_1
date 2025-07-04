using BusBooking_API.DTOs;
using BusBooking_API.Models;
using BusBooking_API.Repos.Interface;

namespace BusBooking_API.Services.Repository
{
    public class ScheduleService
    {
        private readonly IScheduleRepository _repository;
        public ScheduleService(IScheduleRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ScheduleDto>> SearchSchedulesAsync(ScheduleSearchRequest request)
        {
            return await _repository.SearchSchedulesAsync(request.Source, request.Destination, request.TravelDate);
        }

        public async Task<List<SeatLayout>> GetSeatLayoutAsync(int scheduleId)
        {
            return await _repository.GetSeatLayoutAsync(scheduleId);
        }

        public async Task<ScheduleDto> GetScheduleDetailsAsync(int scheduleId)
        {
            return await _repository.GetScheduleDetailsAsync(scheduleId);
        }
    }
}
