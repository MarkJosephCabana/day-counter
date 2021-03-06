using DayCounter.Data.Calendar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Calendar.Services
{
    public interface IBusinessDayCounterService
    {
        int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<IHoliday> publicHolidays);
    }
}
