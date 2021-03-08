using DayCounter.Data.Calendar.Entities;
using DayCounter.Shared.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Factories
{
    public interface IHolidayFactory : IService
    {
        IHoliday Create();
        IHoliday Create(int id, string name, DateTime date, bool isAdjustable);
    }
}
