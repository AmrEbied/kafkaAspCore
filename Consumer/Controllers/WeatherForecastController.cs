using Microsoft.AspNetCore.Mvc;

namespace Consumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger )
        {
            _logger = logger;  
        }
        [HttpGet("/consume")]
        public IActionResult Consume()
        {
            List<string> data = new List<string>();
           

            return Ok(data);
        }

    }
}
