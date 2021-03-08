using DayCounter.Business.Calendar.Models;
using DayCounter.Shared.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Calendar.Services 
{
    public interface IHolidayServices : IService
    {
        IEnumerable<IHolidayModel> GetHolidays();
        IEnumerable<IHolidayModel> GetAllHolidays();
    }
}
