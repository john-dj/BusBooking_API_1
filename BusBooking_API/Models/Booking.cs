namespace BusBooking_API.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ScheduleId { get; set; }
        public int NoOfSeats { get; set; }
        public decimal TotalFare { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
