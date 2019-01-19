﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure.Repositories
{
	public class ConnectedNodeEntityRepository : TableStorageRepository<ConnectedNodeEntity>, IConnectedNodeEntityRepository
	{
		public ConnectedNodeEntityRepository(IConfigurationProvider configurationProvider) : base(configurationProvider){ }

		public Task<ConnectedNodeEntity[]> ReadAll()
		{
			throw new NotImplementedException();
		}
	}
}
