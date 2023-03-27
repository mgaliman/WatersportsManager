using Microsoft.AspNetCore.Mvc;
using WatersportsManager.Application.Prices;
using WatersportsManager.Application.Prices.Models;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceController : Controller
    {
        private readonly IPriceService _priceService;
        public PriceController(IPriceService priceService)
        {
            _priceService = priceService;
        }
        [HttpGet(Name = nameof(GetPrices))]
        public async Task<IReadOnlyList<PriceDto>> GetPrices(CancellationToken cancellationToken)
        {
            return await _priceService.GetPrices(cancellationToken);
        }
    }
}
