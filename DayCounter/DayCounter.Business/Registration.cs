using DayCounter.Business.Calendar.Services;
using DayCounter.Data.Calendar.Repositories;
using DayCounter.Shared.DependencyResolution;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace DayCounter.Business
{
    public static class Registration
    {
        public static void RegisterBusiness(this IServiceCollection service)
        {
            service.AutoRegisterServices<IService>(typeof(IBusinessDayCounterService).Assembly)
                .AutoRegisterServices<IService>(typeof(IDaysRepository).Assembly);
        }

        private static IServiceCollection AutoRegisterServices<TServiceInterface>(this IServiceCollection services, Assembly assembly)
        { 
            var servicesToRegister = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(TServiceInterface).IsAssignableFrom(t))
                .ToList();

            foreach (var s in servicesToRegister)
            {
                var interfaces = s.GetInterfaces().Where(t => t != typeof(TServiceInterface)).ToList();
                foreach (var i in interfaces)
                {
                    services.AddTransient(i, s);
                }
            }

            return services;
        }
    }
}
