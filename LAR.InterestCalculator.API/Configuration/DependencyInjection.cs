using LAR.InterestCalculator.API.Application;
using LAR.InterestCalculator.Domain.Interfaces.Application;
using LAR.InterestCalculator.Domain.Interfaces.Infra;
using LAR.InterestCalculator.Infra.ApiClients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace LAR.InterestCalculator.API.Configuration
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            Action<HttpClient> getDefaultApiClientRequestHeaders = (httpClient) =>
            {
                httpClient.DefaultRequestHeaders.Add("Accept", configuration["AppOptions:BasicApiClientOptions:DefaultRequestHeaders:Accept"]);
                httpClient.DefaultRequestHeaders.Add("User-Agent", configuration["AppOptions:BasicApiClientOptions:DefaultRequestHeaders:User-Agent"]);
            };

            //Infra
            services.AddHttpClient<IInterestTaxClient, InterestTaxClient>(getDefaultApiClientRequestHeaders);

            //Application
            services.AddTransient<IInterestCalculatorService, InterestCalculatorService>();
        }
    }
}
