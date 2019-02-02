using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public interface IUniverseEntityRepository
	{
		Task<UniverseEntity> Add(UniverseEntity campaign);
		Task<UniverseEntity[]> ReadAllForUser(string userId);
		Task<UniverseEntity> ReadById(string id);
		Task Update(UniverseEntity universe);
		Task Delete(string userId, string id);
	}
}
