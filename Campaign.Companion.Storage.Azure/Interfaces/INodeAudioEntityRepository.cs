using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Campaign.Companion.Models;

namespace Campaign.Companion.Storage.Azure
{
	public interface INodeAudioEntityRepository
	{
		Task<NodeAudioEntity> Add(NodeAudioEntity nodeAudio);
		Task<NodeAudioEntity[]> ReadAllForNode(string universeId, string nodeId);
		Task Update(NodeAudioEntity nodeAudio);
	}
}
