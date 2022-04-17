using System.Text.Json.Serialization;

namespace StepNKill.Smmo.Models.SmmoApi
{
	public class SmmoApiGuildWar
	{
		[JsonPropertyName("guild_1")]
		public SmmoApiGuildWarGuild? Guild1 { get; set; }

		[JsonPropertyName("guild_2")]
		public SmmoApiGuildWarGuild? Guild2 { get; set; }

		[JsonPropertyName("status")]
		public string? Status { get; set; }
	}

	public class SmmoApiGuildWarGuild
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("kills")]
		public int Kills { get; set; }
	}

	public class SmmoApiGuildInfo
	{
		[JsonPropertyName("id")]
		public int Id { get; set; } = -1;

		[JsonPropertyName("name")]
		public string Name { get; set; } = "Not set";

		[JsonPropertyName("tag")]
		public string Tag { get; set; } = "Not set";

		[JsonPropertyName("owner")]
		public int GuildOwnerID { get; set; } = -1;

		[JsonPropertyName("exp")]
		public long Exp { get; set; } = -1;

		[JsonPropertyName("passive")]
		public int Passive { get; set; } = -1;

		[JsonPropertyName("icon")]
		public string Icon { get; set; } = "Not set";

		[JsonPropertyName("legacy_exp")]
		public long LegacyExp { get; set; } = -1;

		[JsonPropertyName("member_count")]
		public int MemberCount { get; set; } = -1;

		[JsonPropertyName("eligible_for_guild_war")]
		public bool EligibleForGuildWar { get; set; }
	}

	public class SmmoApiGuildMembers
	{
		[JsonPropertyName("user_id")]
		public int UserId { get; set; } = -1;

		[JsonPropertyName("position")]
		public string? GuildPosition { get; set; } = "Not set";

		[JsonPropertyName("name")]
		public string? Name { get; set; } = "Not set";

		[JsonPropertyName("level")]
		public int Level { get; set; } = -1;

		[JsonPropertyName("safe_mode")]
		public int SafeMode { get; set; } = -1;

		[JsonPropertyName("current_hp")]
		public int CurrentHp { get; set; } = -1;

		[JsonPropertyName("max_hp")]
		public int MaxHp { get; set; } = -1;

		[JsonPropertyName("steps")]
		public int Steps { get; set; } = -1;

		[JsonConverter(typeof(UnixTimeToDateTimeOffsetConverter))]
		[JsonPropertyName("last_activity")]
		public DateTimeOffset LastActivity { get; set; } = default;

		[JsonPropertyName("user_kills")]
		public int? UserKills { get; set; } = -1;

		[JsonPropertyName("npc_kills")]
		public int? NpcKills { get; set; } = -1;
	}
}
