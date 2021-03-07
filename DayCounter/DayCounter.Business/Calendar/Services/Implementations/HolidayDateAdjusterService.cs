using DayCounter.Business.Calendar.Models;
using DayCounter.Data.Calendar.Repositories;
using System;
using System.Linq;

namespace DayCounter.Business.Calendar.Services.Implementations
{
    public class HolidayDateAdjusterService : IHolidayDateAdjusterService
    {
        private readonly IDaysRepository _DaysRepository;

        public HolidayDateAdjusterService(IDaysRepository daysRepository)
        {
            _DaysRepository = daysRepository;
        }

        public IHolidayModel AdjustHolidayDate(IHolidayModel holiday)
        {
            if(holiday?.IsAdjustable ?? false)
            {
                var weekends = _DaysRepository.GetWeekends();

                while (weekends.Contains(holiday.Date.DayOfWeek))
                {
                    holiday.Date = holiday.Date.AddDays(1);
                }
            }

            return holiday;
        }
    }
}
