using DayCounter.Business.Calendar.Validators;
using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DayCounter.Business.Calendar.Services.Implementations
{
    public class BusinessDayCounterService : IBusinessDayCounterService
    {
        private readonly IDaysRepository _DaysRepository;
        private readonly IDatesValidator _DatesValidator;
        private readonly IHolidayDateAdjusterService _HolidayDateAdjusterService;

        public BusinessDayCounterService(IDatesValidator datesValidator, IDaysRepository daysRepository,
            IHolidayDateAdjusterService holidayDateAdjusterService)
        {
            _DatesValidator = datesValidator;
            _DaysRepository = daysRepository;
            _HolidayDateAdjusterService = holidayDateAdjusterService;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            int weekDays = 0;

            if(_DatesValidator.AreValidDate(firstDate, secondDate))
            {
                //Get the daysofweek that are considered as weekends
                var weekends = _DaysRepository.GetWeekends();

                //make sure the holidays has no/default time component
                publicHolidays = publicHolidays?.Any() ?? false ? publicHolidays.Select(d => d.Date).ToList() :
                    new List<DateTime>();

                int daysGap = (int)Math.Floor((secondDate - firstDate).TotalDays);
                weekDays = Enumerable.Range(1, daysGap - 1).Select(gap => firstDate.AddDays(gap))
                    .Where(date => !weekends.Contains(date.DayOfWeek) && !publicHolidays.Contains(date))
                    .Count();
            }

            return weekDays;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<IHoliday> publicHolidays)
        {
            var publicHolidayDates = publicHolidays?
                .Select(publicHoliday => _HolidayDateAdjusterService.AdjustHolidayDate(publicHoliday))
                .Where(publicHoliday => publicHoliday != null)
                .Select(publicHoliday => publicHoliday.HolidayDate)
                .ToList() ?? new List<DateTime>();

            return BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidayDates);
        }

        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
             => BusinessDaysBetweenTwoDates(firstDate, secondDate, new List<DateTime>());
    }
}
