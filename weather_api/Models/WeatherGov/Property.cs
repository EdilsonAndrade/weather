using System.Text.Json.Serialization;

public class Property
{
  [JsonPropertyName("forecast")]
  public required string Forecast { get; set; }
}
