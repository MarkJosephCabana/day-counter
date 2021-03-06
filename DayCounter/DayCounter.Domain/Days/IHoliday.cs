using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Domain.Days
{
    public interface IHoliday
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime HolidayDate { get; set; }
    }
}
