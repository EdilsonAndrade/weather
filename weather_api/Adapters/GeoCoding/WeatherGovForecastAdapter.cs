using System.Text.Json;

internal class WeatherForecastAdapter : IWeatherGovForecastAdapter
{
  public async Task<IEnumerable<IPeriodForecast>> Get(string forecastUrl)
  {
    using HttpClient httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Add("User-Agent", "WebForecast Core");
    var response = await httpClient.GetAsync(forecastUrl);
    if (response.IsSuccessStatusCode)
    {
      var content = await response.Content.ReadAsStringAsync();
      var forecast = JsonSerializer.Deserialize<WeatherGovForeCastDTO>(content)!;
      return forecast.Property.Periods;
    }
    else
    {
      throw new Exception("Unable to get forecast");
    }

  }
}

