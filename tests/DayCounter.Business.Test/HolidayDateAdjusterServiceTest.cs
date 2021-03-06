using DayCounter.Business.Calendar.Services;
using DayCounter.Business.Calendar.Services.Implementations;
using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Entities.Implementations;
using DayCounter.Data.Calendar.Factories;
using DayCounter.Data.Calendar.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DayCounter.Business.Test
{
    public class HolidayDateAdjusterServiceTest
    {
        private IHolidayDateAdjusterService _HolidayDateAdjusterService;
        private Mock<IHolidayFactory> _HolidayFactory;

        [SetUp]
        public void Setup()
        {
            var weekend = new List<DayOfWeek> { 
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };

            var daysRepository = new Mock<IDaysRepository>();
            daysRepository.Setup(r => r.GetWeekends()).Returns(weekend);

            _HolidayFactory = new Mock<IHolidayFactory>();
            _HolidayFactory.Setup(f => f.Create()).Returns(() => new Holiday());

            _HolidayDateAdjusterService = new HolidayDateAdjusterService(daysRepository.Object);
        }

        [Test]
        public void sunday_holiday_adjusted_to_monday()
        {
            //Arrange
            var holiday = _HolidayFactory.Object.Create();
            holiday.Id = 0;
            holiday.Name = "New Year Day 2017";
            holiday.HolidayDate = new DateTime(2017, 1, 1, 0, 0, 0);
            holiday.IsAdjustable = true;
            DateTime expected = new DateTime(2017, 1, 2, 0, 0, 0);

            //Act
            holiday = _HolidayDateAdjusterService.AdjustHolidayDate(holiday);


            //Assert
            Assert.AreEqual(expected.Date, holiday.HolidayDate.Date);
        }

        [Test]
        public void monday_holiday_not_adjusted()
        {
            //Arrange
            var holiday = _HolidayFactory.Object.Create();
            holiday.Id = 0;
            holiday.Name = "New Year Day 2018";
            holiday.HolidayDate = new DateTime(2018, 1, 1, 0, 0, 0);
            holiday.IsAdjustable = true;
            DateTime expected = new DateTime(2018, 1, 1, 0, 0, 0);

            //Act
            holiday = _HolidayDateAdjusterService.AdjustHolidayDate(holiday);


            //Assert
            Assert.AreEqual(expected.Date, holiday.HolidayDate.Date);
        }


        [Test]
        public void saturday_holiday_adjusted_to_monday()
        {
            //Arrange
            var holiday = _HolidayFactory.Object.Create();
            holiday.Id = 0;
            holiday.Name = "New Year Day 2022";
            holiday.HolidayDate = new DateTime(2022, 1, 1, 0, 0, 0);
            holiday.IsAdjustable = true;
            DateTime expected = new DateTime(2022, 1, 3, 0, 0, 0);

            //Act
            holiday = _HolidayDateAdjusterService.AdjustHolidayDate(holiday);

            //Assert
            Assert.AreEqual(expected.Date, holiday.HolidayDate.Date);
        }

        [Test]
        public void null_holiday_returns_null()
        {
            //Arrange
            IHoliday holiday = null;

            //Act
            holiday = _HolidayDateAdjusterService.AdjustHolidayDate(holiday);

            //Assert
            Assert.Null(holiday);
        }

        [Test]
        public void non_adjustable_holiday_is_not_adjusted()
        {
            //Arrange
            var holiday = _HolidayFactory.Object.Create();
            holiday.Id = 0;
            holiday.Name = "Anzac day 2021";
            holiday.HolidayDate = new DateTime(2021, 4, 25, 0, 0, 0);
            holiday.IsAdjustable = false;
            DateTime expected = new DateTime(2021, 4, 25, 0, 0, 0);

            //Act
            holiday = _HolidayDateAdjusterService.AdjustHolidayDate(holiday);

            //Assert
            Assert.AreEqual(expected.Date, holiday.HolidayDate.Date);
        }
    }
}
