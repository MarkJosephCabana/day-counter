using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Entities
{
    public interface ISpecialHoliday
    {
        bool IsAdjustable { get; set; }
    }
}
