using StepNKill.Smmo.Models.SmmoApi;

namespace StepNKill.Pages
{
	public partial class Index
	{
		private string _textBoxApikey = "";
		private string _textBoxInputID = "";
		private string _testJson = "";

		private string _apiKey = "";

		private SmmoApiMe? _smmoApiMe;
		private SmmoApiPlayer? _currentPlayer;

		private SmmoApiGuildInfo? _currentGuild;
		private List<SmmoApiGuildWar> _currentGuildWars = new List<SmmoApiGuildWar>();
		private List<SmmoApiGuildMembers> _currentGuildMembers = new List<SmmoApiGuildMembers>();

		private List<SmmoApiPlayer> _playerTargetList = new List<SmmoApiPlayer>();
		private List<SmmoApiPlayer> _playerTargetListsortbyactive = new List<SmmoApiPlayer>();
		private List<string> _attackUrls = new List<string>();


		protected override async Task OnInitializedAsync()
		{
			if(!string.IsNullOrWhiteSpace(await localStorage.GetItemAsStringAsync("smmoApi")))
			{
				_apiKey = await localStorage.GetItemAsStringAsync("smmoApi");
				await SmmoHttp.SetApiKey(_apiKey);
				Console.WriteLine("api key in storage " + _apiKey);
				_textBoxApikey = _apiKey;
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
		}

		private async Task SetSmmoKeyLocalStorage()
		{
			_apiKey = _textBoxApikey;
			await localStorage.SetItemAsStringAsync("smmoApi", _apiKey);
			await SmmoHttp.SetApiKey(_apiKey);
		}

		private async Task DoCrazyStuffTask()
		{
			SmmoApiClientResult response = await SmmoHttp.GetTest();
		}

		private async Task DoCrazyStuffTasks()
		{
			List<int> lst = new List<int> { 673520, 82453, 633709, 223617, 546975, 680319, 269230, 511638, 422718, 349989, 702459, 221091, 691413, 211276, 307465, 2281, 689944, 700353, 541771, 11376, 591625, 57343, 436536, 707615, 199313, 558143, 650801, 109606, 684375, 285756, 680457, 682955, 674677, 698475, 582010, 196297, 699036, 703939, 672668, 667112, 683132, 115762, 58699, 699503, 229709, 688394, 661723, 149488, 262982, 699804, 398348, 679208, 273070, 433897, 191135, 686962, 399113, 186924, 505413, 333404, 227001, 137488, 645790, 666321, 702993, 692693, 688942, 686920, 703123, 657275, 652555, 664369, 673446, 693314, 691727, 598357, 132889, 685782, 648418, 700463, 185269, 153990, 284198, 259046, 629334, 690116, 371247, 138817, 61859, 705035, 138982, 553193, 521459, 545808, 226008, 278995, 207539, 697489, 564786, 327743, 500838, 701036, 238864, 623755, 684585, 574393, 614407, 671963, 705090, 663103, 650866, 105873, 303328, 692767, 693794, 590921, 683466, 305824, 355746, 414272, 633725, 710114, 295671, 674121, 636800, 557018, 687372, 654580, 281627, 667794, 120456, 693166, 44134, 267456, 137869, 118698, 96377, 476712, 559758, 565118, 595082, 664675, 568687, 179704, 425340, 436610, 682030, 571354, 356162, 667648, 480050, 108245, 349258, 9165, 29324, 702136, 628317, 528042, 706080, 616272, 531422, 397461, 396280, 183344, 221974, 629302, 408516, 643470, 153886, 695174, 541672, 318392, 670014, 694717, 175083, 203711, 294550, 637145, 664569, 696158, 403677, 161948, 431331, 336194, 597761, 668891, 91208, 531226, 295036, 699920, 253821, 231297, 201766, 659414, 89914, 664124, 319244, 273938, 579992, 591246, 700471, 599466, 702604, 485561, 674163, 298491, 693730, 448540, 453352, 687228, 649792, 222666, 583836, 244537, 335929, 689298, 690294, 98896, 556151, 141416, 507144, 346452, 681939, 693277, 281308, 651185, 703568, 563761, 663933, 703016, 415022, 451984, 359766, 595136, 489801, 638218, 535027, 334659, 589292, 356800, 397641, 274483, 203249, 413401, 705654, 696766, 701975, 647381, 575376, 676513, 645463, 529427, 60781, 688073, 693903, 10173, 417348, 393133, 635320, 685324, 688146, 693606, 127456, 684285, 328162, 362206, 534208, 283447, 566494, 697718, 209939, 543608, 120665, 115929, 232377, 656190, 640696, 701205, 688526, 656450, 669418, 293977, 688907, 655220, 676790, 462146, 687242, 569046, 144610, 700195, 549420, 576349, 667511, 115355, 513477, 296353, 689030, 679626, 668982, 624076, 626321, 113275, 683025, 424629, 154805, 272063, 621152, 618046, 678492, 78024, 679867, 412607, 673008, 231334, 681898, 84731, 553167, 695693, 700370, 613468, 606064, 354203, 689272, 605110, 679557, 685325, 193274, 373602, 689053, 197436, 212785, 266746, 685187, 575067, 394820, 105097, 630121, 688783, 690289, 118864, 630168, 441979, 478356, 620467, 352117, 680980, 698371, 694810, 688232, 350276, 190869, 435508, 589419, 93891, 642457, 338385, 643442, 695546, 399022, 679970, 541305, 686383, 461648, 694497, 635369, 680020, 685231, 700223, 612500, 687185, 156322, 662763, 207275, 666809, 442573, 688052, 112698, 463860, 609446, 76939, 424867, 424996, 239752, 105095, 221727, 292010, 587625, 695439, 331577, 661283, 423212, 378280, 683655, 688463, 558677, 686928, 347632, 379720, 693002, 168603, 677009, 656814, 634727, 545639, 679139, 338754, 683985, 572793, 467270, 416694, 691755, 115357, 369876, 585462, 591804, 691349, 686301, 130736, 681804, 631652, 308144, 303479, 659128, 242440, 702741, 329593, 673828, 691238, 110482, 300537, 302053, 577786, 640978, 564427, 683800, 689290, 78728, 317976, 30776, 693522, 620765, 344963, 369533, 277087, 203439, 634820, 241696, 680583, 96069, 314661, 604795, 673231, 534451, 679353, 630725, 168751, 681766, 350059, 453557, 678646, 501818, 624257, 694863, 320600, 613053, 180615, 495839, 698773, 502294, 128844, 378627, 647492, 656481, 246703, 694418, 621460, 415314, 378427, 590580, 593403, 350842, 191632, 209100, 674994, 418798, 536891, 661279, 686560, 662363, 324702, 52155, 169783, 684864, 433118, 368095, 420925, 528850, 663268, 663720, 324910, 237966, 170126, 691503, 526841, 364233, 242707, 284004, 690259, 364319, 674642, 438043, 612111, 562132, 473383, 695360, 682299, 85418, 666316, 505948, 690326, 675373, 370684, 381282, 607819, 398386, 250755, 152351, 51375, 648187, 550484, 643133, 224398, 636195, 669509, 216948, 298517, 584629, 685774, 638340, 454817 };

			var countttt = 0;
			//send smmo api player info request for each id in list
			foreach(var listid in lst)
			{
				countttt++;
				Console.WriteLine(countttt + "/" + lst.Count + " Current ID: " + listid);

				await Task.Delay(1750);

				SmmoApiClientResult response = await SmmoHttp.GetPlayer(listid.ToString());

				if(response.Success)
				{

					if(response.SmmoApiPlayer.Gold > 1000 * 100 * 10) //1 mil
					{
						Console.WriteLine("added: " + response.SmmoApiPlayer.Name + " Gold: " + response.SmmoApiPlayer.Gold);
						_playerTargetList.Add(response.SmmoApiPlayer);
						Console.WriteLine("Targets: " + _playerTargetList.Count);

						if(response.SmmoApiPlayer.Gold > 1000 * 100 * 100) //10 mil
						{
							Console.WriteLine("HAS A LOT OF GOLD: " + response.SmmoApiPlayer.Name + " Gold: " + response.SmmoApiPlayer.Gold + "https://web.simple-mmo.com/user/attack/" + response.SmmoApiPlayer.Id + Environment.NewLine + Environment.NewLine);
						}

					}
					else
					{
						Console.WriteLine("No gold lol");
					}
				}
				else
				{
					//do something with the error
					Console.WriteLine(response.RawJson);
				}
			}

			//create new list from _playerTargetList and sort by last active
			_playerTargetListsortbyactive = _playerTargetList.OrderByDescending(x => x.LastActivity).ToList();

			//sort _playerTargetList by gold
			_playerTargetList = _playerTargetList.OrderByDescending(x => x.Gold).ToList();

			//new dictionary with player id as key and gold as value from list
			foreach(var target in _playerTargetList)
			{
				_attackUrls.Add("https://web.simple-mmo.com/user/attack/" + target.Id + " Gold: " + target.Gold + "Level: " + target.Level);
			}
			var tempString = string.Join(Environment.NewLine, _attackUrls);
			_testJson = tempString;
			Console.WriteLine(tempString);
			Console.WriteLine(tempString);
		}
	}
}
