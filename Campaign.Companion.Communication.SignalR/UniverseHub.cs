using Campaign.Companion.DomainServices;
using Campaign.Companion.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campaign.Companion.Communication.Client.SignalR.Hubs
{
	public class UniverseHub : Hub
	{
		private readonly UniverseDomainService _universeService;

		public UniverseHub(UniverseDomainService universeService)
		{
			_universeService = universeService;
		}

		public async Task GetUniverse(string universeId)
		{
			var foundUniverse = await _universeService.Read(universeId);
			await this.Clients.All.SendAsync("ReceiveUniverseId", foundUniverse.Id);
		}
	}
}
