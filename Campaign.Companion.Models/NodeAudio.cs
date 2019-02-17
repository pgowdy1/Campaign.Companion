using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Models
{
    public class NodeAudio
	{
		public string UniverseId { get; set; }
		public string Id { get; set; }
        public string NodeId { get; set; }
        public string AudioId { get; set; }
        public bool AutoPlay { get; set; }
        public bool Loop { get; set; }

        public NodeAudio(string universeId, string nodeId, string audioId)
        {
            NodeId = nodeId;
            AudioId = audioId;
			UniverseId = universeId;
		}
    }
}
