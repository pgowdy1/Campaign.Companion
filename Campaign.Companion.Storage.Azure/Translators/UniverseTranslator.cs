using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Campaign.Companion.Models;
using Campaign.Companion.Storage.Azure.Interfaces;

namespace Campaign.Companion.Storage.Azure
{
	public class UniverseTranslator : IUniverseRepository
	{
		private IUniverseEntityRepository _universeRepo;

		public UniverseTranslator(IUniverseEntityRepository universeRepo)
		{
			_universeRepo = universeRepo;
		}

		public Task<Universe> Add(Universe campaign)
		{
			throw new NotImplementedException();
		}

		public Task Delete(string id)
		{
			throw new NotImplementedException();
		}

		public Task<Universe[]> GetUniverses(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<Universe> Read(string nodeId)
		{
			throw new NotImplementedException();
		}

		public Task Update(Universe universe)
		{
			throw new NotImplementedException();
		}
	}
}
