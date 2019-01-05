using Microsoft.WindowsAzure.Storage;
using Microsoft.Azure;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;

namespace Campaign.Companion.Storage.Azure
{
    public class TableStorageNodeRepository : INodeRepository
    {
        public TableStorageNodeRepository()
        {
            CreateTableIfNotExist();
        }

        public Node Add(Node node)
        {
            throw new NotImplementedException();
        }

        public void Delete(int nodeId)
        {
            throw new NotImplementedException();
        }

        public Node Read(int nodeId)
        {
            throw new NotImplementedException();
        }

        public void Update(Node node)
        {
            throw new NotImplementedException();
        }

        public void CreateTableIfNotExist()
        {
            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Retrieve a reference to the table.
            CloudTable table = tableClient.GetTableReference("people");

            // Create the table if it doesn't exist.
            //table.CreateIfNotExists();
        }
    }
}
