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
    public async Task<IActionResult> Get(string fullAddress)
    {
        try
        {
            GeoCodingOnlineAddressAdapter onlineAddressAdapter = new();

            // call the online address service with the adapter as a parameter to decouple the controller from the adapter
            OnlineAddressService onlineAddressService = new(onlineAddressAdapter);
            IEnumerable<IAddressMatches> addressMatches = await onlineAddressService.Get(fullAddress);
            if (addressMatches == null || !addressMatches.Any())
            {

                return HttpHelpers.BadRequest(new { message = "Unable to retrieve forecast from the given address" });
            }
            double longitude = addressMatches.ElementAt(0).Coordinates.Longitude;
            double latitude = addressMatches.ElementAt(0).Coordinates.Latitude;

            // call the weather gov forecast url adapter to get the url for the forecast
            WeatherGovForecastUrlAdapter weatherGovForecastUrlAdapter = new();
            WeatherForecastUrlService weatherForecastService = new(weatherGovForecastUrlAdapter);

            string weatherGovForecastUrl = await weatherForecastService.Get(latitude, longitude);
            if (string.IsNullOrEmpty(weatherGovForecastUrl))
            {

                return HttpHelpers.BadRequest(new { message = "Unable to retrieve forecast from the given address" });
            }

            // call the weather gov forecast service to get the forecast
            WeatherForecastAdapter weatherForecastAdapter = new();
            WeatherForecastService weatherForecast = new(weatherForecastAdapter);
            var periodForecasts = await weatherForecast.Get(weatherGovForecastUrl);
            if (periodForecasts == null || !periodForecasts.Any())
            {
                return HttpHelpers.BadRequest(new { message = "Unable to retrieve forecast from the given address" });
            }

            var groupedForeCast = ForecastGroup.GroupForecast(periodForecasts);
            return HttpHelpers.Success(groupedForeCast);
        }
        catch (System.Exception)
        {
            return HttpHelpers.ServerError();
        }

    }


}
