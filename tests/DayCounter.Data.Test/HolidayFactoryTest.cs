using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Entities.Implementations;
using DayCounter.Data.Calendar.Factories;
using Moq;
using NUnit.Framework;

namespace DayCounter.Data.Test
{
    public class HolidayFactoryTest
    {
        private Mock<IHolidayFactory> _HolidayFactory;

        [SetUp]
        public void Setup()
        {
            _HolidayFactory = new Mock<IHolidayFactory>();
            _HolidayFactory.Setup(f => f.Create()).Returns(() => new Holiday());
        }

        [Test]
        public void should_create_a_new_instance()
        {
            //Arrange
            IHoliday holiday = null;

            //Act
            holiday = _HolidayFactory.Object.Create();

            //Assert
            Assert.IsNotNull(holiday);
        }
    }
}
