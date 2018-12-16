using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage
{
	public interface IAudioFileRepository
	{
		void Add(AudioFile node);
		void Delete(int nodeId);
		void Update(int nodeId);
		AudioFile Read(int nodeId);
	}
}
