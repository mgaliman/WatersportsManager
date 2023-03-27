using Microsoft.EntityFrameworkCore;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Application.TimeTypes.Models;

namespace WatersportsManager.Application.TimeTypes
{
    public class TimeTypeService : ITimeTypeService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public TimeTypeService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<TimeTypeDto>> GetTimeTypes(CancellationToken token)
        {
            return await _dbContext.TimeTypes.AsNoTracking()
               .Select(timeType => new TimeTypeDto
               {
                   Id = timeType.Id,
                   Type = timeType.Type
               })
               .ToListAsync(token);
        }

        public async Task<bool> TimeTypeExists(int id, CancellationToken token)
        {
            return await _dbContext.TimeTypes.Where(timeType => timeType.Id == id).AnyAsync(token);
        }
    }
}