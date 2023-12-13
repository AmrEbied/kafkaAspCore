using Microsoft.AspNetCore.Mvc;
using Producer.Model;
using Producer.Setting;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly KafkaProducer _producer; 

        public WeatherForecastController(KafkaProducer producer )
        {
            _producer = producer;
        }
        [HttpPost("/produce/Person")]
        public async Task<IActionResult> ProduceAsync([FromBody] Person person)
        {
            await _producer.ProduceAsync("Consumer.Handler.Query.PersonCommand", person);
            return Ok();
        }
        [HttpPost("/produce/Emp")]
        public async Task<IActionResult> ProduceEmpAsync([FromBody] Employee employee)
        {
            await _producer.ProduceAsync("Consumer.Handler.Query.EmployeeCommand", employee);
            return Ok();
        }
    }
}
