using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Models
{
    public class NodeAudio
    {
        public string Id { get; set; }
        public int NodeId { get; set; }
        public int AudioId { get; set; }
        public bool AutoPlay { get; set; }
        public bool Loop { get; set; }

        public NodeAudio(int nodeId, int audioId)
        {
            NodeId = nodeId;
            AudioId = audioId;
        }
    }
}
