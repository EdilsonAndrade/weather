using System.Text.Json;
using System.Web;

public class GeoCodingOnlineAddressAdapter : IOnlineAddressAdapter
{
  async Task<IEnumerable<IAddressMatches>> IOnlineAddressAdapter.Get(string fullAddress)
  {

    using HttpClient httpClient = new();
    string encodedFullAddress = HttpUtility.UrlEncode(fullAddress);
    string onlineAddressUrl = $"https://geocoding.geo.census.gov/geocoder/locations/onelineaddress?address={encodedFullAddress}&benchmark=2020&format=json";

    HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(onlineAddressUrl);
    IEnumerable<IAddressMatches> addressMatches = null!;
    if (httpResponseMessage.IsSuccessStatusCode)
    {
      string jsonContent = await httpResponseMessage.Content.ReadAsStringAsync();
      if (jsonContent != null && jsonContent.Contains("result"))
      {
        OnlineAddressDTO onlineAddressResponse = JsonSerializer.Deserialize<OnlineAddressDTO>(jsonContent)!;
        addressMatches = onlineAddressResponse.Result.AddressMatches;
      }

    }
    else
    {
      throw new Exception("Unable to retrieve location from the given address");
    }
    return addressMatches;

  }
}
