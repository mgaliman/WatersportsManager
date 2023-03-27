using FluentValidation;
using WatersportsManager.Application.BoatTypes;
using WatersportsManager.Application.Locations;
using WatersportsManager.Application.People;
using WatersportsManager.Application.Reservations.Models;

namespace WatersportsManager.Application.Reservations.Validators
{
    public class UpdateReservationValidator : AbstractValidator<UpdateReservationDto>
    {
        public UpdateReservationValidator(IReservationService reservationService, IPersonService personService, IBoatTypeService boatTypeService, ILocationService locationService)
        {
            RuleFor(boat => boat.Id).MustAsync(reservationService.ReservationExists)
                .WithMessage(boat => $"Boat with id '{boat.Id}' does not exist");
            RuleFor(person => person.PersonId).MustAsync(personService.PersonExists)
                .WithMessage(person => $"Person with id '{person.PersonId}' does not exist");
            RuleFor(boatType => boatType.BoatTypeId).MustAsync(boatTypeService.BoatTypeExists)
                .WithMessage(boatType => $"BoatType with id '{boatType.BoatTypeId}' does not exist");
            RuleFor(location => location.LocationId).MustAsync(locationService.LocationExists)
                .WithMessage(location => $"Location with id '{location.LocationId}' does not exist");
            RuleFor(reservation => reservation.Date).NotEmpty();
        }
    }
}
