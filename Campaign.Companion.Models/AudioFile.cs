using System;
using System.IO;

namespace Campaign.Companion
{
	public class AudioFile
	{
		public string UniverseId { get; set; }
		public string Id { get; set; }
		public string Name { get; set; }
        public Stream File { get; set; }
	}
}
