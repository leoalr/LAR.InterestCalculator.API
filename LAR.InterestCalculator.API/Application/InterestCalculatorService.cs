﻿using LAR.InterestCalculator.Domain.Interfaces.Application;
using LAR.InterestCalculator.Domain.Interfaces.Infra;
using LAR.InterestCalculator.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace LAR.InterestCalculator.API.Application
{
    /// <summary>
    /// Application service responsible for doing the task of calculating compound interest
    /// </summary>
    public class InterestCalculatorService : IInterestCalculatorService
    {
        private readonly IInterestTaxClient _interestTaxClient;

        public InterestCalculatorService(
            IInterestTaxClient interestTaxClient
        )
        {
            _interestTaxClient = interestTaxClient;
        }

        public async Task<decimal> CalculateCompoundInterest(decimal initialAmount, int monthsAmount)
        {
            var interestTax = await _interestTaxClient.GetInterestTax();

            var interestCalculator = new Domain.ValueObjects
                .InterestCalculator(Convert.ToDouble(initialAmount), monthsAmount, Convert.ToDouble(interestTax));

            return interestCalculator.FinalAmount;
        }
    }
}
