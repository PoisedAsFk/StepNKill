using StepNKill.Smmo.Models.Poised;
using StepNKill.Smmo.Models.SmmoApi;

namespace StepNKill.Pages
{
	public partial class Index
	{
		private string _textApiKey = "";
		private string _textBoxInputID = "";
		private string _testJson = "";

		private string _apiKey = "";
		private SmmoApiMe? _smmoApiMe;
		private long _myGuildId;

		private SmmoApiPlayer? _currentPlayer;

		private SmmoApiGuildInfo? _currentGuild;
		private List<SmmoApiGuildWar> _currentGuildWars = new List<SmmoApiGuildWar>();
		private List<SmmoApiGuildMembers> _currentGuildMembers = new List<SmmoApiGuildMembers>();

		public List<SnKGuildWar> _snkGuildWars = new List<SnKGuildWar>();


		private List<SmmoApiPlayer> _playerTargetList = new List<SmmoApiPlayer>();
		private List<SmmoApiPlayer> _playerTargetListsortbyactive = new List<SmmoApiPlayer>();
		private List<string> _attackUrls = new List<string>();


		protected override async Task OnInitializedAsync()
		{
			if(!string.IsNullOrWhiteSpace(await localStorage.GetItemAsStringAsync("smmoApi")))
			{
				_textApiKey = await localStorage.GetItemAsStringAsync("smmoApi");
				await SmmoHttp.SetApiKey(_textApiKey);
				await SendApiMeTask();
			}
			else
			{
				Console.WriteLine("No keys in storage");
			}
		}

		private async Task SendApiPlayerTask()
		{
			SmmoApiClientResult response = await SmmoHttp.GetPlayer(_textBoxInputID);
			_testJson = response.RawJson;
			if(response.Success)
			{
				_currentPlayer = response.SmmoApiPlayer;
			}
		}

		private async Task SendApiGuildWarTask()
		{
			SmmoApiClientResult response = await SmmoHttp.GetGuildWars(_textBoxInputID);
			_testJson = response.RawJson;
			_currentGuildWars = response.SmmoApiGuildWars;
		}

		private async Task SendApiMeTask()
		{
			SmmoApiClientResult response = await SmmoHttp.GetMe();
			_testJson = response.RawJson;
			if(response.Success)
			{
				await LoadApiMe(response.SmmoApiMe);
			}
		}

		private async Task SendApiGuildInfoTask()
		{
			var id = _textBoxInputID;
			SmmoApiClientResult response = await SmmoHttp.GetGuildInfo(_textBoxInputID);
			_testJson = response.RawJson;
			_currentGuild = response.SmmoApiGuildInfo;
		}

		private async Task SendApiGuildMembersTask()
		{
			var id = _textBoxInputID;
			SmmoApiClientResult response = await SmmoHttp.GetGuildMembers(_textBoxInputID);
			_testJson = response.RawJson;
			_currentGuildMembers = response.SmmoApiGuildMembers;
		}

		private async Task LoadApiMe(SmmoApiMe apiMe)
		{
			_smmoApiMe = apiMe;
			if(_smmoApiMe.Guild.Id != -1)
			{
				_myGuildId = _smmoApiMe.Guild.Id;
			}
		}

		private async Task SetSmmoKeyLocalStorage()
		{
			await localStorage.SetItemAsStringAsync("smmoApi", _textApiKey);
			await SmmoHttp.SetApiKey(_textApiKey);
		}


		private async Task DoCrazyStuffTask()
		{
			foreach(var war in _currentGuildWars)
			{
				var newWar = new SnKGuildWar();

				switch(war.Guild1.Id)
				{
					case 293:
						{
							newWar.SnKKills = war.Guild1.Kills;
							newWar.EnemyGuildID = war.Guild2.Id;
							newWar.EnemyGuildName = war.Guild2.Name;
							newWar.EnemyKills = war.Guild2.Kills;
							newWar.Status = war.Status;
							_snkGuildWars.Add(newWar);
							break;
						}

					default:
						{
							newWar.SnKKills = war.Guild2.Kills;
							newWar.EnemyGuildID = war.Guild1.Id;
							newWar.EnemyGuildName = war.Guild1.Name;
							newWar.EnemyKills = war.Guild1.Kills;
							_snkGuildWars.Add(newWar);
							break;
						}
				}


			}

		}
	}
}
