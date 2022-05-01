using System.Net.Http.Json;
using StepNKill.Smmo.Models.SmmoApi;
using StepNKill.Smmo;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace StepNKill.Services
{
	public class TestingService
	{


		public FormUrlEncodedContent? _apiKey { get; set; }


		public async Task GetApiKey()
		{

			Console.WriteLine(_apiKey.ToString());

		}
	}
}
