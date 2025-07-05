using BusBooking_API.DTOs;
using BusBooking_API.Models;
using BusBooking_API.Repos.Interface;
using BusBooking_API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking_API.Services.Repository
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repository;

        public BookingService(IBookingRepository repository) => _repository = repository;

        public async Task<BookingResponse> BookSeatsAsync(int userId, CreateBookingRequest request)
        {
            if (!await _repository.AreSeatsAvailableAsync(request.ScheduleId, request.SeatNumbers))
                throw new Exception("One or more seats are already booked.");

            var farePerSeat = await _repository.GetFarePerSeatAsync(request.ScheduleId);
            var totalFare = farePerSeat * request.SeatNumbers.Count;

            var booking = new Booking
            {
                UserId = userId,
                ScheduleId = request.ScheduleId,
                BookingDate = DateTime.UtcNow,
                TotalFare = totalFare,
                NoOfSeats = request.SeatNumbers.Count,
                BookedSeats = request.SeatNumbers.Select(seat => new BookedSeat
                {
                    SeatNumber = seat
                }).ToList()
            };

            var bookingId = await _repository.CreateBookingAsync(booking);
            await _repository.BlockSeatsAsync(request.ScheduleId, request.SeatNumbers);

            return new BookingResponse
            {
                BookingId = bookingId,
                TotalFare = totalFare,
                BookedSeats = request.SeatNumbers
            };
        }

        public async Task<List<SeatLayout>> FetchSeatLayoutAsync(int scheduleId) =>
            await _repository.GetSeatLayoutAsync(scheduleId);
    }
}
