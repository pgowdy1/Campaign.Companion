using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage
{
	public interface IAudioFileRepository
	{
        AudioFile Add(AudioFile audioFile);
		void Delete(int audioFileId);
		void Update(AudioFile audioFile);
		AudioFile Read(int audioFileId);
	}
}
