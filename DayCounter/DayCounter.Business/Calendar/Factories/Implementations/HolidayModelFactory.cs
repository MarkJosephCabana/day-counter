using DayCounter.Business.Calendar.Models;
using DayCounter.Business.Calendar.Models.Implementations;
using System;

namespace DayCounter.Business.Calendar.Factories.Implementations
{
    public class HolidayModelFactory : IHolidayModelFactory
    {
        public IHolidayModel Create()
        {
            return new HolidayModel();
        }

        public IHolidayModel Create(int id, string name, DateTime date, bool isAdjustable)
        {
            return new HolidayModel
            {
                IsAdjustable = isAdjustable,
                Date = date,
                Id = id,
                Name = name
            };
        }
    }
}
