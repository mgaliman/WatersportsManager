#nullable disable warnings

namespace WatersportsManager.Application.Reservations.Models
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string BoatType { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
    }
}
