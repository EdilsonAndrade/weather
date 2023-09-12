namespace weather_core;

internal class WeatherForecast : IPeriodForecast
{
    public int Number { get; set; }
    public required string Name { get; set; }
    public required int Temperature { get; set; }
    public required string TemperatureUnit { get; set; }
    public required string WindSpeed { get; set; }
    public required string WindDirection { get; set; }
    public required string Icon { get; set; }
    public required string ShortForecast { get; set; }
    public required string DetailedForecast { get; set; }
}
