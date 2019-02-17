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
		Task<NodeAudio> ReadSpecific(string universeId, string nodeId, string audioFileId);
		Task<NodeAudio[]> ReadAllForNode(string universeId, string nodeId);
		Task Update(NodeAudio nodeAudio);
	}
}
