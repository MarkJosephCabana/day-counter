using DayCounter.Data.Calendar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Factories
{
    public interface IHolidayFactory
    {
        IHoliday Create();
    }
}
