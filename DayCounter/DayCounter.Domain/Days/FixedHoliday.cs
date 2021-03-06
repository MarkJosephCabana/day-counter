using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Domain.Days
{
    public class FixedHoliday : IHoliday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HolidayDate { get; set; }
    }
}
