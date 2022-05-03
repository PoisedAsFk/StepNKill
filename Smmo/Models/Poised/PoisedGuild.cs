namespace StepNKill.Smmo.Models.Poised
{
	public class SnKGuildWar
	{
		public int SnKKills { get; set; }
		public int EnemyKills { get; set; }
		public int KillDifference { get; set; }
		public string EnemyGuildName { get; set; } = "Not set";
		public int EnemyGuildID { get; set; }
		public string? Status { get; set; }
	}

}
