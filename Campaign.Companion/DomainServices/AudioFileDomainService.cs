using Campaign.Companion.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.DomainServices
{
	public class AudioFileDomainService
	{
		private IAudioFileRepository _audioFileRepository;

        public AudioFileDomainService(IAudioFileRepository audioFileRepository)
        {
            _audioFileRepository = audioFileRepository;
        }

		public AudioFile Add(AudioFile audioFile)
		{
			return _audioFileRepository.Add(audioFile);
		}

		public void Delete(int audioFileId)
		{
			_audioFileRepository.Delete(audioFileId);
		}

		public void Update(AudioFile audioFile)
		{
			_audioFileRepository.Update(audioFile);
		}

		public AudioFile Read(int audioFileId)
		{
			return _audioFileRepository.Read(audioFileId);
		}
	}
}
