using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
    public class NodeEntity : TableEntity
    {
        public string Name { get; set; }
        public string ParentNodeId { get; set; }
        public string Description { get; set; }
        
        public NodeEntity() { }

        public NodeEntity(string type)
        {
            PartitionKey = type.ToString();
            RowKey = Guid.NewGuid().ToString();
        }
    }
}
