#nullable disable warnings

using WatersportsManager.Domain.Base;

namespace WatersportsManager.Domain
{
    public class Location : BaseEntity
    {
        public string City { get; set; }
        public string Camp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ICollection<Person> People { get; set; } = new List<Person>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
