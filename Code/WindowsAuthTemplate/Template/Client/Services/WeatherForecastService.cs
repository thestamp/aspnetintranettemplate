using ServiceClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Client.Services
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
