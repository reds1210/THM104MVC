using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Route("���a�ӧ�F�a/�٦��o�ؾާ@")]
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

        //[HttpGet(Name = "GetWeatherForecast")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        //[HttpGet("{id}/subject/{subject}")]
        //public WeatherForecast Get2(string id,string subject)
        //{
        //    return new WeatherForecast 
        //    {
        //        Date = DateOnly.MaxValue,
        //        TemperatureC = 32,
        //        Summary = $"id:{id}  subject:{subject}"
        //    };
        //}
        [HttpGet("/asdasd/{x:min(65)}")]
        public WeatherForecast Get2(int x)
        {
            return new WeatherForecast
            {
                Date = DateOnly.MaxValue,
                TemperatureC = 32,
                Summary = x.ToString()
            };
        }
    }
}