using DayCounter.Data.Calendar.Entities;

namespace DayCounter.Business.Calendar.Services
{
    public interface IVariableHolidayConverterService
    {
        IHoliday GetHoliday(IVariableHoliday variableHoliday, int year);
    }
}
