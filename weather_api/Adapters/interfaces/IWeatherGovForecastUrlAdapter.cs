internal interface IWeatherGovForecastUrlAdapter
{
  Task<string> Get(double latitude, double longitude);
}
