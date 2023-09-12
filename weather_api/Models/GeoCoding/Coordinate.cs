using System.Text.Json.Serialization;

internal class Coordinate : ICoordinate
{
  [JsonPropertyName("x")]
  public double Longitude { get; set; }
  [JsonPropertyName("y")]
  public double Latitude { get; set; }

}
