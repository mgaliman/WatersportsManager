#nullable disable warnings

namespace WatersportsManager.Application.Reservations.Models
{
    public class UpdateReservationDto : CreateReservationDto
    {
        public int Id { get; set; }
    }
}
