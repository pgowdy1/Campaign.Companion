using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public class AudioFileTranslator : IAudioFileRepository
	{
		IAudioFileEntityRepository _audioFileEntityRepository;

		public AudioFileTranslator(IAudioFileEntityRepository audioFileEntityRepository)
		{
			_audioFileEntityRepository = audioFileEntityRepository;
		}

		public async Task<AudioFile> Add(AudioFile audioFile)
		{
			var entity = Convert(audioFile);
			entity = await _audioFileEntityRepository.Add(entity);

			// TODO: File

			return Convert(entity);
		}


		public async Task Delete(string audioFileId)
		{
			await _audioFileEntityRepository.DeleteById(audioFileId);

			// TODO: File
		}

		public async Task<AudioFile> Read(string universeId, string audioFileId)
		{
			var entity = await _audioFileEntityRepository.Read(universeId, audioFileId);

			// TODO: File

			return Convert(entity);
		}

		public async Task UpdateAsync(AudioFile audioFile)
		{
			var entity = Convert(audioFile);

			// TODO: File

			await _audioFileEntityRepository.Update(entity);
		}

		private AudioFile Convert(AudioFileEntity entity)
		{
			return new AudioFile
			{
				UniverseId = entity.UniverseId,
				Id = entity.Id,
				Name = entity.Name,
				File = null
				// TODO: File
			};
		}

		private AudioFileEntity Convert(AudioFile entity)
		{
			// TODO: File

			return new AudioFileEntity
			{
				UniverseId = entity.UniverseId,
				Id = entity.Id,
				Name = entity.Name,
			};
		}

	}
}
