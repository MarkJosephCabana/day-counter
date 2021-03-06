using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Entities.Implementations;

namespace DayCounter.Data.Calendar.Factories.Implementations
{
    public class VariableHolidayFactory : IVariableHolidayFactory
    {
        public IVariableHoliday Create()
        {
            return new VariableHoliday();
        }
    }
}
