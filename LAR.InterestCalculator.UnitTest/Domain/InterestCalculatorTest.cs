using System;
using Xunit;

namespace LAR.InterestCalculator.UnitTest.Domain
{
    public class InterestCalculatorTest
    {
        private const int MAX_MONTHS_AMOUNT = 24;

        private readonly double _testingRandomInitialAmount;
        private readonly int _testingRandomMonthsAmount;
        private readonly double _testingRandomInterestTax;

        public InterestCalculatorTest()
        {
            var random = new Random();
            _testingRandomInitialAmount = random.NextDouble();
            _testingRandomMonthsAmount = random.Next(MAX_MONTHS_AMOUNT);
            _testingRandomInterestTax = random.NextDouble();
        }

        [Fact]
        public void ShouldFinalAmountBeACorrectResultOfACorrectCompoundInterestCalculation()
        {
            //Arrange
            Func<double, int, double, decimal> correctCalculation = (i, m, t) =>
            {
                return (decimal)Math.Truncate((i * Math.Pow(1 + t, m)) * 100) / 100;
            };

            //Act
            var interestCalculator = new InterestCalculator.Domain.ValueObjects
                .InterestCalculator(_testingRandomInitialAmount,
                    _testingRandomMonthsAmount, _testingRandomInterestTax);

            //Assert
            Assert.Equal(interestCalculator.FinalAmount,
                correctCalculation(_testingRandomInitialAmount, 
                    _testingRandomMonthsAmount, _testingRandomInterestTax));
        }
    }
}
