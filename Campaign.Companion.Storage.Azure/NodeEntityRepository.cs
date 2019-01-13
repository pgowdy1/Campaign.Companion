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
		private readonly IConfigurationProvider _configurationProvider;

		public NodeEntityRepository(IConfigurationProvider configurationProvider)
		{
			_configurationProvider = configurationProvider;

			CreateTableIfNotExist();
		}

		public void CreateTableIfNotExist()
		{
			//  ConfigurationManager.AppSettings.Get("StorageConnectionString");
			var connectionString = _configurationProvider.StorageConnectionString;

			// Retrieve the storage account from the connection string.
			CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

			// Create the table client.
			CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

			// Retrieve a reference to the table.
			_cloudTable = tableClient.GetTableReference("Nodes");

			// Create the table if it doesn't exist.
			_cloudTable.CreateIfNotExistsAsync().Wait();
		}

		public async Task<NodeEntity> Add(NodeEntity node)
		{
			TableResult tableResult = await _cloudTable.ExecuteAsync(TableOperation.Insert(node));
			return (NodeEntity)tableResult.Result;
		}

		public async Task<NodeEntity> Read(string partitionKey, string rowKey)
		{
			TableResult tableResult = await _cloudTable.ExecuteAsync(TableOperation.Retrieve<NodeEntity>(partitionKey, rowKey));
			return (NodeEntity)tableResult.Result;
		}

		public async Task Delete(string partitionKey, string rowKey)
		{
			var entity = new DynamicTableEntity(partitionKey, rowKey);
			entity.ETag = "*";

			await _cloudTable.ExecuteAsync(TableOperation.Delete(entity));
		}

		public async Task Update(NodeEntity node)
		{
			await _cloudTable.ExecuteAsync(TableOperation.Replace(node));
		}
	}
}
