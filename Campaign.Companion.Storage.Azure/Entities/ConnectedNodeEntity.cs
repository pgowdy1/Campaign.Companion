using Campaign.Companion.Storage.Azure.Entities;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
	public class ConnectedNodeEntity : UniversalEntityBase
	{
		public string FirstNodeId { get; set; }
		public string SecondNodeId { get; set; }

		public ConnectedNodeEntity() : base() { }

		public ConnectedNodeEntity(string universeId) : base(universeId)
		{
		}
	}
}