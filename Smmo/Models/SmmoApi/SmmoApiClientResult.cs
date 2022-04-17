namespace StepNKill.Smmo.Models.SmmoApi
{
	public class SmmoApiClientResult
	{
		public bool Success { get; set; }

		public SmmoApiPlayer? SmmoApiPlayer { get; set; }

		public SmmoApiMe? SmmoApiMe { get; set; }

		public SmmoApiPlayerNotFound? SmmoApiPlayerNotFound { get; set; }

		public List<SmmoApiGuildWar>? SmmoApiGuildWars { get; set; }

		public List<SmmoApiGuildMembers>? SmmoApiGuildMembers { get; set; }

		public SmmoApiGuildInfo? SmmoApiGuildInfo { get; set; }

		public string RawJson { get; set; } = "";
	}
}
