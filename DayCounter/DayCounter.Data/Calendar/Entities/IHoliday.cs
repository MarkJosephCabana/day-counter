using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Entities
{
    public interface IHoliday : ISpecialHoliday
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime HolidayDate { get; set; }
    }
}
