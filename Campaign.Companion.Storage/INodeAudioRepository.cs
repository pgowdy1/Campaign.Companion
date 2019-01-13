using Campaign.Companion.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage
{
    public interface INodeAudioRepository
    {
		Task<NodeAudio> Add(NodeAudio nodeAudio);
        Task<NodeAudio> Read(string nodeAudioId);
        Task Update(NodeAudio nodeAudio);
    }
}
