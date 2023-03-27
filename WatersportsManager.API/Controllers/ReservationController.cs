using Microsoft.AspNetCore.Mvc;
using WatersportsManager.Application.Reservations;
using WatersportsManager.Application.Reservations.Models;

namespace WatersportsManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet(Name = nameof(GetReservations))]
        public async Task<IReadOnlyList<ReservationDto>> GetReservations(CancellationToken cancellationToken)
        {
            return await _reservationService.GetReservations(cancellationToken);
        }

        [HttpGet("{id}", Name = nameof(GetReservation))]
        public async Task<IActionResult> GetReservation([FromRoute] int id, CancellationToken cancellationToken)
        {
            ReservationDto reservation = await _reservationService.GetReservationById(id, cancellationToken);

            return reservation is not null ? Ok(reservation) : NotFound();
        }

        [HttpPost(Name = nameof(CreateReservation))]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto model, CancellationToken cancellationToken)
        {
            int reservationId = await _reservationService.CreateReservation(model, cancellationToken);

            return CreatedAtAction(nameof(CreateReservation), new { Id = reservationId });
        }

        [HttpPut(Name = nameof(UpdateReservation))]
        public async Task<IActionResult> UpdateReservation([FromBody] UpdateReservationDto model, CancellationToken cancellationToken)
        {
            await _reservationService.UpdateReservation(model, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteReservation))]
        public async Task<IActionResult> DeleteReservation([FromRoute] int id, CancellationToken cancellationToken)
        {
            bool reservationDeleted = await _reservationService.DeleteReservation(id, cancellationToken);

            return reservationDeleted ? NoContent() : NotFound();
        }
    }
}
