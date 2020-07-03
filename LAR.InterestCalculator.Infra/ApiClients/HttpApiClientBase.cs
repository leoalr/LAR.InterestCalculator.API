using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LAR.InterestCalculator.Infra.ApiClients
{
    public abstract class HttpApiClientBase
    {
        private readonly HttpClient _httpClient;

        public HttpApiClientBase(
            HttpClient httpClient
        )
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string baseUrl, string relativePath)
        {
            HttpResponseMessage httpResponse = await _httpClient.GetAsync(baseUrl + relativePath);

            httpResponse.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<T>(await httpResponse.Content.ReadAsStringAsync());
        }
    }
}
