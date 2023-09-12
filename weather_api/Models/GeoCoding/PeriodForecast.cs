using System.Text.Json.Serialization;

class PeriodForecast : IPeriodForecast
{
  [JsonPropertyName("number")]
  public required int Number { get; set; }
  [JsonPropertyName("name")]
  public required string Name { get; set; }
  [JsonPropertyName("temperature")]
  public required int Temperature { get; set; }
  [JsonPropertyName("temperatureUnit")]
  public required string TemperatureUnit { get; set; }
  [JsonPropertyName("windSpeed")]
  public required string WindSpeed { get; set; }
  [JsonPropertyName("windDirection")]
  public required string WindDirection { get; set; }
  [JsonPropertyName("icon")]
  public required string Icon { get; set; }
  [JsonPropertyName("shortForecast")]
  public required string ShortForecast { get; set; }
  [JsonPropertyName("detailedForecast")]
  public required string DetailedForecast { get; set; }

}
