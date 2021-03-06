using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Calendar.Validators
{
    public interface IDatesValidator
    {
        bool AreValidDate(DateTime startDate, DateTime endDate);
    }
}
