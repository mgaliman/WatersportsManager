using Microsoft.AspNetCore.Mvc;
using WatersportsManager.Application.TimeTypes;
using WatersportsManager.Application.TimeTypes.Models;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeTypeController : Controller
    {
        private readonly ITimeTypeService _timeTypeService;
        public TimeTypeController(ITimeTypeService timeTypeService)
        {
            _timeTypeService = timeTypeService;
        }

        [HttpGet(Name = nameof(GetTimeTypes))]
        public async Task<IReadOnlyList<TimeTypeDto>> GetTimeTypes(CancellationToken cancellationToken)
        {
            return await _timeTypeService.GetTimeTypes(cancellationToken);
        }
    }
}
