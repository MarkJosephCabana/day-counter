using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Entities.Implementations;
using DayCounter.Data.Calendar.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Repositories.Implementations
{
    public class InMemoryDaysRepository : IDaysRepository
    {
        private readonly IHolidayFactory _HolidayFactory;
        private readonly IVariableHolidayFactory _VariableHolidayFactory;
        public InMemoryDaysRepository(IHolidayFactory holidayFactory,
            IVariableHolidayFactory variableHolidayFactory)
        {
            _HolidayFactory = holidayFactory;
            _VariableHolidayFactory = variableHolidayFactory;
        }

        public IEnumerable<IHoliday> GetHolidays()
        {
            return new List<IHoliday> {
                _HolidayFactory.Create(1, "Xmas 2013",  new DateTime(2013, 12, 25,0,0,0), true),
                _HolidayFactory.Create(2, "Boxing day 2013",  new DateTime(2013, 12, 26,0,0,0), true),
                _HolidayFactory.Create(4, "New Year 2014",  new DateTime(2014, 1, 1,0,0,0), true)
            };
        }


        public IEnumerable<IVariableHoliday> GetVariableHolidays()
        {
            return new List<IVariableHoliday> {
                _VariableHolidayFactory.Create(new Random().Next(0, int.MaxValue), DayOfWeek.Monday, true, 6, "Queen's birthday", 2) 
            };
        }

        public IEnumerable<DateTime> GetSimpleHolidays()
        {
            return new List<DateTime> {
                new DateTime(2013, 12, 25,0,0,0),
                new DateTime(2013, 12, 26,0,0,0),
                new DateTime(2014, 1, 1,0,0,0)
            };
        }



        public IEnumerable<DayOfWeek> GetWeekends()
        {
            return new List<DayOfWeek> {
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };
        }
    }
}
