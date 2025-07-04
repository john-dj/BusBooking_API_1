namespace BusBooking_API.DTOs
{
    public class ScheduleSearchRequest
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime TravelDate { get; set; }
    }
}
