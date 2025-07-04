namespace BusBooking_API.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime TravelDate { get; set; }
        public decimal Fare { get; set; }
        public int TotalSeats { get; set; }
    }
}
