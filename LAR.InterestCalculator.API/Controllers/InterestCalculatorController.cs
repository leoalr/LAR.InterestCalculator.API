using LAR.InterestCalculator.API.Attributes;
using LAR.InterestCalculator.API.Request;
using LAR.InterestCalculator.API.Response;
using LAR.InterestCalculator.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LAR.InterestCalculator.API.Controllers
{
    /// <summary>
    /// API to calculate interest values
    /// </summary>
    [Route("api/calculajuros")]
    [ApiController]
    public class InterestCalculatorController : ControllerBase
    {
        private readonly IInterestCalculatorService _interestCalculatorService;

        public InterestCalculatorController(
            IInterestCalculatorService interestCalculatorService)
        {
            _interestCalculatorService = interestCalculatorService;
        }

        /// <summary>
        /// HTTP POST Method to calculate compound interest total value
        /// </summary>
        /// <returns>A decimal value representing the result of the calculation</returns>
        [HttpPost]
        public async Task<IActionResult> CompoundInterest(CompoundInterestRequest request)
        {
            try
            {
                return new CompoundInterestResponse
                {
                    Result = await _interestCalculatorService.CalculateCompoundInterest(request.InitialAmount, request.MonthsAmount)
                };
            }
            catch (System.Exception ex)
            {
                return new ResponseBase(500, "Ocorreu um erro inesperado. Tente novamente e se " +
                                             "o erro persistir entre em contato com o administrador da API. " +
                                             "- Exception: " + ex.Message);
            }
        }
    }
}
