using FluentValidation;
using WatersportsManager.Application.BoatTypes.Models;

namespace WatersportsManager.Application.BoatTypes.Validators
{
    public class UpdateBoatTypeValidator : AbstractValidator<UpdateBoatTypeDto>
    {
        public UpdateBoatTypeValidator(IBoatTypeService boatTypeService)
        {
            RuleFor(boatType => boatType.Id).MustAsync(boatTypeService.BoatTypeExists)
               .WithMessage(boatType => $"BoatType with id '{boatType.Id}' does not exist");
            RuleFor(boatType => boatType.Name).NotEmpty().MaximumLength(100);
        }
    }
}
