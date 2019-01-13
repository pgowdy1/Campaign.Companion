using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage
{
	public interface IAudioFileRepository
	{
		Task<AudioFile> Add(AudioFile audioFile);
		Task Delete(string audioFileId);
		Task Update(AudioFile audioFile);
		Task<AudioFile> Read(string audioFileId);
	}
}
