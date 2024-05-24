using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Leaderboard.Server.Controllers {
	[Route("[controller]")]
	[ApiController]
	public class LeaderboardController : ControllerBase {
		private static List<LeaderboardItem> items = [];

		// GET: api/<LeaderboardController>
		[HttpGet]
		public IEnumerable<LeaderboardItem> Get() {
			return items;
		}

		// GET api/<LeaderboardController>/5
		[HttpGet("{id}")]
		public string Get(int id) {
			return "value";
		}

		// POST api/<LeaderboardController>
		[HttpPost]
		public void Post([FromBody] LeaderboardItem value) {
			items.Add(value);
		}

		// PUT api/<LeaderboardController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value) {
		}

		// DELETE api/<LeaderboardController>/5
		[HttpDelete("{id}")]
		public void Delete(int id) {
		}
	}
}
