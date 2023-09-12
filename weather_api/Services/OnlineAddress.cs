internal class OnlineAddressService : IOnlineAddressService
{
  private readonly IOnlineAddressAdapter _onlineAddress;
  public OnlineAddressService(IOnlineAddressAdapter onlineAddress)
  {
    _onlineAddress = onlineAddress;
  }

  public async Task<IEnumerable<IAddressMatches>> Get(string fullAddress)
  {
    return await _onlineAddress.Get(fullAddress);
  }

}
