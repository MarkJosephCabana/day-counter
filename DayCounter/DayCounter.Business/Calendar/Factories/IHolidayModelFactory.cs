using DayCounter.Business.Calendar.Models;
using System;

namespace DayCounter.Business.Calendar.Factories
{
    public interface IHolidayModelFactory
    {
        IHolidayModel Create();
        IHolidayModel Create(int id, string name, DateTime date, bool isAdjustable);
    }
}
