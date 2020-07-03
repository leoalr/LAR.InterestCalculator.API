using System.Threading.Tasks;
using LAR.InterestCalculator.Domain.Options;
using Microsoft.AspNetCore.Mvc;

namespace LAR.InterestCalculator.API.Controllers
{
    [Route("api/showmethecode")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private const string DEFAULT_MY_GITHUB_REPOSITORIES_URL = "https://github.com/leoalr?tab=repositories";

        private readonly AppOptions _appOptions;

        public ShowMeTheCodeController(
            AppOptions appOptions
        )
        {
            _appOptions = appOptions;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            return string.IsNullOrWhiteSpace(_appOptions.MyGithubRepositoriesURL) ? 
                DEFAULT_MY_GITHUB_REPOSITORIES_URL :
                _appOptions.MyGithubRepositoriesURL;
        }
    }
}
