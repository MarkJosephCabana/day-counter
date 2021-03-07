using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Calendar.Models.Implementations
{
    public class HolidayModel : IHolidayModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsAdjustable { get; set; }
    }
}
