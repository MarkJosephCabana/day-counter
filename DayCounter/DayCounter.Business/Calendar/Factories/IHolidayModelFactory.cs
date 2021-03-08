using DayCounter.Business.Calendar.Models;
using DayCounter.Shared.DependencyResolution;
using System;

namespace DayCounter.Business.Calendar.Factories
{
    public interface IHolidayModelFactory : IService
    {
        IHolidayModel Create();
        IHolidayModel Create(int id, string name, DateTime date, bool isAdjustable);
    }
}
