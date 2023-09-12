public interface IPeriodForecast
{
  public int Number { get; set; }
  public string Name { get; set; }
  public int Temperature { get; set; }
  public string TemperatureUnit { get; set; }
  public string WindSpeed { get; set; }
  public string WindDirection { get; set; }
  public string Icon { get; set; }
  public string ShortForecast { get; set; }
  public string DetailedForecast { get; set; }
}
