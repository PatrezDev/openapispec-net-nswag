using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace openapispec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        public WeatherForecastController() { }

        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType<SuccessResult>(200)]
        [ProducesResponseType<FailureResult<ErrorEnumType>>(400)]
        [ProducesResponseType<FailureResult<ErrorEnumType>>(401)]
        public Task<IActionResult> Get()
        {
            return null;
        }

        public record SuccessResult(string Description);

        public record FailureResult<T>(Dictionary<T, ErrorWrapper> Errors) where T : Enum;

        public record ErrorWrapper(string Description);

        [JsonConverter(typeof(JsonStringEnumConverter<ErrorEnumType>))]
        public enum ErrorEnumType
        {
            Error400,
            Error401,
            Errir500 
        }
    }
}
