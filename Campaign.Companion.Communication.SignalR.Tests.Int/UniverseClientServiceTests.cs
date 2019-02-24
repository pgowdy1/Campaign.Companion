using Campaign.Companion.Communication.Client;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Communication.SignalR.Tests.Int
{
	public class UniverseTests
	{
		UniverseClientService _universeClientService;

		[SetUp]
		public void Setup()
		{
			_universeClientService = new UniverseClientService();
		}

		[Test]
		public async Task GetUniverseID_ReturnsUniverseId()
		{
			await _universeClientService.SetupReceiveUniverseId();
			Console.WriteLine(_universeClientService._universeId);
		}
	}
}