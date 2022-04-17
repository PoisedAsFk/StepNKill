using System.Text.Json.Serialization;

namespace StepNKill.Smmo.Models.SmmoApi
{

	public class SmmoApiPlayer
	{
		[JsonPropertyName("id")] public long Id { get; set; } = -1;

		[JsonPropertyName("name")] public string Name { get; set; } = "Not Set";

		[JsonPropertyName("level")] public long Level { get; set; } = -1;

		[JsonPropertyName("avatar")] public string Avatar { get; set; } = "Not Set";

		[JsonPropertyName("motto")] public string Motto { get; set; } = "Not Set";

		[JsonConverter(typeof(NullToEmptyStringConverter))]
		[JsonPropertyName("profile_number")] public string ProfileNumber { get; set; } = "Not Set";

		[JsonPropertyName("exp")] public long Exp { get; set; } = -1;

		[JsonConverter(typeof(UnixTimeToDateTimeOffsetConverter))]
		[JsonPropertyName("last_activity")] public DateTimeOffset LastActivity { get; set; } = default;

		[JsonPropertyName("gold")] public long Gold { get; set; } = -1;

		[JsonPropertyName("steps")] public long Steps { get; set; } = -1;

		[JsonPropertyName("npc_kills")] public long NpcKills { get; set; } = -1;

		[JsonPropertyName("user_kills")] public long UserKills { get; set; } = -1;

		[JsonPropertyName("quests_complete")] public long QuestsComplete { get; set; } = -1;

		[JsonPropertyName("quests_performed")] public long QuestsPerformed { get; set; } = -1;

		[JsonPropertyName("dex")] public long Dex { get; set; } = -1;

		[JsonPropertyName("def")] public long Def { get; set; } = -1;

		[JsonPropertyName("str")] public long Str { get; set; } = -1;

		[JsonPropertyName("bonus_dex")] public long BonusDex { get; set; } = -1;

		[JsonPropertyName("bonus_def")] public long BonusDef { get; set; } = -1;

		[JsonPropertyName("bonus_str")] public long BonusStr { get; set; } = -1;

		[JsonPropertyName("hp")] public long Hp { get; set; } = -1;

		[JsonPropertyName("max_hp")] public long MaxHp { get; set; } = -1;

		[JsonPropertyName("safeMode")] public long SafeMode { get; set; } = -1;

		[JsonPropertyName("background")] public int Background { get; set; } = -1;

		[JsonPropertyName("membership")] public long Membership { get; set; } = -1;

		[JsonPropertyName("tasks_completed")] public long TasksCompleted { get; set; } = -1;

		[JsonPropertyName("boss_kills")] public long BossKills { get; set; } = -1;

		[JsonPropertyName("market_trades")] public long MarketTrades { get; set; } = -1;

		[JsonPropertyName("reputation")] public long Reputation { get; set; } = -1;

		[JsonPropertyName("creation_date")] public DateTime CreationDate { get; set; } = default;

		[JsonPropertyName("bounties_completed")] public long BountiesCompleted { get; set; } = -1;

		[JsonConverter(typeof(FalseAndNullToLongConverter))]
		[JsonPropertyName("dailies_unlocked")] public long DailiesUnlocked { get; set; } = -1;

		[JsonPropertyName("chests_opened")] public long ChestsOpened { get; set; } = -1;

		[JsonPropertyName("current_location")] public CurrentLocation CurrentLocation { get; set; } = new CurrentLocation { Id = -1, Name = "Not set" };

		[JsonPropertyName("guild")] public Guild Guild { get; set; } = new Guild { Id = -1, Name = "not set" };
	}
	public class CurrentLocation
	{
		[JsonPropertyName("name")] public string Name { get; set; } = "Not Set";

		[JsonPropertyName("id")] public long Id { get; set; } = -1;
	}

	public class Guild
	{
		[JsonPropertyName("id")] public long Id { get; set; } = -1;

		[JsonPropertyName("name")] public string Name { get; set; } = "Not Set";
	}

	public class SmmoApiPlayerNotFound
	{
		[JsonPropertyName("error")] public string? Error { get; set; }
	}

	public class SmmoApiMe
	{
		[JsonPropertyName("id")] public long Id { get; set; } = -1;

