using Microsoft.AspNetCore.Mvc;

namespace eBPS.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getName")] // Custom route for this endpoint
        public IActionResult GetName()
        {
            return Ok("Hello Reeza and Sangeet!");
        }

        [HttpGet("getQualification")] // Custom route for this endpoint
        public IActionResult GetQualification()
        {
            return Ok("BIM");
        }
    }
}
