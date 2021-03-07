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
        private readonly IHolidayDateAdjusterService _HolidayDateAdjusterService;

        public DayzController(IBusinessDayCounterService businessDayCounterService, 
            IHolidayDateAdjusterService holidayDateAdjusterService)
        {
            _BusinessDayCounterService = businessDayCounterService;
            _HolidayDateAdjusterService = holidayDateAdjusterService;
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
        public async Task<ActionResult> GetHolidays(int start, int end)
        {
            DateTime startDate = DateTimeOffset.FromUnixTimeSeconds(start).DateTime,
                endDate = DateTimeOffset.FromUnixTimeSeconds(end).DateTime;

            int gap = await Task.FromResult(_BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate));

            return Ok(gap);
        }
    }
}
