using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Campaign.Companion.Models;
using Campaign.Companion.Storage.Azure;

namespace Campaign.Companion.Storage.Azure
{
	public class NodeAudioTranslator : INodeAudioRepository
	{
		private readonly INodeAudioEntityRepository _nodeAudioRepository;

		public NodeAudioTranslator(INodeAudioEntityRepository nodeAudioRepository)
		{
			_nodeAudioRepository = nodeAudioRepository;
		}

		public async Task<NodeAudio> Add(NodeAudio nodeAudio)
		{
			var entity = await _nodeAudioRepository.Add(Convert(nodeAudio));
			return Convert(entity);
		}

		private NodeAudio Convert(NodeAudioEntity entity)
		{
			return new NodeAudio(entity.UniverseId, entity.NodeId, entity.AudioFileId)
			{
				AutoPlay = entity.AutoPlay,
				Loop = entity.Loop,
				Id = entity.Id
			};
		}

		private NodeAudioEntity Convert(NodeAudio nodeAudio)
		{
			return new NodeAudioEntity(nodeAudio.UniverseId)
			{
				NodeId = nodeAudio.NodeId,
				AutoPlay = nodeAudio.AutoPlay,
				Loop = nodeAudio.Loop,
				AudioFileId = nodeAudio.AudioId,
			};
		}

		public async Task<NodeAudio> Read(string universeId, string nodeId, string audioFileId)
		{
			var entity = await _nodeAudioRepository.Read(universeId, nodeId, audioFileId);
			return Convert(entity);
		}

		public async Task Update(NodeAudio nodeAudio)
		{
			await _nodeAudioRepository.Update(Convert(nodeAudio));
		}
	}
}
