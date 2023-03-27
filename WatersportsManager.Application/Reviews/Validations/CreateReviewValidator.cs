using FluentValidation;
using WatersportsManager.Application.Reviews.Models;

namespace WatersportsManager.Application.Reviews.Validations
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewValidator()
        {
            RuleFor(person => person.Name).NotEmpty().MaximumLength(100);
            RuleFor(person => person.Description).NotEmpty().MaximumLength(2000);
            RuleFor(person => person.Star).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(5);
            RuleFor(person => person.Date).NotEmpty();
        }
    }
}
