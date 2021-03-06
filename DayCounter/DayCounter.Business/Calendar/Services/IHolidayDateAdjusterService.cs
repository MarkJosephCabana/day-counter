using DayCounter.Data.Calendar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Calendar.Services
{
    public interface IHolidayDateAdjusterService
    {
        IHoliday AdjustHolidayDate(IHoliday holiday);
    }
}
