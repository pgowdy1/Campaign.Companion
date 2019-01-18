using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
	public class ConnectedNodeEntity : TableEntity
	{
		//I think these two properties are useless. Discuss with Trey. 
		public string FirstNode { get; }
		public string SecondNode { get; }

		[IgnoreProperty]
		public string Id
		{
			get
			{
				return PartitionKey + "." + RowKey;
			}
		}

		public ConnectedNodeEntity(string firstNodeId, string secondNodeId)
		{
			PartitionKey = firstNodeId;
			RowKey = secondNodeId;
			FirstNode = firstNodeId;
			SecondNode = secondNodeId;
		}
	}
}
