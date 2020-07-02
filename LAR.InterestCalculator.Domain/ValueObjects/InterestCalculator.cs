using System;

namespace LAR.InterestCalculator.Domain.ValueObjects
{
    public class InterestCalculator
    {
        public InterestCalculator(
            double initialAmount,
            int monthsAmount,
            double interestTax
        )
        {
            InitialAmount = initialAmount;
            MonthsAmount = monthsAmount;
            InterestTax = interestTax;
        }

        public double InitialAmount { get; }

        public int MonthsAmount { get; }

        public double InterestTax { get; }

        public decimal FinalAmount
        { 
            get 
            {
                var notTrucatedResult = InitialAmount * Math.Pow(1 + InterestTax, MonthsAmount);
                return (decimal)Math.Truncate(notTrucatedResult * 100) / 100;
            }
        }
    }
}
