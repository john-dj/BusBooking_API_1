using BusBooking_API.DTOs;
using BusBooking_API.Models;
using BusBooking_API.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace BusBooking_API.Repos.Implementation
{
    public class ScheduleRepository :IScheduleRepository
    {
        private readonly BusBookingContext _context;
        public ScheduleRepository(BusBookingContext context)
        {
            _context = context;
        }

        public async Task<List<ScheduleDto>> SearchSchedulesAsync(string source, string destination, DateTime travelDate)
        {
            var schedules = await (from s in _context.Schedules
                                   join b in _context.Buses on s.BusId equals b.Id
                                   join r in _context.Routes on s.RouteId equals r.Id
                                   where r.Source == source && r.Destination == destination && s.TravelDate == travelDate
                                   select new ScheduleDto
                                   {
                                       ScheduleId = s.Id,
                                       BusNumber = b.BusNumber,
                                       BusType = b.BusType,
                                       Source = r.Source,
                                       Destination = r.Destination,
                                       DepartureTime = s.DepartureTime,
                                       ArrivalTime = s.ArrivalTime,
                                       Fare = s.Fare,
                                       AvailableSeats = _context.SeatLayouts.Count(sl => sl.ScheduleId == s.Id && sl.IsAvailable)
                                   }).ToListAsync();
            return schedules;
        }

        public async Task<List<SeatLayout>> GetSeatLayoutAsync(int scheduleId)
        {
            return await _context.SeatLayouts
                .Where(s => s.ScheduleId == scheduleId)
                .ToListAsync();
        }

        public async Task<ScheduleDto> GetScheduleDetailsAsync(int scheduleId)
        {
            return await (from s in _context.Schedules
                          join b in _context.Buses on s.BusId equals b.Id
                          join r in _context.Routes on s.RouteId equals r.Id
                          where s.Id == scheduleId
                          select new ScheduleDto
                          {
                              ScheduleId = s.Id,
                              BusNumber = b.BusNumber,
                              BusType = b.BusType,
                              Source = r.Source,
                              Destination = r.Destination,
                              DepartureTime = s.DepartureTime,
                              ArrivalTime = s.ArrivalTime,
                              Fare = s.Fare,
                              AvailableSeats = _context.SeatLayouts.Count(sl => sl.ScheduleId == s.Id && sl.IsAvailable)
                          }).FirstOrDefaultAsync();
        }
    }
}
