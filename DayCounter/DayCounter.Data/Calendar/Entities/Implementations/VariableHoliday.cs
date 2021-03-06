using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Entities.Implementations
{
    public class VariableHoliday : IVariableHoliday
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Nth { get; set; }
        public int Month { get; set; }
        public bool IsAdjustable { get; set; }
    }
}
