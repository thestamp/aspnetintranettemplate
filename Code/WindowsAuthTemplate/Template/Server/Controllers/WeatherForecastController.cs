using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.User.Server.CoreServer;


namespace Template.User.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CoreServerApiClient _client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CoreServerApiClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            
            return _client.GetAsync().Result;
        }
    }
}