using Campaign.Companion.Communication.Client.SignalR.NETCore;
using Campaign.Companion.Communication.Host.SignalR;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Communication.SignalR.Tests.Int
{
	public class UniverseTests
	{
		UniverseHubService _universeClientService;

		[SetUp]
		public void Setup()
		{
			_universeClientService = new UniverseHubService();		
		}

		[Test]
		public async Task GetUniverseID_ReturnsUniverseId()
		{
			var heardBack = false;
			await _universeClientService.Do(response =>
			{
				heardBack = true;
			});
			
			heardBack.Should().BeTrue();
		}
	}
}