using Campaign.Companion.Models;
using Campaign.Companion.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.DomainServices
{
	public class UniverseDomainService
	{
		private IUniverseRepository _universeRepository;
		
		public UniverseDomainService(IUniverseRepository universeRepository)
		{
			_universeRepository = universeRepository;
		}

		public async Task<Universe> Read(string universeId)
		{
			return await _universeRepository.Read(universeId);
		}
	}
}
