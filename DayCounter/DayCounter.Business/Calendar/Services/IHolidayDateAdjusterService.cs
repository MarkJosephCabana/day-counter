using DayCounter.Business.Calendar.Models;

namespace DayCounter.Business.Calendar.Services
{
    public interface IHolidayDateAdjusterService
    {
        IHolidayModel AdjustHolidayDate(IHolidayModel holiday);
    }
}
