using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Template.User.Server.CoreServer;


namespace Template.User.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FutureWeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherForecastApiClient _client;

        public FutureWeatherForecastController(ILogger<WeatherForecastController> logger, WeatherForecastApiClient client)
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