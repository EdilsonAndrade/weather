

internal class WeatherForecastUrlService : IWeatherGovForecastUrlService
{
  private readonly IWeatherGovForecastUrlAdapter _weatherGov;
  public WeatherForecastUrlService(IWeatherGovForecastUrlAdapter weatherGov)
  {
    _weatherGov = weatherGov;
  }

  public async Task<string> Get(double latitude, double longitude)
  {
    return await _weatherGov.Get(latitude, longitude);
  }
}
