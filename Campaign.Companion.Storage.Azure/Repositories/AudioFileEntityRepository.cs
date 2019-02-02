using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public class AudioFileEntityRepository : TableStorageRepository<AudioFileEntity>, IAudioFileEntityRepository
	{
		public AudioFileEntityRepository(IConfigurationProvider configurationProvider) : base(configurationProvider)
		{
		}

		public async Task DeleteById(string universeId, string audioFileId)
		{
			await Delete(universeId, audioFileId);
		}

		public Task<AudioFileEntity> Read(string audioFileId)
		{
			throw new NotImplementedException();
		}
	}
}
