using Campaign.Companion.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage
{
	public interface IUniverseRepository
	{
		Task<Universe> Add(Universe campaign);
		Task Delete(string id);
		Task Update(Universe universe);
		Task<Universe[]> GetUniverses(string userId);
		Task<Universe> Read(string id);
	}
}
