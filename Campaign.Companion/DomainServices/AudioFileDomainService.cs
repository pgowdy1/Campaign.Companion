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
		//Maybe this returns the Node we added? Talk to Trey about why or why not. 
		public void Add(AudioFile node)
		{
			_audioFileRepository.Add(node);
		}

		public void Delete(int nodeId)
		{
			_audioFileRepository.Delete(nodeId);
		}

		public void Update(int nodeId)
		{
			_audioFileRepository.Update(nodeId);
		}

		public AudioFile Read(int nodeId)
		{
			return _audioFileRepository.Read(nodeId);
		}
	}
}
