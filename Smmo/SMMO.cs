namespace StepNKill.Smmo
{
	public static class SMMO
	{
		public static string PlayerEndpoint = "https://api.simple-mmo.com/v1/player/info"; //PlayerID
		public static string PlayerEquipmentEndpoint = "https://api.simple-mmo.com/v1/player/equipment"; //PlayerID
		public static string MeEndpoint = "https://api.simple-mmo.com/v1/player/me"; //No id, returs info of api key owner


		public static string GuildWarEndpoint = "https://api.simple-mmo.com/v1/guilds/wars"; //GuildID / StatusID (1 ongoing, 2 ended, 3 hold, 4 all)
		public static string GuildInfoEndpoint = "https://api.simple-mmo.com/v1/guilds/info"; //guild_id
		public static string GuildMembersEndpoint = "https://api.simple-mmo.com/v1/guilds/members"; //guild_id


		public static string DiamondMarketEndpoint = "https://api.simple-mmo.com/v1/diamond-market"; //diamonnd market
		public static string OrphanageEndpoint = "https://api.simple-mmo.com/v1/orpahange"; //orpahange ((Docs spell it liike that,,, idk))
		public static string WorldBossEndpoint = "https://api.simple-mmo.com/v1/worldboss/all"; //all worldboss
	}
}
