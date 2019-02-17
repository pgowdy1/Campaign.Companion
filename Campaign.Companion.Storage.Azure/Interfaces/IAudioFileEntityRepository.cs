using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public interface IAudioFileEntityRepository
	{
		Task<AudioFileEntity> Add(AudioFileEntity audioFileEntity);
		Task DeleteById(string universeId, string audioFileId);
		Task<AudioFileEntity> Read(string universeId, string audioFileId);
		Task Update(AudioFileEntity entity);
	}
}
