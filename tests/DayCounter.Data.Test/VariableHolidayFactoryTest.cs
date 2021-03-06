using DayCounter.Data.Calendar.Entities;
using DayCounter.Data.Calendar.Entities.Implementations;
using DayCounter.Data.Calendar.Factories;
using Moq;
using NUnit.Framework;

namespace DayCounter.Data.Test
{
    public class VariableHolidayFactoryTest
    {
        private Mock<IVariableHolidayFactory> _VariableHolidayFactory;

        [SetUp]
        public void Setup()
        {
            _VariableHolidayFactory = new Mock<IVariableHolidayFactory>();
            _VariableHolidayFactory.Setup(f => f.Create()).Returns(() => new VariableHoliday());
        }

        [Test]
        public void should_create_a_new_instance()
        {
            //Arrange
            IVariableHoliday holiday = null;

            //Act
            holiday = _VariableHolidayFactory.Object.Create();

            //Assert
            Assert.IsNotNull(holiday);
        }
    }
}
