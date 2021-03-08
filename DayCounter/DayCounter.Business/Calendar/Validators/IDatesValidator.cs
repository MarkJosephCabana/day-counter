using DayCounter.Shared.DependencyResolution;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Calendar.Validators
{
    public interface IDatesValidator : IService
    {
        bool AreValidDate(DateTime startDate, DateTime endDate);
    }
}
