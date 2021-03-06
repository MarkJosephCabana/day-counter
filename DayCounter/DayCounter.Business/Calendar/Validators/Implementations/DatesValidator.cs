using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Calendar.Validators.Implementations
{
    public class DatesValidator : IDatesValidator
    {
        public bool AreValidDate(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).TotalDays > 1;
        }
    }
}
