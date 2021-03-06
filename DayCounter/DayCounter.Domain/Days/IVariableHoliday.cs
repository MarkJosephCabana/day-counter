using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Domain.Days
{
    public interface IVariableHoliday
    {
        int id { get; set; }
        string Name { get; set; }
        DayOfWeek DayOfWeek { get; set; }
        int Day { get; set; }
        int Month { get; set; }
    }
}
