using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
	public class NodeAudioEntity : UniversalEntityBase
	{
		public string NodeId { get; set; }
		public string AudioFileId { get; set; }
		public bool AutoPlay { get; set; }
		public bool Loop { get; set; }

		public NodeAudioEntity() : base() { }

		public NodeAudioEntity(string universeId) : base(universeId)
		{
		}
	}
}
