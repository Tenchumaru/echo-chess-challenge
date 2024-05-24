using Microsoft.AspNetCore.Mvc;

namespace Leaderboard.Server.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase {
		private static List<LeaderboardItem> items = [];

		private readonly ILogger<WeatherForecastController> _logger;

		public WeatherForecastController(ILogger<WeatherForecastController> logger) {
			_logger = logger;
		}

		[HttpGet(Name = "GetWeatherForecast")]
		public IEnumerable<LeaderboardItem> Get() {
			return items;
		}

		// POST api/<LeaderboardController>
		[HttpPost(Name = "PostWeatherForecast")]
		public void Post([FromBody] LeaderboardItem value) {
			value.Id = Guid.NewGuid().ToString();
			items.Add(value);
		}
	}
}
