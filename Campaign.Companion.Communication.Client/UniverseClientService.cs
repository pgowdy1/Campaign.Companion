using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Communication.Client
{
	public class UniverseClientService
	{
		public string _universeId;

		public UniverseClientService()
		{

		}

		public async Task SetupReceiveUniverseId()
		{
			var connection = new HubConnectionBuilder()
				.WithUrl("http://localhost:62557/universe")
				.Build();

			connection.On<string>("ReceiveUniverseId", (message) =>
			{
				_universeId = message;
			});

			try
			{
				await connection.StartAsync();
				await connection.InvokeAsync("GetUniverse", "1");
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
