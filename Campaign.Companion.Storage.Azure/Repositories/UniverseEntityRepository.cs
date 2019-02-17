using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Campaign.Companion.Storage.Azure
{
	public class UniverseEntityRepository : TableStorageRepository<UniverseEntity>, IUniverseEntityRepository
	{
		public UniverseEntityRepository(IConfigurationProvider configurationProvider) : base(configurationProvider, "Universes") { }


		public async Task<UniverseEntity[]> ReadAllForUser(string userId)
		{
			return await GetByParitionKeyAsync(userId);
		}

		public async Task<UniverseEntity> ReadById(string id)
		{
			return (await GetByRowKeyAsync(id)).First();
		}
	}
}
