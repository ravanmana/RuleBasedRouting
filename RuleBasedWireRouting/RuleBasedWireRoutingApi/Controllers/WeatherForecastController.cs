using Microsoft.AspNetCore.Mvc;

namespace RuleBasedWireRoutingApi.Controllers
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
        private readonly IWireRepository _wireRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWireRepository wireRepository)
        {
            _logger = logger;
            _wireRepository = wireRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var wire = new WireRequest() { 
                Amount = 100,
                DebitAccount = "11223344556",
                RequestedDate = DateTime.UtcNow
            };
            var rules = new List<IWireUpdateRule>() { 
                new AmountThresholdRule(10000),
                new DailyWireCountRule(200, _wireRepository),
                new DebitAccountRule(_wireRepository)
            };

            var updater = new WireIntermediaryUpdater(rules);

            if (updater.ShouldUpdateIntermediaryAsync(wire).GetAwaiter().GetResult())
            {
                wire.IntermediaryBank = "NEW_BANK_ID";
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}