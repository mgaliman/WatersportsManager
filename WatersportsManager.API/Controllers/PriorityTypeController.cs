using Microsoft.AspNetCore.Mvc;
using WatersportsManager.Application.PriorityTypes.Models;
using WatersportsManager.Application.PriorityTypes;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriorityTypeController : Controller
    {
        private readonly IPriorityTypeService _priorityTypeService;
        public PriorityTypeController(IPriorityTypeService priorityTypeService)
        {
            _priorityTypeService = priorityTypeService;
        }

        [HttpGet(Name = nameof(GetPriorityTypes))]
        public async Task<IReadOnlyList<PriorityTypeDto>> GetPriorityTypes(CancellationToken cancellationToken)
        {
            return await _priorityTypeService.GetPriorityTypes(cancellationToken);
        }
    }
}
