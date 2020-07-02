using LAR.InterestCalculator.Domain.Interfaces.Infra;
using LAR.InterestCalculator.Infra.ApiClients.Response;
using System.Net.Http;
using System.Threading.Tasks;

namespace LAR.InterestCalculator.Infra.ApiClients
{
    public class InterestTaxClient : HttpApiClientBase, IInterestTaxClient
    {
        public InterestTaxClient(
            HttpClient httpClient
        ) : base(httpClient)
        {

        }

        public async Task<decimal> GetInterestTax()
        {
            var interestTaxResponse = await GetAsync<GetInterestTaxResponse>("http://localhost:51949/api", "/InterestTax");

            return interestTaxResponse.InterestTax;
        }
    }
}
