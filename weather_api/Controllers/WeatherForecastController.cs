using Microsoft.AspNetCore.Mvc;

namespace weather_core.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<IPeriodForecast>> Get(string fullAddress)
    {
        GeoCodingOnlineAddressAdapter onlineAddressAdapter = new();

        // call the online address service with the adapter as a parameter to decouple the controller from the adapter
        OnlineAddressService onlineAddressService = new(onlineAddressAdapter);
        IEnumerable<IAddressMatches> addressMatches = await onlineAddressService.Get(fullAddress);
        if (addressMatches == null || !addressMatches.Any())
        {
            throw new Exception("Unable to retrieve location from the given address");
        }
        double longitude = addressMatches.ElementAt(0).Coordinates.Longitude;
        double latitude = addressMatches.ElementAt(0).Coordinates.Latitude;

        // call the weather gov forecast url adapter to get the url for the forecast
        WeatherGovForecastUrlAdapter weatherGovForecastUrlAdapter = new();
        WeatherForecastUrlService weatherForecastService = new(weatherGovForecastUrlAdapter);

        string weatherGovForecastUrl = await weatherForecastService.Get(latitude, longitude);
        if (string.IsNullOrEmpty(weatherGovForecastUrl))
        {
            throw new Exception("Unable to retrieve forecast url from the given coordinates");
        }

        // call the weather gov forecast service to get the forecast
        WeatherForecastAdapter weatherForecastAdapter = new();
        WeatherForecastService weatherForecast = new(weatherForecastAdapter);
        var periodForecasts = await weatherForecast.Get(weatherGovForecastUrl);
        if (periodForecasts == null || !periodForecasts.Any())
        {
            throw new Exception("Unable to retrieve forecast from the given address");
        }

        return periodForecasts;
    }


}
