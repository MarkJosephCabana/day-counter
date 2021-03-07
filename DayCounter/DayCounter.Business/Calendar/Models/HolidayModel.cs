﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Calendar.Models
{
    public class HolidayModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsAdjustable { get; set; }
    }
}
