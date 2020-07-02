using System.Threading.Tasks;

namespace LAR.InterestCalculator.Domain.Interfaces.Application
{
    public interface IInterestCalculatorService
    {
        Task<decimal> CalculateCompoundInterest(decimal initialAmount, int monthsAmount);
    }
}
