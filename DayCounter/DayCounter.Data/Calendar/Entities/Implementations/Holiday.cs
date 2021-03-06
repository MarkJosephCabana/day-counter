using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Entities.Implementations
{
    public class Holiday : IHoliday
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HolidayDate { get; set; }
        public bool IsAdjustable { get; set; }
    }
}
