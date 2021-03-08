using DayCounter.Business.Calendar.Factories;
using DayCounter.Business.Calendar.Models;
using DayCounter.Data.Calendar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DayCounter.Business.Calendar.Services.Implementations
{
    public class HolidayServices : IHolidayServices
    {
        private readonly IDaysRepository _DaysRepository;
        private readonly IHolidayModelFactory _HolidayModelFactory;
        private readonly IVariableHolidayConverterService _VariableHolidayConverterService;

        public HolidayServices(IDaysRepository daysRepository, IHolidayModelFactory holidayModelFactory,
            IVariableHolidayConverterService variableHolidayConverterService)
        {
            _DaysRepository = daysRepository;
            _HolidayModelFactory = holidayModelFactory;
            _VariableHolidayConverterService = variableHolidayConverterService;
        }

        public IEnumerable<IHolidayModel> GetHolidays()
        {
            var model = Enumerable.Empty<IHolidayModel>();
            var holidays = _DaysRepository.GetHolidays();

            if (holidays?.Any() ?? false)
            {
                model = holidays.Select(h => _HolidayModelFactory.Create(h.Id, h.Name, h.HolidayDate, h.IsAdjustable))
                    .ToList();
            }

            return model;
        }

        public IEnumerable<IHolidayModel> GetAllHolidays()
        {
            var model = GetHolidays();
            var holidays = _DaysRepository.GetVariableHolidays();

            if (holidays?.Any() ?? false)
            {
                model = model.Union(holidays.Select(h => _VariableHolidayConverterService.GetHoliday(h, DateTime.Now.Year)))
                    .ToList();
            }

            return model;
        }
    }
}
