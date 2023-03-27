using FluentValidation;
using WatersportsManager.Application.BoatTypes.Models;

namespace WatersportsManager.Application.BoatTypes.Validators
{
    public class CreateBoatTypeValidator : AbstractValidator<CreateBoatTypeDto>
    {
        public CreateBoatTypeValidator()
        {
            RuleFor(boatType => boatType.Name).NotEmpty().MaximumLength(100);
        }
    }
}
