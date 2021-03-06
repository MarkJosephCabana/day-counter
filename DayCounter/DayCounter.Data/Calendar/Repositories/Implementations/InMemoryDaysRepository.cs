using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Data.Calendar.Repositories.Implementations
{
    public class InMemoryDaysRepository : IDaysRepository
    {
        public IEnumerable<DateTime> GetHolidays()
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
