internal interface ICoordinate
{
  double Longitude { get; set; }
  double Latitude { get; set; }
}

internal interface IResult
{
  IEnumerable<AddressMatch> AddressMatches { get; set; }
}

internal interface IAddressMatches
{

  Coordinate Coordinates { get; set; }
  AddressComponent AddressComponents { get; set; }

  string MatchedAddress { get; set; }
}

interface IAddressComponents
{
  string Zip { get; set; }
  string StreetName { get; set; }
  string City { get; set; }
  string FromAddress { get; set; }
  string State { get; set; }
  string SuffixType { get; set; }

}
