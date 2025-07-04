using static System.Net.Mime.MediaTypeNames;

namespace BusBooking_API.Models
{
    public class Buses
    {
        public int Id { get; set; }
        public string BusNumber { get; set; }
        public string BusType { get; set; }
    }
}
