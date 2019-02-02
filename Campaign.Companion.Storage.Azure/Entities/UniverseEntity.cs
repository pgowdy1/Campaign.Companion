using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
	public class UniverseEntity : TableEntity
	{
		public string UserId { get { return PartitionKey; } set { PartitionKey = value; } }
		public string Id { get { return RowKey; } set { RowKey = value; } }
		public string Name { get; set; }

		public UniverseEntity()
		{
		}

		public UniverseEntity(string userId)
		{
			UserId = userId;
			Id = Guid.NewGuid().ToString();
		}
	}
}
