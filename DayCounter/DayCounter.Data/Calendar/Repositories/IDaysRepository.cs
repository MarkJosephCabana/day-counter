using DayCounter.Data.Calendar.Entities;
using DayCounter.Shared.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Repositories
{
    public interface IDaysRepository: IService
    {
        IEnumerable<DayOfWeek> GetWeekends();
        IEnumerable<DateTime> GetSimpleHolidays();
        IEnumerable<IHoliday> GetHolidays();
        IEnumerable<IVariableHoliday> GetVariableHolidays();
    }
}
