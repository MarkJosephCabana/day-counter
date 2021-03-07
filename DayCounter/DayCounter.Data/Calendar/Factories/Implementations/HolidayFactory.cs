using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Entities.Implementations;
using System;

namespace DayCounter.Data.Calendar.Factories.Implementations
{
    public class HolidayFactory : IHolidayFactory
    {
        public IHoliday Create()
        {
            return new Holiday();
        }

        public IHoliday Create(int id, string name, DateTime date, bool isAdjustable)
        {
            return new Holiday { 
                Id = id,
                Name = name,
                HolidayDate = date,
                IsAdjustable = isAdjustable
            };
        }
    }
}
