#nullable disable warnings

namespace WatersportsManager.Application.Reservations.Models
{
    public class CreateReservationDto
    {
        public int PersonId { get; set; }
        public int BoatTypeId { get; set; }
        public int LocationId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
    }
}
