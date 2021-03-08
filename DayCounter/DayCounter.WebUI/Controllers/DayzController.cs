using DayCounter.Business.Calendar.Models;
using DayCounter.Business.Calendar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DayCounter.WebUI.Controllers
{
    [ApiController]
    public class DayzController : ControllerBase
    {
        private readonly IBusinessDayCounterService _BusinessDayCounterService;
        private readonly IHolidayServices _HolidayServices;

        public DayzController(IBusinessDayCounterService businessDayCounterService,
            IHolidayServices holidayServices)
        {
            _BusinessDayCounterService = businessDayCounterService;
            _HolidayServices = holidayServices;
        }

        [HttpGet,
         Route("days/{start:int}/{end:int}")]
        public async Task<ActionResult> GetDays(int start, int end)
        {
            DateTime startDate = DateTimeOffset.FromUnixTimeSeconds(start).DateTime,
                endDate = DateTimeOffset.FromUnixTimeSeconds(end).DateTime;

            int gap = await Task.FromResult(_BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate));

            return Ok(gap);
        }

        [HttpGet,
         Route("businessdays/{start:int}/{end:int}")]
        public async Task<ActionResult> GetBusinessDays(int start, int end)
        {
            DateTime startDate = DateTimeOffset.FromUnixTimeSeconds(start).DateTime,
                endDate = DateTimeOffset.FromUnixTimeSeconds(end).DateTime;

            IList<IHolidayModel> holidays = _HolidayServices.GetHolidays().ToList();

            int gap = await Task.FromResult(_BusinessDayCounterService.BusinessDaysBetweenTwoDates(startDate, endDate, holidays));

            return Ok(gap);
        }

        [HttpGet,
        Route("businessdays/special/{start:int}/{end:int}")]
        public async Task<ActionResult> GetSpecialBusinessDays(int start, int end)
        {
            DateTime startDate = DateTimeOffset.FromUnixTimeSeconds(start).DateTime,
                endDate = DateTimeOffset.FromUnixTimeSeconds(end).DateTime;

            IList<IHolidayModel> holidays = _HolidayServices.GetAllHolidays().ToList();

            int gap = await Task.FromResult(_BusinessDayCounterService.BusinessDaysBetweenTwoDates(startDate, endDate, holidays));

            return Ok(gap);
        }

        [HttpGet,
        Route("holidays")]
        public async Task<ActionResult> GetHolidays()
        {
            IList<IHolidayModel> holidays = await Task.FromResult(_HolidayServices.GetHolidays().ToList());

            return Ok(holidays);
        }

        [HttpGet,
        Route("holidays/special")]
        public async Task<ActionResult> GetAllHolidays()
        {
            IList<IHolidayModel> holidays = await Task.FromResult(_HolidayServices.GetAllHolidays().ToList());

            return Ok(holidays);
        }
    }
}