		[JsonPropertyName("name")] public string Name { get; set; } = "Not Set";

		[JsonPropertyName("level")] public long Level { get; set; } = -1;

		[JsonPropertyName("avatar")] public string Avatar { get; set; } = "Not Set";

		[JsonPropertyName("motto")] public string Motto { get; set; } = "Not Set";

		[JsonConverter(typeof(NullToEmptyStringConverter))]
		[JsonPropertyName("profile_number")] public string ProfileNumber { get; set; } = "Not Set";

		[JsonPropertyName("exp")] public long Exp { get; set; } = -1;

		[JsonConverter(typeof(UnixTimeToDateTimeOffsetConverter))]
		[JsonPropertyName("last_activity")] public DateTimeOffset LastActivity { get; set; } = default;
		[JsonPropertyName("gold")] public long Gold { get; set; } = -1;

		[JsonPropertyName("steps")] public long Steps { get; set; } = -1;

		[JsonPropertyName("npc_kills")] public long NpcKills { get; set; } = -1;

		[JsonPropertyName("user_kills")] public long UserKills { get; set; } = -1;

		[JsonPropertyName("quests_complete")] public long QuestsComplete { get; set; } = -1;

		[JsonPropertyName("quests_performed")] public long QuestsPerformed { get; set; } = -1;

		[JsonPropertyName("dex")] public long Dex { get; set; } = -1;

		[JsonPropertyName("def")] public long Def { get; set; } = -1;

		[JsonPropertyName("str")] public long Str { get; set; } = -1;

		[JsonPropertyName("bonus_dex")] public long BonusDex { get; set; } = -1;

		[JsonPropertyName("bonus_def")] public long BonusDef { get; set; } = -1;

		[JsonPropertyName("bonus_str")] public long BonusStr { get; set; } = -1;

		[JsonPropertyName("hp")] public long Hp { get; set; } = -1;

		[JsonPropertyName("max_hp")] public long MaxHp { get; set; } = -1;

		[JsonPropertyName("safeMode")] public long SafeMode { get; set; } = -1;

		[JsonPropertyName("background")] public int Background { get; set; } = -1;

		[JsonPropertyName("membership")] public long Membership { get; set; } = -1;

		[JsonPropertyName("tasks_completed")] public long TasksCompleted { get; set; } = -1;

		[JsonPropertyName("boss_kills")] public long BossKills { get; set; } = -1;

		[JsonPropertyName("market_trades")] public long MarketTrades { get; set; } = -1;

		[JsonPropertyName("reputation")] public long Reputation { get; set; } = -1;

		[JsonPropertyName("creation_date")] public DateTime CreationDate { get; set; } = default;

		[JsonPropertyName("bounties_completed")] public long BountiesCompleted { get; set; } = -1;

		[JsonConverter(typeof(FalseAndNullToLongConverter))]
		[JsonPropertyName("dailies_unlocked")] public long DailiesUnlocked { get; set; } = -1;

		[JsonPropertyName("chests_opened")] public long ChestsOpened { get; set; } = -1;

		[JsonPropertyName("current_location")] public CurrentLocation CurrentLocation { get; set; } = new CurrentLocation { Id = -1, Name = "Not set" };

		[JsonPropertyName("guild")] public Guild Guild { get; set; } = new Guild { Id = -1, Name = "not set" };

		[JsonPropertyName("diamonds")]
		public int Diamonds { get; set; } = -1;

		[JsonPropertyName("quest_points")]
		public int QuestPoints { get; set; } = -1;

		[JsonPropertyName("maximum_quest_points")]
		public int MaximumQuestPoints { get; set; } = -1;

		[JsonPropertyName("energy")]
		public int Energy { get; set; } = -1;

		[JsonPropertyName("maximum_energy")]
		public int MaximumEnergy { get; set; } = -1;

		[JsonPropertyName("total_tasks_complete")]
		public int TotalTasksComplete { get; set; } = -1;

		[JsonPropertyName("task_complete_today")]
		public string TaskCompleteToday { get; set; } = "";

		[JsonPropertyName("safe_mode_time")]
		public DateTime SafeModeTime { get; set; } = default;
	}

}
