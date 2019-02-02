using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
	public abstract class UniversalEntityBase : TableEntity
	{
		public string UniverseId { get { return PartitionKey; } set { PartitionKey = value; } }
		public string Id { get { return RowKey; } set { RowKey = value; } }


		public UniversalEntityBase() { }

		public UniversalEntityBase(string universeId)
		{
			PartitionKey = universeId;
			RowKey = Guid.NewGuid().ToString();
		}
	}
}
