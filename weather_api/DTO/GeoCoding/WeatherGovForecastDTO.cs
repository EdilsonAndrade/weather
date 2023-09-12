using System.Text.Json.Serialization;

internal class WeatherGovForeCastDTO
{
  [JsonPropertyName("properties")]
  public required WeatherGovForeCastProperty Property { get; set; }

}


