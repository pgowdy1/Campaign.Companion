using Campaign.Companion.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage
{
    public interface INodeAudioRepository
    {
        NodeAudio Add(NodeAudio nodeAudio);
        NodeAudio Read(int nodeAudioId);
        void Update(NodeAudio nodeAudio);
    }
}
