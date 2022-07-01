using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservice.Value.Web.Api.V1.M1.Controllers
{
    [ApiVersion("1.1")]
    [Route("api/{version:apiVersion}/values")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        private readonly ILogger<ValueController> _logger;

        public ValueController(
            ILogger<ValueController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = nameof(GetValues)), MapToApiVersion("1.1")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        public ActionResult<object> GetValues()
        {
            return Ok();
        }
    }
}
