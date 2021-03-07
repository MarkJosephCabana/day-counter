using DayCounter.Business.Calendar.Services;
using DayCounter.Business.Calendar.Services.Implementations;
using DayCounter.Business.Calendar.Validators;
using DayCounter.Business.Calendar.Validators.Implementations;
using DayCounter.Data.Calendar.Factories;
using DayCounter.Data.Calendar.Factories.Implementations;
using DayCounter.Data.Calendar.Repositories;
using DayCounter.Data.Calendar.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DayCounter.Business
{
    public static class Registration
    {
        public static void RegisterBusiness(this IServiceCollection service)
        {
            service.AddTransient<IBusinessDayCounterService, BusinessDayCounterService>();
            service.AddTransient<IHolidayDateAdjusterService, HolidayDateAdjusterService>();
            service.AddTransient<IVariableHolidayConverterService, VariableHolidayConverterService>();
            service.AddTransient<IDatesValidator, DatesValidator>();
            service.AddTransient<IHolidayFactory, HolidayFactory>();
            service.AddTransient<IVariableHolidayFactory, VariableHolidayFactory>();
            service.AddTransient<IDaysRepository, InMemoryDaysRepository>();
        }
    }
}
