using Microsoft.AspNetCore.Mvc;
using WatersportsManager.Application.BoatTypes;
using WatersportsManager.Application.BoatTypes.Models;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoatTypeController : Controller
    {
        private readonly IBoatTypeService _boatTypeService;

        public BoatTypeController(IBoatTypeService boatTypeService)
        {
            _boatTypeService = boatTypeService;
        }

        [HttpGet(Name = nameof(GetBoatTypes))]
        public async Task<IReadOnlyList<BoatTypeDto>> GetBoatTypes(CancellationToken cancellationToken)
        {
            return await _boatTypeService.GetBoatTypes(cancellationToken);
        }

        [HttpGet("{id}", Name = nameof(GetBoatType))]
        public async Task<IActionResult> GetBoatType([FromRoute] int id, CancellationToken cancellationToken)
        {
            BoatTypeDto boatType = await _boatTypeService.GetBoatTypeById(id, cancellationToken);

            return boatType is not null ? Ok(boatType) : NotFound();
        }

        [HttpPost(Name = nameof(CreateBoatType))]
        public async Task<IActionResult> CreateBoatType([FromBody] CreateBoatTypeDto model, CancellationToken cancellationToken)
        {
            int boatTypeId = await _boatTypeService.CreateBoatType(model, cancellationToken);

            return CreatedAtAction(nameof(CreateBoatType), new { Id = boatTypeId });
        }

        [HttpPut(Name = nameof(UpdateBoatType))]
        public async Task<IActionResult> UpdateBoatType([FromBody] UpdateBoatTypeDto model, CancellationToken cancellationToken)
        {
            await _boatTypeService.UpdateBoatType(model, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteBoatType))]
        public async Task<IActionResult> DeleteBoatType([FromRoute] int id, CancellationToken cancellationToken)
        {
            bool boatTypeDeleted = await _boatTypeService.DeleteBoatType(id, cancellationToken);

            return boatTypeDeleted ? NoContent() : NotFound();
        }
    }
}
