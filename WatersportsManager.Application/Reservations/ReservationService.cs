#nullable disable warnings

using Microsoft.EntityFrameworkCore;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Application.Reservations.Models;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public ReservationService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<ReservationDto>> GetReservations(CancellationToken token)
        {
            return await _dbContext.Reservations.AsNoTracking()
               .Select(reservation => new ReservationDto
               {
                   Id = reservation.Id,
                   Person = reservation.Person.ToString(),
                   BoatType = reservation.BoatType.Name,
                   Location = reservation.Location.Camp,
                   Date = reservation.Date,
                   IsPaid = reservation.IsPaid
               })
               .ToListAsync(token);
        }

        public async Task<ReservationDto> GetReservationById(int id, CancellationToken token)
        {
            return await _dbContext.Reservations.Where(reservation => reservation.Id == id)
               .Select(reservation => new ReservationDto
               {
                   Id = reservation.Id,
                   Person = reservation.Person.ToString(),
                   BoatType = reservation.BoatType.Name,
                   Location = reservation.Location.Camp,
                   Date = reservation.Date,
                   IsPaid = reservation.IsPaid
               })
               .FirstOrDefaultAsync(token);
        }

        public async Task<int> CreateReservation(CreateReservationDto reservation, CancellationToken token)
        {
            ArgumentNullException.ThrowIfNull(reservation, nameof(reservation));

            Reservation reservationToCreate = new()
            {
                PersonId = reservation.PersonId,
                BoatTypeId = reservation.BoatTypeId,
                LocationId = reservation.LocationId,
                Date = reservation.Date,
                IsPaid = reservation.IsPaid
            };

            _dbContext.Add(reservationToCreate);

            await _dbContext.SaveChangesAsync(token);

            return reservationToCreate.Id;
        }

        public async Task UpdateReservation(UpdateReservationDto reservation, CancellationToken token)
        {
            Reservation reservationToUpdate = await _dbContext.Reservations.FindAsync(new object[] { reservation.Id }, cancellationToken: token);

            reservationToUpdate.PersonId = reservation.PersonId;
            reservationToUpdate.BoatTypeId = reservation.BoatTypeId;
            reservationToUpdate.LocationId = reservation.LocationId;
            reservationToUpdate.Date = reservation.Date;
            reservationToUpdate.IsPaid = reservation.IsPaid;

            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<bool> DeleteReservation(int id, CancellationToken token)
        {
            Reservation reservationToDelete = await _dbContext.Reservations.Where(reservation => reservation.Id == id).FirstOrDefaultAsync(token);
            if (reservationToDelete is null)
                return false;

            _dbContext.Reservations.Remove(reservationToDelete);
            await _dbContext.SaveChangesAsync(token);

            return true;
        }

        public async Task<bool> ReservationExists(int id, CancellationToken token)
        {
            return await _dbContext.Boats.Where(reservation => reservation.Id == id).AnyAsync(token);
        }
    }
}
