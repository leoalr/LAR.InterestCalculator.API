using Bogus;
using FluentAssertions;
using LAR.InterestCalculator.API.Application;
using LAR.InterestCalculator.Domain.Interfaces.Infra;
using NSubstitute;
using System;
using System.Collections.Generic;
using Xunit;

namespace LAR.InterestCalculator.UnitTest.Application
{
    public class InterestCalculatorServiceTest
    {
        public static IEnumerable<object[]> InterestTaxToThrowException =>
            new List<object[]>
            {
                new object[] { default(decimal) },
                new object[] { -1M },
                new object[] { -0.01M },
                new object[] { -0.00001M },
                new object[] { -100000M },
            };

        [Theory]
        [MemberData(nameof(InterestTaxToThrowException))]
        public void ShouldRaiseArgumentOutOfRangeExceptionWhenInterestTaxIsNotValidForCalculating(decimal interestTax)
        {
            //Arrange
            var interestTaxClientSubstitute = Substitute.For<IInterestTaxClient>();
            interestTaxClientSubstitute.GetInterestTax().ReturnsForAnyArgs(interestTax);
            var systemUnderTest = new InterestCalculatorService(interestTaxClientSubstitute);
            var randomizer = new Randomizer();

            void testToThrowException()
            {
                systemUnderTest.CalculateCompoundInterest(randomizer.Decimal(1, 10000), randomizer.Int(1, 24))
                    .GetAwaiter().GetResult();
            }

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(testToThrowException);
        }

        [Fact]
        public void ShouldReturnPositiveDecimalAndNotRaiseArgumentOutOfRangeExceptionWhenInterestTaxIsValid()
        {
            //Arrange
            var randomizer = new Randomizer();
            var interestTax = randomizer.Decimal(0M, 1M);
            var interestTaxClientSubstitute = Substitute.For<IInterestTaxClient>();
            interestTaxClientSubstitute.GetInterestTax().ReturnsForAnyArgs(interestTax);
            var systemUnderTest = new InterestCalculatorService(interestTaxClientSubstitute);

            //Act
            var result = systemUnderTest.CalculateCompoundInterest(randomizer.Decimal(1, 10000), randomizer.Int(1, 24))
                    .GetAwaiter().GetResult();

            //Assert
            result.Should().BeGreaterThan(0);
        }
    }
}
