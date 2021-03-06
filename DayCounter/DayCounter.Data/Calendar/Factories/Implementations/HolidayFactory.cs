using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Entities.Implementations;

namespace DayCounter.Data.Calendar.Factories.Implementations
{
    public class HolidayFactory : IHolidayFactory
    {
        public IHoliday Create()
        {
            return new Holiday();
        }
    }
}
