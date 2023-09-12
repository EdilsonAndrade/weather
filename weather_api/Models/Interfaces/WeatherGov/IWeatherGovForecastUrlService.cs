internal interface IWeatherGovForecastUrlService
{
  Task<string> Get(double latitude, double longitude);
}
