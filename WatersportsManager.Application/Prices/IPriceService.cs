using WatersportsManager.Application.Prices.Models;

namespace WatersportsManager.Application.Prices
{
    public interface IPriceService
    {
        public Task<IReadOnlyList<PriceDto>> GetPrices(CancellationToken token);
        public Task<bool> PriceExists(int id, CancellationToken token);
    }
}
