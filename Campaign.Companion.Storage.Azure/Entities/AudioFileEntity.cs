using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
	public class AudioFileEntity : UniversalEntityBase
	{
		public string Name { get; set; }

		public AudioFileEntity()
		{
		}

		public AudioFileEntity(string universeId) : base(universeId)
		{
		}
	}
}
