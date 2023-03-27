using Microsoft.EntityFrameworkCore;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Application.Prices.Models;

namespace WatersportsManager.Application.Prices
{
    public class PriceService : IPriceService
    {
        private readonly WatersportsManagerDbContext _dbContext;
        public PriceService(WatersportsManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<PriceDto>> GetPrices(CancellationToken token)
        {
            return await _dbContext.Prices.AsNoTracking()
               .Select(price => new PriceDto
               {
                   Id = price.Id,
                   Value = price.Value,
                   TimeType = price.TimeType.Type
               })
               .ToListAsync(token);
        }

        public async Task<bool> PriceExists(int id, CancellationToken token)
        {
            return await _dbContext.Prices.Where(price => price.Id == id).AnyAsync(token);
        }
    }
}
