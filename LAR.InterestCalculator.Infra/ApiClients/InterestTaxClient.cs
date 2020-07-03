using LAR.InterestCalculator.Domain.Interfaces.Infra;
using LAR.InterestCalculator.Domain.Options;
using LAR.InterestCalculator.Infra.ApiClients.Response;
using System.Net.Http;
using System.Threading.Tasks;

namespace LAR.InterestCalculator.Infra.ApiClients
{
    public class InterestTaxClient : HttpApiClientBase, IInterestTaxClient
    {
        private readonly InterestTaxApiOptions _apiOptions;

        public InterestTaxClient(
            HttpClient httpClient,
            AppOptions options
        ) : base(httpClient)
        {
            _apiOptions = options.InterestTaxApiOptions;
        }

        public async Task<decimal> GetInterestTax()
        {
            var interestTaxResponse = await GetAsync<GetInterestTaxResponse>(
                _apiOptions.BaseUrl, _apiOptions.GetInterestTaxPath);

            return interestTaxResponse?.InterestTax ?? default;
        }
    }
}
