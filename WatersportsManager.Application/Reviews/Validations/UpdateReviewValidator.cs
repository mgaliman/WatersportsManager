using FluentValidation;
using WatersportsManager.Application.People;
using WatersportsManager.Application.Reviews.Models;

namespace WatersportsManager.Application.Reviews.Validations
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewDto>
    {
        public UpdateReviewValidator(IReviewService reviewService)
        {
            RuleFor(review => review.Id).MustAsync(reviewService.ReviewExists)
                .WithMessage(review => $"Review with id '{review.Id}' does not exist");
            RuleFor(person => person.Name).NotEmpty().MaximumLength(100);
            RuleFor(person => person.Description).NotEmpty().MaximumLength(2000);
            RuleFor(person => person.Star).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(5);
            RuleFor(person => person.Date).NotEmpty();
        }
    }
}
