internal interface IWeatherGovForecastAdapter
{
  Task<IEnumerable<IPeriodForecast>> Get(string forecastUrl);
}
