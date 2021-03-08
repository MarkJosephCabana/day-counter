using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Entities.Implementations;
using System;

namespace DayCounter.Data.Calendar.Factories.Implementations
{
    public class VariableHolidayFactory : IVariableHolidayFactory
    {
        public IVariableHoliday Create()
        {
            return new VariableHoliday();
        }

        public IVariableHoliday Create(int id, DayOfWeek dayOfWeek, bool isAdjustable, int month, string name, int nth)
        {
            return new VariableHoliday { 
                id = id,
                DayOfWeek = dayOfWeek,
                IsAdjustable = isAdjustable,
                Month = month,
                Name = name,
                Nth = nth
            };
        }
    }
}
