using FluentValidation;
using WatersportsManager.Application.People;
using WatersportsManager.Application.PriorityTypes;
using WatersportsManager.Application.Reports.Models;

namespace WatersportsManager.Application.Reports.Validators
{
    public class CreateReportValidator : AbstractValidator<CreateReportDto>
    {
        public CreateReportValidator(IPersonService personService, IPriorityTypeService priorityTypeService)
        {
            RuleFor(person => person.Title).NotEmpty().MaximumLength(100);
            RuleFor(person => person.Description).NotEmpty().MaximumLength(2000);
            RuleFor(person => person.PersonId).MustAsync(personService.PersonExists)
                .WithMessage(person => $"Person with id '{person.PersonId}' does not exist");
            RuleFor(priorityType => priorityType.PriorityTypeId).MustAsync(priorityTypeService.PriorityTypeExists)
                .WithMessage(priorityType => $"PriorityType with id '{priorityType.PriorityTypeId}' does not exist");
        }
    }
}
