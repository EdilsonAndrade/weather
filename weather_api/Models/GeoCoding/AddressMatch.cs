using System.Text.Json.Serialization;

internal class AddressMatch : IAddressMatches
{
  [JsonPropertyName("coordinates")]
  public required Coordinate Coordinates { get; set; }
  [JsonPropertyName("addressComponents")]
  public required AddressComponent AddressComponents { get; set; }
  [JsonPropertyName("matchedAddress")]
  public required string MatchedAddress { get; set; }
}
