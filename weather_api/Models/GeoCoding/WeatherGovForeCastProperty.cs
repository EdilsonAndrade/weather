using System.Text.Json.Serialization;
internal class WeatherGovForeCastProperty : IWeatherGovForeCastProperty
{
  [JsonPropertyName("periods")]
  public required IEnumerable<PeriodForecast> Periods { get; set; }
}
