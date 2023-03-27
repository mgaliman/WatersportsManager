#nullable disable warnings

using Microsoft.EntityFrameworkCore;
using WatersportsManager.Application.BoatTypes.Models;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.BoatTypes
{
    public class BoatTypeService : IBoatTypeService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public BoatTypeService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<BoatTypeDto>> GetBoatTypes(CancellationToken token)
        {
            return await _dbContext.BoatTypes.AsNoTracking()
               .Select(boatType => new BoatTypeDto
               {
                   Id = boatType.Id,
                   Name = boatType.Name,
                   Registration = boatType.Registration,
                   Length = boatType.Length,
                   MaxCapacity = boatType.MaxCapacity,
                   HorsePower = boatType.HorsePower,
                   FuelPercentage = boatType.FuelPercentage,
                   LifeJackets = boatType.LifeJackets,
                   IsFunctional = boatType.IsFunctional,
                   Price = boatType.Price.Value.ToString()
               })
               .ToListAsync(token);
        }

        public async Task<BoatTypeDto> GetBoatTypeById(int id, CancellationToken token)
        {
            return await _dbContext.BoatTypes.Where(boatType => boatType.Id == id)
               .Select(boatType => new BoatTypeDto
               {
                   Id = boatType.Id,
                   Name = boatType.Name,
                   Registration = boatType.Registration,
                   Length = boatType.Length,
                   MaxCapacity = boatType.MaxCapacity,
                   HorsePower = boatType.HorsePower,
                   FuelPercentage = boatType.FuelPercentage,
                   LifeJackets = boatType.LifeJackets,
                   IsFunctional = boatType.IsFunctional,
                   Price = boatType.Price.Value.ToString()
               })
               .FirstOrDefaultAsync(token);
        }

        public async Task<int> CreateBoatType(CreateBoatTypeDto boatType, CancellationToken token)
        {
            ArgumentNullException.ThrowIfNull(boatType, nameof(boatType));

            BoatType boatTypeToCreate = new()
            {
                Name = boatType.Name,
                Registration = boatType.Registration,
                Length = boatType.Length,
                MaxCapacity = boatType.MaxCapacity,
                HorsePower = boatType.HorsePower,
                FuelPercentage = boatType.FuelPercentage,
                LifeJackets = boatType.LifeJackets,
                IsFunctional = boatType.IsFunctional,
                PriceId = boatType.PriceId
            };

            _dbContext.Add(boatTypeToCreate);

            await _dbContext.SaveChangesAsync(token);

            return boatTypeToCreate.Id;
        }

        public async Task UpdateBoatType(UpdateBoatTypeDto boatType, CancellationToken token)
        {
            BoatType boatTypeToUpdate = await _dbContext.BoatTypes.FindAsync(new object[] { boatType.Id }, cancellationToken: token);

            boatTypeToUpdate.Name = boatType.Name;
            boatTypeToUpdate.Registration = boatType.Registration;
            boatTypeToUpdate.Length = boatType.Length;
            boatTypeToUpdate.MaxCapacity = boatType.MaxCapacity;
            boatTypeToUpdate.HorsePower = boatType.HorsePower;
            boatTypeToUpdate.FuelPercentage = boatType.FuelPercentage;
            boatTypeToUpdate.LifeJackets = boatType.LifeJackets;
            boatTypeToUpdate.IsFunctional = boatType.IsFunctional;
            boatTypeToUpdate.PriceId = boatType.PriceId;

            await _dbContext.SaveChangesAsync(token);
        }

        public async Task<bool> DeleteBoatType(int id, CancellationToken token)
        {
            BoatType boatTypeToDelete = await _dbContext.BoatTypes.Where(boatType => boatType.Id == id).FirstOrDefaultAsync(token);
            if (boatTypeToDelete is null)
                return false;

            _dbContext.BoatTypes.Remove(boatTypeToDelete);
            await _dbContext.SaveChangesAsync(token);

            return true;
        }

        public async Task<bool> BoatTypeExists(int id, CancellationToken token)
        {
            return await _dbContext.BoatTypes.Where(boatType => boatType.Id == id).AnyAsync(token);
        }
    }
}
