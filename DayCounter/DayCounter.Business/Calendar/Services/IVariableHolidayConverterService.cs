using DayCounter.Data.Calendar.Entities;

namespace DayCounter.Business.Calendar.Adapters
{
    public interface IVariableHolidayConverterService
    {
        IHoliday GetHoliday(IVariableHoliday variableHoliday, int year);
    }
}
