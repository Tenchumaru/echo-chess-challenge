namespace Leaderboard.Server {
	public class LeaderboardItem {
		public string? Id { get; set; }
		public required string Name { get; set; }
		public int Score { get; set; }
	}
}
