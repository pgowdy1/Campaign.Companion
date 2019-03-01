﻿using Campaign.Companion.DomainServices;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Campaign.Companion.Communication.Client.SignalR
{
	public class UniverseHub : Hub
	{
		//private readonly UniverseDomainService _universeService;

		//public UniverseHub(UniverseDomainService universeService)
		//{
		//	_universeService = universeService;
		//}

		public async Task GetUniverseId(string universeId)
		{
			await Clients.All.SendAsync("ReceiveUniverseId", "We're transmitting with SignalR");
		}

		public override async Task OnDisconnectedAsync(Exception exception)
		{
			await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
			await base.OnDisconnectedAsync(exception);
		}
	}

	//class TimerManager
	//{
	//	private Timer _timer;
	//	private AutoResetEvent _autoResetEvent;
	//	private Action _action;

	//	public DateTime TimerStarted { get; }

	//	public TimerManager(Action action)
	//	{
	//		_action = action;
	//		_autoResetEvent = new AutoResetEvent(false);
	//		_timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
	//		TimerStarted = DateTime.Now;
	//	}

	//	public void Execute(object stateInfo)
	//	{
	//		_action();

	//		if ((DateTime.Now - TimerStarted).Seconds > 60)
	//		{
	//			_timer.Dispose();
	//		}
	//	}
	//}
}
