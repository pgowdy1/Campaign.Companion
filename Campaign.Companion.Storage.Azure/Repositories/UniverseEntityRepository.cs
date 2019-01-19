using Campaign.Companion.Storage.Azure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure.Repositories
{
	public class UniverseEntityRepository : TableStorageRepository<UniverseEntity>, IUniverseEntityRepository
	{
		public UniverseEntityRepository(IConfigurationProvider configurationProvider) : base(configurationProvider) { }

		public Task<UniverseEntity[]> GetUniverses(string userId)
		{
			throw new NotImplementedException();
		}
	}
}
