using DayCounter.Business.Calendar.Validators;
using DayCounter.Business.Calendar.Validators.Implementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DayCounter.Business.Test
{
    public class DatesValidatorTest
    {
        private IDatesValidator _DatesValidator;

        [SetUp]
        public void Setup()
        {
            _DatesValidator = new DatesValidator();
        }

        [Test]
        public void date_range_is_invalid()
        {
            //Arrange
            DateTime startDate = new DateTime(2021, 3, 1, 0, 0, 0),
                endDate = new DateTime(2021, 3, 3, 0, 0, 0);

            //Act
            var isValid = _DatesValidator.AreValidDate(startDate, endDate);

            Assert.IsTrue(isValid);
        }

        [Test]
        public void same_dates_are_invalid()
        {
            //Arrange
            DateTime startDate = new DateTime(2021, 3, 1, 0, 0, 0),
                endDate = new DateTime(2021, 3, 1, 0, 0, 0);

            //Act
            var isValid = _DatesValidator.AreValidDate(startDate, endDate);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void enddate_is_before_start_date_are_invalid()
        {
            //Arrange
            DateTime startDate = new DateTime(2021, 3, 3, 0, 0, 0),
                endDate = new DateTime(2021, 3, 1, 0, 0, 0);

            //Act
            var isValid = _DatesValidator.AreValidDate(startDate, endDate);

            Assert.IsFalse(isValid);
        }

        [Test]
        public void suceeding_dates_are_invalid()
        {
            //Arrange
            DateTime startDate = new DateTime(2021, 3, 1, 0, 0, 0),
                endDate = new DateTime(2021, 3, 2, 0, 0, 0);

            //Act
            var isValid = _DatesValidator.AreValidDate(startDate, endDate);

            Assert.IsFalse(isValid);
        }
    }
}
