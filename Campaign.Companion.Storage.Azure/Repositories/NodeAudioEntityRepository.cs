using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Campaign.Companion.Models;
using Microsoft.WindowsAzure.Storage.Table;

namespace Campaign.Companion.Storage.Azure
{
	public class NodeAudioEntityRepository : TableStorageRepository<NodeAudioEntity>, INodeAudioEntityRepository
	{
		public NodeAudioEntityRepository(IConfigurationProvider configurationProvider) : base(configurationProvider)
		{
		}

		public async Task<NodeAudioEntity[]> ReadAllForNode(string universeId, string nodeId)
		{
			var universeCondition = TableQuery.GenerateFilterCondition(PARTITION_KEY_COLUMN_NAME, QueryComparisons.Equal, universeId);
			var nodeCondition = TableQuery.GenerateFilterCondition(nameof(NodeAudioEntity.NodeId), QueryComparisons.Equal, nodeId);

			var filter = TableQuery.CombineFilters(universeCondition, TableOperators.And, nodeCondition);

			var projectionQuery = new TableQuery<NodeAudioEntity>().Where(filter);

			return await ReadMany(projectionQuery);
		}
	}
}
