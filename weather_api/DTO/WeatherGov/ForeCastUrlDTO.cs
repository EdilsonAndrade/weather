using System.Text.Json.Serialization;

internal class ForeCastUrlDTO : IForecastUrl
{
  [JsonPropertyName("properties")]
  public required Property Property { get; set; }
}
