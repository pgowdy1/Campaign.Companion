using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
    public class NodeEntityRepository : INodeEntityRepository
    {
		private CloudTable _cloudTable;

        public NodeEntityRepository()
        {
			CreateTableIfNotExist();
		}

		public async Task Add(NodeEntity node)
		{
			await _cloudTable.ExecuteAsync(TableOperation.Insert(node));
		}

		public async Task<NodeEntity> Read(string type, string nodeId)
		{
			TableResult tableResult = await _cloudTable.ExecuteAsync(TableOperation.Retrieve<NodeEntity>(type, nodeId));
			return (NodeEntity)tableResult.Result;
		}

        public void CreateTableIfNotExist()
        {
            var connectionString = ConfigurationManager.AppSettings.Get("StorageConnectionString");

            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

			// Create the table client.
			CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

			// Retrieve a reference to the table.
			_cloudTable = tableClient.GetTableReference("Nodes");

			// Create the table if it doesn't exist.
			_cloudTable.CreateIfNotExistsAsync().Wait();
		}
	}
}
