internal interface IOnlineAddressAdapter
{
  Task<IEnumerable<IAddressMatches>> Get(string fullAddress);
}
