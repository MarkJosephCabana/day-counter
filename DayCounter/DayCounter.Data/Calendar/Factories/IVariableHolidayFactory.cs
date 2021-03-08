using DayCounter.Data.Calendar.Entities;
using DayCounter.Shared.DependencyResolution;
using System;

namespace DayCounter.Data.Calendar.Factories
{
    public interface IVariableHolidayFactory : IService
    {
        IVariableHoliday Create();
        IVariableHoliday Create(int id, DayOfWeek dayOfWeek, bool isAdjustable, int month, string name, int nth);
    }
}
