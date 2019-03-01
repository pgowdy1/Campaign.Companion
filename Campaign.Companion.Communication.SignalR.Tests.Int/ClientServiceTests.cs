using Campaign.Companion.Communication.Client;
using Campaign.Companion.Communication.Client.SignalR.Hubs;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Communication.SignalR.Tests.Int
{
	public class UniverseTests
	{
		//UniverseClientService _universeClientService;

		[SetUp]
		public void Setup()
		{
			//_universeClientService = new UniverseClientService();
		}

		[Test]
		public async Task GetUniverseID_ReturnsUniverseId()
		{
			var hub = new UniverseHub(null);
			await hub.GetUniverse("13");
		}
	}
}