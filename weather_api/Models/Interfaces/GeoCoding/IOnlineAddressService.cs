internal interface IOnlineAddressService
{
  Task<IEnumerable<IAddressMatches>> Get(string fullAddress);
}
