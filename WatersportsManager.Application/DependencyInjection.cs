using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WatersportsManager.Application.Reservations;
using WatersportsManager.Application.BoatTypes;
using WatersportsManager.Application.BoatTypes.Models;
using WatersportsManager.Application.BoatTypes.Validators;
using WatersportsManager.Application.Locations;
using WatersportsManager.Application.People;
using WatersportsManager.Application.People.Models;
using WatersportsManager.Application.People.Validators;
using WatersportsManager.Application.Persistence;
using WatersportsManager.Application.Prices;
using WatersportsManager.Application.PriorityTypes;
using WatersportsManager.Application.Reports;
using WatersportsManager.Application.Reports.Models;
using WatersportsManager.Application.Reports.Validators;
using WatersportsManager.Application.Reviews;
using WatersportsManager.Application.Reviews.Models;
using WatersportsManager.Application.Reviews.Validations;
using WatersportsManager.Application.Roles;
using WatersportsManager.Application.TimeTypes;
using WatersportsManager.Application.Reservations.Models;
using WatersportsManager.Application.Reservations.Validators;

namespace WatersportsManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //Services
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ITimeTypeService, TimeTypeService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IBoatTypeService, BoatTypeService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IPriorityTypeService, PriorityTypeService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IReviewService, ReviewService>();

            //Validators
            services.AddScoped<IValidator<CreatePersonDto>, CreatePersonValidator>();
            services.AddScoped<IValidator<UpdatePersonDto>, UpdatePersonValidator>();
            services.AddScoped<IValidator<CreateReservationDto>, CreateReservationValidator>();
            services.AddScoped<IValidator<UpdateReservationDto>, UpdateReservationValidator>();
            services.AddScoped<IValidator<CreateBoatTypeDto>, CreateBoatTypeValidator>();
            services.AddScoped<IValidator<UpdateBoatTypeDto>, UpdateBoatTypeValidator>();
            services.AddScoped<IValidator<CreateReportDto>, CreateReportValidator>();
            services.AddScoped<IValidator<UpdateReportDto>, UpdateReportValidator>();
            services.AddScoped<IValidator<CreateReviewDto>, CreateReviewValidator>();
            services.AddScoped<IValidator<UpdateReviewDto>, UpdateReviewValidator>();

            services.AddDbContext<WatersportsManagerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("WatersportsManagerDb"));
            });

            return services;
        }
    }
}
