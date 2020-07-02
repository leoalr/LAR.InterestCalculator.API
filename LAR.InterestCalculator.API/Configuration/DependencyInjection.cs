using LAR.InterestCalculator.API.Application;
using LAR.InterestCalculator.Domain.Interfaces.Application;
using LAR.InterestCalculator.Domain.Interfaces.Infra;
using LAR.InterestCalculator.Infra.ApiClients;
using Microsoft.Extensions.DependencyInjection;

namespace LAR.InterestCalculator.API.Configuration
{
    public static class DependencyInjection
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            //Infra
            services.AddHttpClient<IInterestTaxClient, InterestTaxClient>();

            //Application
            services.AddTransient<IInterestCalculatorService, InterestCalculatorService>();
        }
    }
}
