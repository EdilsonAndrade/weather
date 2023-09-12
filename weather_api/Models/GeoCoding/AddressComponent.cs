using System.Text.Json.Serialization;

internal class AddressComponent : IAddressComponents
{
  [JsonPropertyName("zip")]
  public required string Zip { get; set; }
  [JsonPropertyName("streetName")]
  public required string StreetName { get; set; }
  [JsonPropertyName("city")]
  public required string City { get; set; }
  [JsonPropertyName("fromAddress")]
  public required string FromAddress { get; set; }
  [JsonPropertyName("state")]
  public required string State { get; set; }
  [JsonPropertyName("suffixType")]
  public required string SuffixType { get; set; }
}
