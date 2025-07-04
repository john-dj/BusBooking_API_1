namespace BusBooking_API.Models
{
    public class SeatLayout
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public string SeatNumber { get; set; }
        public bool IsAvailable { get; set; }
    }
}
