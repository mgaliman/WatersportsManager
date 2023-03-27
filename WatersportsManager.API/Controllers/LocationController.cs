using Microsoft.AspNetCore.Mvc;
using WatersportsManager.Application.Locations;
using WatersportsManager.Application.Locations.Models;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet(Name = nameof(GetLocations))]
        public async Task<IReadOnlyList<LocationDto>> GetLocations(CancellationToken cancellationToken)
        {
            return await _locationService.GetLocations(cancellationToken);
        }
    }
}
