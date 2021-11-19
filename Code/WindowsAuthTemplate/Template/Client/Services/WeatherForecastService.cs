using Template.User.Client.UserServer;

namespace Template.User.Client.Services
{
    public class WeatherForecastService
    {
        private readonly WeatherForecastApiClient _apiClient;
        public WeatherForecastService(WeatherForecastApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<ICollection<WeatherForecast>> GetWeatherForecasts()
        {
            return await _apiClient.GetAsync();
        }
    }
}
