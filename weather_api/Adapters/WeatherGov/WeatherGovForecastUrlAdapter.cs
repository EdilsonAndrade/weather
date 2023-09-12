using System.Text.Json;

internal class WeatherGovForecastUrlAdapter : IWeatherGovForecastUrlAdapter
{
  public async Task<string> Get(double latitude, double longitude)
  {
    using HttpClient httpClient = new();
    httpClient.DefaultRequestHeaders.Add("User-Agent", "C# program");
    string url = $"https://api.weather.gov/points/{latitude},{longitude}";
    HttpResponseMessage response = await httpClient.GetAsync(url);

    string jsonContent = response.Content.ReadAsStringAsync().Result;
    if (jsonContent != null && jsonContent.Contains("properties"))
    {
      ForeCastUrlDTO pointsResponse = JsonSerializer.Deserialize<ForeCastUrlDTO>(jsonContent)!;
      return pointsResponse.Property.Forecast;
    }
    else
    {
      throw new Exception("Unable to retrieve forecast url from the given latitude and longitude");
    }
  }
}

