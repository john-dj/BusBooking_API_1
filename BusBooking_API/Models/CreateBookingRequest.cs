namespace BusBooking_API.Models
{
    public class CreateBookingRequest
    {
        public int ScheduleId { get; set; }
        public int NoOfSeats { get; set; }
        public decimal TotalFare { get; set; }
    }
}
