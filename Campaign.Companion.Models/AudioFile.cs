using System;
using System.IO;

namespace Campaign.Companion
{
	public class AudioFile
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public Stream File { get; set; }
    }
}
