using System.Text.Json.Serialization;

internal class OnlineAddressDTO
{
  [JsonPropertyName("result")]
  public required Result Result { get; set; }
}
