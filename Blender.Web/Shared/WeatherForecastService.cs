using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blender.Web.Shared
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;

        public WeatherForecastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(bool success, WeatherForecast[] weatherForecasts)> Get()
        {
            var response = await _httpClient.GetAsync("WeatherForecast");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return (true, JsonSerializer.Deserialize<WeatherForecast[]>(json, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }));
            }

            return (false, new WeatherForecast[0]);
        }
    }
}