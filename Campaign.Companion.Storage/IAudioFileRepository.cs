using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage
{
	public interface IAudioFileRepository
	{
		Task<AudioFile> Add(AudioFile audioFile);
		Task Delete(string universeId, string audioFileId);
		Task UpdateAsync(AudioFile audioFile);
		Task<AudioFile> Read(string universeId, string audioFileId);
	}
}
