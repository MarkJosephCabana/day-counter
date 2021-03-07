using DayCounter.Business.Calendar.Models;
using System;
using System.Collections.Generic;

namespace DayCounter.Business.Calendar.Services
{
    public interface IBusinessDayCounterService
    {
        int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);
        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<IHolidayModel> publicHolidays);
    }
}
