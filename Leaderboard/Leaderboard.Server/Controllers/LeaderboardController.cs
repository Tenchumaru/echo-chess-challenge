using Microsoft.AspNetCore.Mvc;

namespace Leaderboard.Server.Controllers {
	[ApiController, Route("[controller]")]
	public class LeaderboardController : ControllerBase {
		private static readonly List<LeaderboardItem> items = [];

		// GET: api/<LeaderboardController>
		[HttpGet]
		public IEnumerable<LeaderboardItem> Get() {
			return items;
		}

		// POST api/<LeaderboardController>
		[HttpPost]
		public void Post([FromBody] LeaderboardItem value) {
			value.Id = Guid.NewGuid().ToString();
			items.Add(value);
		}
	}
}
