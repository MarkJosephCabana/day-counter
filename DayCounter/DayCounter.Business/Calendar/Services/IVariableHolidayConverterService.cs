using DayCounter.Business.Calendar.Models;
using DayCounter.Data.Calendar.Entities;

namespace DayCounter.Business.Calendar.Services
{
    public interface IVariableHolidayConverterService
    {
        IHolidayModel GetHoliday(IVariableHoliday variableHoliday, int year);
    }
}
