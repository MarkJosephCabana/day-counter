using DayCounter.Business.Calendar.Models;
using DayCounter.Shared.DependencyResolution;

namespace DayCounter.Business.Calendar.Services
{
    public interface IHolidayDateAdjusterService : IService
    {
        IHolidayModel AdjustHolidayDate(IHolidayModel holiday);
    }
}
