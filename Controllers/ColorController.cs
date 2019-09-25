using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlueGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly string color = "undefined";
        private readonly bool isBuggy;
        private readonly int buggyStatus = 503;

        public ColorController(IConfiguration configuration)
        {
            string color = configuration["color"];
            if (!string.IsNullOrEmpty(color))
            {
                this.color = color;
            }

            string buggy = configuration["buggy"];
            isBuggy = string.Equals(buggy, "true", System.StringComparison.InvariantCultureIgnoreCase);

            string status = configuration["buggy-status"];
            int.TryParse(status, out buggyStatus);
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        public ActionResult<string> Get()
        {
            if (isBuggy && new System.Random().Next(1, 101) % 4 == 0)
            {
                //timeout in about 25% of the calls
                return StatusCode(buggyStatus);
            }
            return color;
        }
    }
}
