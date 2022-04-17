using StepNKill.Smmo.Models.SmmoApi;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace StepNKill.Smmo
{
	public class SmmoApiClient
	{
		private readonly HttpClient _http;
		private FormUrlEncodedContent? _apiKey;

		public async Task SetApiKey(string key)
		{
			if(!string.IsNullOrWhiteSpace(key))
			{
				var SmmoApiKeyDict = new Dictionary<string, string>() { { "api_key", key } };
				_apiKey = new FormUrlEncodedContent(SmmoApiKeyDict);
			}
		}

		private readonly JsonSerializerOptions _serializerOptions = new()
		{
			WriteIndented = true,
			DefaultIgnoreCondition = JsonIgnoreCondition.Never,
			NumberHandling = JsonNumberHandling.Strict
		};

		public SmmoApiClient(HttpClient http)
		{
			_http = http;
		}

		public async Task<SmmoApiClientResult?> GetMe()
		{
			var response = await _http.PostAsync(SMMO.MeEndpoint, _apiKey);

			var jsonResponseNode = JsonNode.Parse(await response.Content.ReadAsStreamAsync());

			var rawJsonResponse = jsonResponseNode.ToJsonString(_serializerOptions);

			var jsonResponseObject = jsonResponseNode.AsObject();

			return new SmmoApiClientResult { Success = true, SmmoApiMe = jsonResponseObject.Deserialize<SmmoApiMe>(_serializerOptions), RawJson = rawJsonResponse };
		}

		public async Task<SmmoApiClientResult?> GetPlayer(string id)
		{
			if(string.IsNullOrWhiteSpace(id))
			{
				id = "1";
			}

			var response = await _http.PostAsync($"{SMMO.PlayerEndpoint}/{id}", _apiKey);

			var jsonResponseNode = JsonNode.Parse(await response.Content.ReadAsStreamAsync());

			var rawJsonResponse = jsonResponseNode.ToJsonString(_serializerOptions);

			var jsonResponseObject = jsonResponseNode.AsObject();

			if(jsonResponseObject.ContainsKey("error"))
			{
				return new SmmoApiClientResult { Success = false, SmmoApiPlayerNotFound = jsonResponseObject.Deserialize<SmmoApiPlayerNotFound>(_serializerOptions), RawJson = rawJsonResponse };
			}

			return new SmmoApiClientResult { Success = true, SmmoApiPlayer = jsonResponseObject.Deserialize<SmmoApiPlayer>(_serializerOptions), RawJson = rawJsonResponse };
		}

		public async Task<SmmoApiClientResult?> GetGuildWars(string guildId)
		{
			if(string.IsNullOrWhiteSpace(guildId))
			{
				guildId = "828";
			}

			var response = await _http.PostAsync($"{SMMO.GuildWarEndpoint}/{guildId}/1", _apiKey);

			var jsonResponseNode = JsonNode.Parse(await response.Content.ReadAsStreamAsync());

			var rawJsonResponse = jsonResponseNode.ToJsonString(_serializerOptions);

			return new SmmoApiClientResult { Success = true, SmmoApiGuildWars = JsonSerializer.Deserialize<List<SmmoApiGuildWar>>(rawJsonResponse, _serializerOptions), RawJson = rawJsonResponse };
		}

		public async Task<SmmoApiClientResult?> GetGuildInfo(string guildId)
		{
			if(string.IsNullOrWhiteSpace(guildId))
			{
				guildId = "828";
			}

			var response = await _http.PostAsync($"{SMMO.GuildInfoEndpoint}/{guildId}", _apiKey);

			var jsonResponseNode = JsonNode.Parse(await response.Content.ReadAsStreamAsync());

			var rawJsonResponse = jsonResponseNode.ToJsonString(_serializerOptions);

			var jsonResponseObject = jsonResponseNode.AsObject();

			return new SmmoApiClientResult { Success = true, SmmoApiGuildInfo = jsonResponseObject.Deserialize<SmmoApiGuildInfo>(_serializerOptions), RawJson = rawJsonResponse };
		}
		public async Task<SmmoApiClientResult?> GetGuildMembers(string guildId)
		{
			if(string.IsNullOrWhiteSpace(guildId))
			{
				guildId = "828";
			}

			var response = await _http.PostAsync($"{SMMO.GuildMembersEndpoint}/{guildId}", _apiKey);

			var jsonResponseNode = JsonNode.Parse(await response.Content.ReadAsStreamAsync());

			var rawJsonResponse = jsonResponseNode.ToJsonString(_serializerOptions);

			return new SmmoApiClientResult { Success = true, SmmoApiGuildMembers = JsonSerializer.Deserialize<List<SmmoApiGuildMembers>>(rawJsonResponse, _serializerOptions), RawJson = rawJsonResponse };
		}

		public async Task<SmmoApiClientResult?> GetTest()
		{

			var request = new HttpRequestMessage();
			request.RequestUri = new Uri("https://web.simple-mmo.com/login");
			request.Method = HttpMethod.Get;

			var response = await _http.SendAsync(request);
			var result = await response.Content.ReadAsStringAsync();
			Console.WriteLine(result);

			Console.WriteLine(response);

			var jsonResponseNode = JsonNode.Parse(await response.Content.ReadAsStreamAsync());

			var rawJsonResponse = jsonResponseNode.ToJsonString(_serializerOptions);

			return new SmmoApiClientResult { Success = true, SmmoApiGuildMembers = JsonSerializer.Deserialize<List<SmmoApiGuildMembers>>(rawJsonResponse, _serializerOptions), RawJson = rawJsonResponse };
		}


	}
}
