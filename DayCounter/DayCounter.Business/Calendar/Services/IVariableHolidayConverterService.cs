using DayCounter.Business.Calendar.Models;
using DayCounter.Data.Calendar.Entities;
using DayCounter.Shared.DependencyResolution;

namespace DayCounter.Business.Calendar.Services
{
    public interface IVariableHolidayConverterService : IService
    {
        IHolidayModel GetHoliday(IVariableHoliday variableHoliday, int year);
    }
}
