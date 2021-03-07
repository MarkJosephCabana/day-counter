using System;

namespace DayCounter.Business.Calendar.Models
{
    public interface IHolidayModel
    {
        DateTime Date { get; set; }
        int Id { get; set; }
        bool IsAdjustable { get; set; }
        string Name { get; set; }
    }
}