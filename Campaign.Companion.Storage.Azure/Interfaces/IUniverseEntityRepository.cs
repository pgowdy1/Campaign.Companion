using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure.Interfaces
{
	public interface IUniverseEntityRepository
	{
		Task<UniverseEntity> Add(UniverseEntity campaign);
		Task<UniverseEntity> Read(string parititonKey, string rowKey);
		Task Update(UniverseEntity universe);
		Task Delete(string parititonKey, string rowKey);
		Task<UniverseEntity[]> GetUniverses(string userId);
	}
}
