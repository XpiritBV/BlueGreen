using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BlueGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly string color;

        public ColorController(IConfiguration configuration)
        {
            string color = configuration["color"];
            if (!string.IsNullOrEmpty(color))
            {
                this.color = color;
            }
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        public ActionResult<string> Get()
        {
            return color;
        }
    }
}
