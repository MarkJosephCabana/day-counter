using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Entities
{
    public interface IVariableHoliday : ISpecialHoliday
    {
        int id { get; set; }
        string Name { get; set; }
        DayOfWeek DayOfWeek { get; set; }
        int Nth { get; set; }
        int Month { get; set; }
    }
}
