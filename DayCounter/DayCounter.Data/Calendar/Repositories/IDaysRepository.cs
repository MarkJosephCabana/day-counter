using DayCounter.Data.Calendar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Repositories
{
    public interface IDaysRepository
    {
        IEnumerable<DayOfWeek> GetWeekends();
        IEnumerable<DateTime> GetSimpleHolidays();
        IEnumerable<IHoliday> GetHolidays();
    }
}
