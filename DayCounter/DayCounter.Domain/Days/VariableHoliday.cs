using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Domain.Days
{
    public class VariableHoliday : IVariableHoliday
    {
        public int id { get; set; }
        public string Name { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
    }
}
