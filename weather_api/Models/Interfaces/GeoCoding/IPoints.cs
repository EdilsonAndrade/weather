internal interface Properties
{
  string Forecast { get; set; }
}

internal interface IPoints
{
  Properties Get(string latitude, string longitude);
}
