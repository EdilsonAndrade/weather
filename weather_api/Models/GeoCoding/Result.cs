using System.Text.Json.Serialization;

internal class Result : IResult
{
  [JsonPropertyName("addressMatches")]
  public required IEnumerable<AddressMatch> AddressMatches { get; set; }
}
