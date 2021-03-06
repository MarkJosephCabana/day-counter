using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayCounter.Business.Calendar.Services.Implementations
{
    public class HolidayDateAdjusterService : IHolidayDateAdjusterService
    {
        private readonly IDaysRepository _DaysRepository;

        public HolidayDateAdjusterService(IDaysRepository daysRepository)
        {
            _DaysRepository = daysRepository;
        }

        public IHoliday AdjustHolidayDate(IHoliday holiday)
        {
            if(holiday?.IsAdjustable ?? false)
            {
                var weekends = _DaysRepository.GetWeekends();

                while (weekends.Contains(holiday.HolidayDate.DayOfWeek))
                {
                    holiday.HolidayDate = holiday.HolidayDate.AddDays(1);
                }
            }

            return holiday;
        }
    }
}
