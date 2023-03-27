#nullable disable warnings

namespace WatersportsManager.Application.Locations.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Camp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
