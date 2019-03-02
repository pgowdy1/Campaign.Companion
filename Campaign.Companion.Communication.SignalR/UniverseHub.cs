using Campaign.Companion.DomainServices;
using Campaign.Companion.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Campaign.Companion.Communication.Host.SignalR.Hubs
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
			var timerManager = new TimerManager(async () => await Clients.All.SendAsync("ReceiveUniverseId", "We're transmitting with SignalR"));
		}

		public override async Task OnDisconnectedAsync(Exception exception)
		{
			await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
			await base.OnDisconnectedAsync(exception);
		}
	}

	class TimerManager
	{
		private Timer _timer;
		private AutoResetEvent _autoResetEvent;
		private Action _action;

		public DateTime TimerStarted { get; }

		public TimerManager(Action action)
		{
			_action = action;
			_autoResetEvent = new AutoResetEvent(false);
			_timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
			TimerStarted = DateTime.Now;
		}

		public void Execute(object stateInfo)
		{
			_action();

			if ((DateTime.Now - TimerStarted).Seconds > 60)
			{
				_timer.Dispose();
			}
		}
	}
}
