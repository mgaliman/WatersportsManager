using FluentValidation;
using WatersportsManager.Application.People.Models;
using WatersportsManager.Application.Roles;

namespace WatersportsManager.Application.People.Validators
{
    public class UpdatePersonValidator : AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonValidator(IRoleService roleService, IPersonService personService)
        {
            RuleFor(person => person.Id).MustAsync(personService.PersonExists)
                .WithMessage(person => $"Person with id '{person.Id}' does not exist");
            RuleFor(person => person.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(person => person.LastName).NotEmpty().MaximumLength(50);
            RuleFor(person => person.LastName).NotEmpty().MaximumLength(50);
            RuleFor(role => role.RoleId).MustAsync(roleService.RoleExists)
                .WithMessage(role => $"Role with id '{role.RoleId}' does not exist");
        }
    }
}
