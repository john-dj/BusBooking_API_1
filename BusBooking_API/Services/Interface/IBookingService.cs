using BusBooking_API.DTOs;
using BusBooking_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBooking_API.Services.Interface
{
    public interface IBookingService
    {
        Task<BookingResponse> BookSeatsAsync(int userId, CreateBookingRequest request);
        Task<List<SeatLayout>> FetchSeatLayoutAsync(int scheduleId);
    }
}
