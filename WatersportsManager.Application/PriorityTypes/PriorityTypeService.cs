using Microsoft.EntityFrameworkCore;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Application.PriorityTypes.Models;

namespace WatersportsManager.Application.PriorityTypes
{
    public class PriorityTypeService : IPriorityTypeService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public PriorityTypeService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<PriorityTypeDto>> GetPriorityTypes(CancellationToken token)
        {
            return await _dbContext.PriorityTpes.AsNoTracking()
               .Select(priorityType => new PriorityTypeDto
               {
                   Id = priorityType.Id,
                   Type = priorityType.Type
               })
               .ToListAsync(token);
        }

        public async Task<bool> PriorityTypeExists(int id, CancellationToken token)
        {
            return await _dbContext.PriorityTpes.Where(priorityType => priorityType.Id == id).AnyAsync(token);
        }
    }
}
