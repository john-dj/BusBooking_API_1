namespace BusBooking_API.DTOs
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }
        public string BusNumber { get; set; }
        public string BusType { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Fare { get; set; }
        public int AvailableSeats { get; set; }
    }
}
