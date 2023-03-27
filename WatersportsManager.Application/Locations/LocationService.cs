using Microsoft.EntityFrameworkCore;
using WatersportsManager.Application.Locations.Models;
using WatersportsManager.Application.Persistence;

namespace WatersportsManager.Application.Locations
{
    public class LocationService : ILocationService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public LocationService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<LocationDto>> GetLocations(CancellationToken token)
        {
            return await _dbContext.Locations.AsNoTracking()
               .Select(location => new LocationDto
               {
                   Id = location.Id,
                   City = location.City,
                   Camp = location.Camp,
                   Latitude = location.Latitude,
                   Longitude = location.Longitude,
               })
               .ToListAsync(token);
        }

        public async Task<bool> LocationExists(int id, CancellationToken token)
        {
            return await _dbContext.Locations.Where(location => location.Id == id).AnyAsync(token);
        }
    }
}
