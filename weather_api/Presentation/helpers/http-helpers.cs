using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
internal class HttpHelpers
{
  public static IActionResult BadRequest(object error)
  {
    var response = new HttpResponse
    {
      StatusCode = 400,
      Body = error
    };

    return new ObjectResult(response) { StatusCode = 400 };
  }
  public static IActionResult Success(object data)
  {
    var response = new HttpResponse
    {
      StatusCode = 200,
      Body = data
    };

    return new ObjectResult(response) { StatusCode = 200 };
  }

  public static IActionResult ServerError()
  {
    var response = new HttpResponse
    {
      StatusCode = 500,
      Body = new ServerError()
    };

    return new ObjectResult(response) { StatusCode = 500 };
  }
}

public class ServerError
{
  public string Message { get; set; } = "Internal Server Error";

}

internal class HttpResponse
{
  public int StatusCode { get; set; }
  public object? Body { get; set; }
}
