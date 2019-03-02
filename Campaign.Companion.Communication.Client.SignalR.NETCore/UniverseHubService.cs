using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Communication.Client.SignalR.NETCore
{
	public class UniverseHubService
	{
		public async Task Do(Action<string> responseHandler)
		{
			var connection = new HubConnectionBuilder()
			   .WithUrl("http://localhost:5000/universe")
			   .Build();

			connection.On("ReceiveUniverseId", responseHandler);

			await connection.StartAsync();


			await connection.InvokeAsync("GetUniverseId", "I'm an id.");
		}
	}
}
