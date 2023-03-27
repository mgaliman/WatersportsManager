#nullable disable warnings

using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FluentValidation.Results;

namespace WatersportsManager.API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        private readonly IServiceProvider _serviceProvider;
        public ValidationFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            foreach (var actionArgument in context.ActionArguments)
            {
                Type actionArgumentType = actionArgument.Value?.GetType();
                if (actionArgumentType is null)
                    continue;

                Type paramValidatorType = typeof(IValidator<>).MakeGenericType(actionArgumentType);
                IValidator validator = (IValidator)_serviceProvider.GetService(paramValidatorType);
                if (validator is null)
                    continue;

                IValidationContext validationContext = (IValidationContext)Activator.CreateInstance(typeof(ValidationContext<>).MakeGenericType(actionArgumentType), actionArgument.Value);
                ValidationResult validationResult = await validator.ValidateAsync(validationContext);
                if (!validationResult.IsValid)
                {
                    var validationErrorsDictionary = validationResult.ToDictionary();
                    ValidationProblemDetails problemDetails = new(validationErrorsDictionary)
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                    };
                    problemDetails.Extensions.Add("traceId", Activity.Current?.Id ?? context.HttpContext.TraceIdentifier);
                    context.Result = new BadRequestObjectResult(problemDetails);
                    return;
                }
            }
            await next();
        }
    }
}
