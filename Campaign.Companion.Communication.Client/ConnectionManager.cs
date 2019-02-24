using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Communication.Client
{
	class ConnectionManager
	{
		private static HubConnection _connection;
		static ConnectionManager()
		{
			
		}

		//public static HubConnection StartConnection()
		//{
			
		//	_connection.Closed += async (error) =>
		//	{
		//		await Task.Delay(new Random().Next(0, 5) * 1000);
		//		await _connection.StartAsync();
		//	};
		//}
	}
}
