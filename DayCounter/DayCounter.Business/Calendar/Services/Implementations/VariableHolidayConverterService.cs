using DayCounter.Business.Calendar.Services;
using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Calendar.Services.Implementations
{
    public class VariableHolidayConverterService : IVariableHolidayConverterService
    {
        private readonly IHolidayFactory _HolidayFactory;

        public VariableHolidayConverterService(IHolidayFactory holidayFactory)
        {
            _HolidayFactory = holidayFactory;
        }

        public IHoliday GetHoliday(IVariableHoliday variableHoliday, int year)
        {
            var holiday = _HolidayFactory.Create();

            if (variableHoliday != null)
            {
                holiday.Id = variableHoliday.id;
                holiday.Name = variableHoliday.Name;
                holiday.HolidayDate = GetHolidayDate(year, variableHoliday.Month,
                    variableHoliday.Nth, variableHoliday.DayOfWeek);
            }

            return holiday;
        }

        public DateTime GetHolidayDate(int year, int month, int nth, DayOfWeek dayOfWeek)
        {
            var holidayDate = DateTime.MinValue;

            if (nth > 1)
            {
                holidayDate = new DateTime(year, month, 1);
                while (dayOfWeek != holidayDate.DayOfWeek)
                {
                    holidayDate = holidayDate.AddDays(1);
                }

                var adjustment = ((nth - 1) * 7);
                var adjustedDate = holidayDate.AddDays(adjustment);

                //If nth dayofweek goes out of bounds,
                //return default value
                holidayDate = adjustedDate.Month == month ? adjustedDate : DateTime.MinValue;
            }

            return holidayDate;
        }
    }
}