using DayCounter.Business.Calendar.Factories;
using DayCounter.Business.Calendar.Factories.Implementations;
using DayCounter.Business.Calendar.Services;
using DayCounter.Business.Calendar.Services.Implementations;
using DayCounter.Business.Calendar.Validators.Implementations;
using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Entities.Implementations;
using DayCounter.Data.Calendar.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DayCounter.Business.Test
{
    public class BusinessDayCounterServiceTest
    {
        private IBusinessDayCounterService _BusinessDayCounterService;
        private Mock<IDaysRepository> _DaysRepository;
        private IHolidayModelFactory _HolidayModelFactory;
        private int _gap;

        [SetUp]
        public void Setup()
        {
            var weekends = new List<DayOfWeek> {
                    DayOfWeek.Saturday,
                    DayOfWeek.Sunday
                };

            var simpleHolidays = new List<DateTime> {
                new DateTime(2013, 12, 25,0,0,0),
                new DateTime(2013, 12, 26,0,0,0),
                new DateTime(2014, 1, 1,0,0,0),
                new DateTime(2022, 1, 1, 0, 0, 0),
                new DateTime(2017, 1, 1, 0, 0, 0)
            };

            var holidays = new List<IHoliday>
            {
                new Holiday
                {
                    Id = 1,
                    Name = "Xmas 2013",
                    HolidayDate = new DateTime(2013, 12, 25,0,0,0),
                    IsAdjustable = true
                },
                new Holiday
                {
                    Id = 2,
                    Name = "Boxing day 2013",
                    HolidayDate = new DateTime(2013, 12, 26,0,0,0),
                    IsAdjustable = true
                },
                new Holiday
                {
                    Id = 3,
                    Name = "New Year 2014",
                    HolidayDate = new DateTime(2014, 1, 1,0,0,0),
                    IsAdjustable = true
                }
            };

            _DaysRepository = new Mock<IDaysRepository>();

            var holidayDateAdjusterService = new HolidayDateAdjusterService(_DaysRepository.Object);

            _DaysRepository.Setup(r => r.GetWeekends()).Returns(weekends);
            _DaysRepository.Setup(r => r.GetSimpleHolidays()).Returns(simpleHolidays);
            _DaysRepository.Setup(r => r.GetHolidays()).Returns(holidays);

            _BusinessDayCounterService = new BusinessDayCounterService(new DatesValidator(),
                _DaysRepository.Object, holidayDateAdjusterService);
            _HolidayModelFactory = new HolidayModelFactory();
        }

        [Test]
        public void monday_to_wednesday_has_1_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2021, 3, 1, 0, 0, 0),
                endDate = new DateTime(2021, 3, 3, 0, 0, 0);

            //Act
            _gap = _BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.AreEqual(1, _gap);
        }

        [Test]
        public void monday_to_tuesday_has_0_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2021, 3, 1, 0, 0, 0),
                endDate = new DateTime(2021, 3, 2, 0, 0, 0);

            //Act
            _gap = _BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.AreEqual(0, _gap);
        }


        [Test]
        public void tuesday_to_previous_day_has_0_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2021, 3, 1, 0, 0, 0),
                endDate = new DateTime(2021, 3, 2, 0, 0, 0);

            //Act
            _gap = _BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.AreEqual(0, _gap);
        }

        [Test]
        public void test_case_one_has_1_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2013, 10, 7, 0, 0, 0),
                endDate = new DateTime(2013, 10, 9, 0, 0, 0);

            //Act
            _gap = _BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.AreEqual(1, _gap);
        }


        [Test]
        public void test_case_two_has_5_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2013, 10, 5, 0, 0, 0),
                endDate = new DateTime(2013, 10, 14, 0, 0, 0);

            //Act
            _gap = _BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.AreEqual(5, _gap);
        }

        [Test]
        public void test_case_three_has_61_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2013, 10, 7, 0, 0, 0),
                endDate = new DateTime(2014, 1, 1, 0, 0, 0);

            //Act
            _gap = _BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.AreEqual(61, _gap);
        }

        [Test]
        public void test_case_four_has_0_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2013, 10, 7, 0, 0, 0),
                endDate = new DateTime(2013, 10, 5, 0, 0, 0);

            //Act
            _gap = _BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.AreEqual(0, _gap);
        }

        [Test]
        public void test_case_five_has_1_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2013, 10, 7, 0, 0, 0),
                endDate = new DateTime(2013, 10, 9, 0, 0, 0);
            var holidays = _DaysRepository.Object.GetHolidays()
                .Select(h => _HolidayModelFactory.Create(h.Id, h.Name, h.HolidayDate, h.IsAdjustable))
                .ToList();

            //Act
            _gap = _BusinessDayCounterService.BusinessDaysBetweenTwoDates(startDate, endDate, holidays);

            //Assert
            Assert.AreEqual(1, _gap);
        }

        [Test]
        public void test_case_six_has_0_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2013, 12, 24, 0, 0, 0),
                endDate = new DateTime(2013, 12, 27, 0, 0, 0);
            var holidays = _DaysRepository.Object.GetHolidays()
                 .Select(h => _HolidayModelFactory.Create(h.Id, h.Name, h.HolidayDate, h.IsAdjustable))
                 .ToList();

            //Act
            _gap = _BusinessDayCounterService.BusinessDaysBetweenTwoDates(startDate, endDate, holidays);

            //Assert
            Assert.AreEqual(0, _gap);
        }

        [Test]
        public void test_case_seven_has_59_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2013, 10, 7, 0, 0, 0),
                endDate = new DateTime(2014, 1, 1, 0, 0, 0);
            var holidays = _DaysRepository.Object.GetHolidays()
                 .Select(h => _HolidayModelFactory.Create(h.Id, h.Name, h.HolidayDate, h.IsAdjustable))
                 .ToList();

            //Act
            _gap = _BusinessDayCounterService.BusinessDaysBetweenTwoDates(startDate, endDate, holidays);

            //Assert
            Assert.AreEqual(59, _gap);
        }

        [Test]
        public void sunday_to_tuesday_has_1_weekday()
        {
            //Arrange
            DateTime startDate = new DateTime(2021, 2, 28, 0, 0, 0),
                endDate = new DateTime(2021, 3, 2, 0, 0, 0);

            //Act
            _gap = _BusinessDayCounterService.WeekdaysBetweenTwoDates(startDate, endDate);

            //Assert
            Assert.AreEqual(1, _gap);
        }
    }
}