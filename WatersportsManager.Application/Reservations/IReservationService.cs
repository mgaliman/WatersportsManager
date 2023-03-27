using WatersportsManager.Application.Reservations.Models;

namespace WatersportsManager.Application.Reservations
{
    public interface IReservationService
    {
        public Task<IReadOnlyList<ReservationDto>> GetReservations(CancellationToken token);
        public Task<ReservationDto> GetReservationById(int id, CancellationToken token);
        public Task<int> CreateReservation(CreateReservationDto boat, CancellationToken token);
        public Task UpdateReservation(UpdateReservationDto boat, CancellationToken token);
        public Task<bool> DeleteReservation(int id, CancellationToken token);
        public Task<bool> ReservationExists(int id, CancellationToken token);
    }
}
