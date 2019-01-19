using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure.Repositories
{
	public class NodeEntityRepository : TableStorageRepository<NodeEntity>, INodeEntityRepository
	{
		public NodeEntityRepository(IConfigurationProvider configurationProvider) : base(configurationProvider){ }
	}
}
