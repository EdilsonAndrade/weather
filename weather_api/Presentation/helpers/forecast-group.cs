
static class ForecastGroup
{
  public static List<GroupedWeatherForecast> GroupForecast(IEnumerable<IPeriodForecast> forecasts)
  {
    // Group the forecasts by the day of the week
    var groupedForecasts = forecasts
        .GroupBy(forecast => forecast.StartTime.DayOfWeek)
        .Select(group =>
        {
          var day = group.Key.ToString();
          var forecasts = group.ToList();
          return new GroupedWeatherForecast { Day = day, Forecasts = forecasts };
        })
        .ToList();

    return groupedForecasts;
  }
}

internal class GroupedWeatherForecast
{
  public required string Day { get; set; }
  public required List<IPeriodForecast> Forecasts { get; set; }
}
