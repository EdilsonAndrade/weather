internal interface IWeatherForecastService
{
  Task<IEnumerable<IPeriodForecast>> Get(string fullAddress);
}
