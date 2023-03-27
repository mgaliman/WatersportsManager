using FluentValidation;
using WatersportsManager.Application.People.Models;
using WatersportsManager.Application.Roles;

namespace WatersportsManager.Application.People.Validators
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonDto>
    {
        public CreatePersonValidator(IRoleService roleService)
        {
            RuleFor(person => person.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(person => person.LastName).NotEmpty().MaximumLength(50);
            RuleFor(person => person.LastName).NotEmpty().MaximumLength(50);
        }
    }
}
