internal class WeatherForecastService : IWeatherForecastService
{
  private readonly IWeatherGovForecastAdapter _weatherGovForecastAdapter;
  public WeatherForecastService(IWeatherGovForecastAdapter weatherGovForecastAdapter)
  {
    _weatherGovForecastAdapter = weatherGovForecastAdapter;
  }
  public async Task<IEnumerable<IPeriodForecast>> Get(string fullAddress)
  {
    return await _weatherGovForecastAdapter.Get(fullAddress);
  }
}
