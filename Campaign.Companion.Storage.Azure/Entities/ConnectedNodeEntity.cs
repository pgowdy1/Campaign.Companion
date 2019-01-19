using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
	public class ConnectedNodeEntity : TableEntity
	{
		public string FirstNode { get { return PartitionKey; } set { PartitionKey = value; } }
		public string SecondNode { get { return RowKey; } set { RowKey = value; } }

		public ConnectedNodeEntity() { }

		public ConnectedNodeEntity(string firstNodeId, string secondNodeId)
		{
			PartitionKey = firstNodeId;
			RowKey = secondNodeId;
		}
	}
}