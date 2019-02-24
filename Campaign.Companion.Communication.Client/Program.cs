using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Communication.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			new ConnectionManager();
			Console.ReadLine();
		}		
	}
}
