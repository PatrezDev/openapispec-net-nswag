using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace openapispec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController() { }

        [HttpGet(Name = "controller-approach")]
        [ProducesResponseType<FailureResult<AuthErrorType>>(401)]
        [ProducesResponseType<Dictionary<AuthErrorType, ErrorDetail>>(403)]

        public Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        public record FailureResult<T>(Dictionary<T, ErrorDetail> Errors) where T : Enum;

        public record ErrorDetail(string Description);

        [JsonConverter(typeof(JsonStringEnumConverter<AuthErrorType>))]
        public enum AuthErrorType
        {
            InvalidCredentials,
            InvalidLogin
        }
    }
}
