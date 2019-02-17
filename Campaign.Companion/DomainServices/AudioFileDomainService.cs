using Campaign.Companion.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.DomainServices
{
	public class AudioFileDomainService
	{
		private IAudioFileRepository _audioFileRepository;

        public AudioFileDomainService(IAudioFileRepository audioFileRepository)
        {
            _audioFileRepository = audioFileRepository;
        }

		public async Task<AudioFile> Add(AudioFile audioFile)
		{
			return await _audioFileRepository.Add(audioFile);
		}

		public async Task Delete(string universeId, string audioFileId)
		{
			await _audioFileRepository.Delete(universeId, audioFileId);
		}

		public async Task Update(AudioFile audioFile)
		{
			await _audioFileRepository.UpdateAsync(audioFile);
		}

		public async Task<AudioFile> Read(string universeId, string audioFileId)
		{
			return await _audioFileRepository.Read(universeId, audioFileId);
		}
	}
}
