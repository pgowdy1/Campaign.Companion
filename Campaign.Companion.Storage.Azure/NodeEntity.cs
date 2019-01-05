using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
    public class NodeEntity : TableEntity
    {
        public NodeEntity(int nodeId, string partitionKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = nodeId.ToString();
        }

        public NodeEntity() { }
    }
}
