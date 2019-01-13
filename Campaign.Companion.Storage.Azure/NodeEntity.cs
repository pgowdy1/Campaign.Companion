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
        
        [IgnoreProperty]
        public string Id
        {
            get
            {
                return PartitionKey + "." + RowKey;
            }
        }

		[IgnoreProperty]
		public NodeType NodeType
		{
			get
			{
				return (NodeType)Enum.Parse(typeof(NodeType), PartitionKey);
			}

		}

        public NodeEntity(NodeType type)
        {
            this.PartitionKey = type.ToString();
            this.RowKey = Guid.NewGuid().ToString();
        }

        public NodeEntity() { }
    }
}
