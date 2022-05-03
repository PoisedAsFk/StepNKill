using System.Net.Http.Json;
using StepNKill.Smmo.Models.SmmoApi;
using StepNKill.Smmo.Models;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace StepNKill.Smmo
{
	public class SmmoDataService
	{


		public FormUrlEncodedContent? apiKey { get; set; }


		public async Task GetApiKey()
		{

			Console.WriteLine(apiKey.ToString());

		}
	}
}
