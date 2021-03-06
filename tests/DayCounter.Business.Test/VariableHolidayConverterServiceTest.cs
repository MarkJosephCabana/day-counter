using DayCounter.Business.Calendar.Factories;
using DayCounter.Business.Calendar.Models.Implementations;
using DayCounter.Business.Calendar.Services;
using DayCounter.Business.Calendar.Services.Implementations;
using DayCounter.Data.Calendar.Entities.Implementations;
using DayCounter.Data.Calendar.Factories;
using Moq;
using NUnit.Framework;
using System;

namespace DayCounter.Business.Test
{
    public class VariableHolidayConverterServiceTest
    {
        private IVariableHolidayConverterService _VariableHolidayConverterService;
        private Mock<IHolidayModelFactory> _HolidayModelFactory;
        private Mock<IVariableHolidayFactory> _VariableHolidayFactory;

        [SetUp]
        public void Setup()
        {
            _HolidayModelFactory = new Mock<IHolidayModelFactory>();
            _VariableHolidayFactory = new Mock<IVariableHolidayFactory>();

            _HolidayModelFactory.Setup(f => f.Create()).Returns(() => new HolidayModel());
            _VariableHolidayFactory.Setup(f => f.Create()).Returns(() => new VariableHoliday());

            _VariableHolidayConverterService = new VariableHolidayConverterService(_HolidayModelFactory.Object);
        }

        [Test]
        public void march_8_2021_is_2nd_monday_march_2021()
        {
            //Arrange
            var variableHoliday = _VariableHolidayFactory.Object.Create();
            variableHoliday.DayOfWeek = System.DayOfWeek.Monday;
            variableHoliday.Month = 3;
            variableHoliday.Nth = 2;
            var expected = new DateTime(2021, 3, 8, 0, 0, 0);

            //Act
            var holiday = _VariableHolidayConverterService.GetHoliday(variableHoliday, 2021);

            //Assert
            Assert.AreEqual(expected.Date, holiday.Date.Date);
        }

        [Test]
        public void march_25_2021_is_not_2nd_monday_march_2021()
        {
            //Arrange
            var variableHoliday = _VariableHolidayFactory.Object.Create();
            variableHoliday.DayOfWeek = System.DayOfWeek.Monday;
            variableHoliday.Month = 3;
            variableHoliday.Nth = 2;
            var expected = new DateTime(2021, 3, 25, 0, 0, 0);

            //Act
            var holiday = _VariableHolidayConverterService.GetHoliday(variableHoliday, 2021);

            //Assert
            Assert.AreNotEqual(expected.Date, holiday.Date.Date);
        }


        [Test]
        public void nth_less_than_one_is_min_date()
        {
            //Arrange
            var variableHoliday = _VariableHolidayFactory.Object.Create();
            variableHoliday.DayOfWeek = System.DayOfWeek.Monday;
            variableHoliday.Month = 3;
            variableHoliday.Nth = 0;
            var expected = new DateTime(2021, 3, 25, 0, 0, 0);

            //Act
            var holiday = _VariableHolidayConverterService.GetHoliday(variableHoliday, 2021);

            //Assert
            Assert.AreEqual(DateTime.MinValue.Date, holiday.Date.Date);
        }

        [Test]
        public void nth_out_of_bounds_is_min_date()
        {
            //Arrange
            var variableHoliday = _VariableHolidayFactory.Object.Create();
            variableHoliday.DayOfWeek = System.DayOfWeek.Monday;
            variableHoliday.Month = 3;
            variableHoliday.Nth = 6;
            var expected = new DateTime(2021, 3, 25, 0, 0, 0);

            //Act
            var holiday = _VariableHolidayConverterService.GetHoliday(variableHoliday, 2021);

            //Assert
            Assert.AreEqual(DateTime.MinValue.Date, holiday.Date.Date);
        }
    }
}
