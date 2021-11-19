using ServiceClients;

namespace Template.User.Client.Services
{
    public class WeatherForecastService
    {
        private UserServerApiClient _apiClient;
        public WeatherForecastService(UserServerApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        public async Task<ICollection<WeatherForecast>> GetWeatherForecasts()
        {
            return await _apiClient.GetAsync();
        }
    }
}
