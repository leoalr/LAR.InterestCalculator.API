using System.Threading.Tasks;

namespace LAR.InterestCalculator.Domain.Interfaces.Infra
{
    public interface IInterestTaxClient
    {
        Task<decimal> GetInterestTax();
    }
}
