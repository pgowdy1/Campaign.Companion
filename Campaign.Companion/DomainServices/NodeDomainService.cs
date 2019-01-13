using Campaign.Companion.Models;
using Campaign.Companion.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.DomainServices
{
	public class NodeDomainService
	{
		private INodeRepository _nodeRepository;
        private IConnectedNodeRepository _connectedNodeRepository;
        private INodeAudioRepository _nodeAudioRepository;

		public NodeDomainService(INodeRepository nodeRepository, IConnectedNodeRepository connectedNodeRepository, INodeAudioRepository nodeAudioRepository)
		{
			_nodeRepository = nodeRepository;
            _connectedNodeRepository = connectedNodeRepository;
            _nodeAudioRepository = nodeAudioRepository;
        }

		public async Task<Node> Add(Node node)
		{
			return await _nodeRepository.Add(node);
		}

		public async Task Delete(string nodeId)
		{
			await _nodeRepository.Delete(nodeId);
		}

		public async Task Update(Node node)
		{
			await _nodeRepository.Update(node);
		}

		public async Task<Node> Read(string nodeId)
		{
			return await _nodeRepository.Read(nodeId);
		}

        public async Task ParentNode(string parentId, string childId)
        {
            var child = await _nodeRepository.Read(childId);

            child.ParentNodeId = parentId;

            await _nodeRepository.Update(child);
        }

        public async Task<ConnectedNode[]> GetConnections()
        {
            return await _connectedNodeRepository.ReadAll();
        }

        public async Task<ConnectedNode> ConnectNodes(string firstNode, string secondNode)
        {
            ConnectedNode newNode = new ConnectedNode(firstNode, secondNode);

            return await _connectedNodeRepository.Add(newNode);
        }

        public async Task RemoveConnection(string connectionId)
        {
			await _connectedNodeRepository.Delete(connectionId);
        }

        public async Task<NodeAudio> AddAudioFile(int nodeId, int audioId)
        {
            NodeAudio nodeAudio = new NodeAudio(nodeId, audioId);

            return await _nodeAudioRepository.Add(nodeAudio);
        }

        public async Task SetAudioFileShouldLoop(string nodeAudioId, bool shouldLoop)
        {
            var nodeAudio = await _nodeAudioRepository.Read(nodeAudioId);

            nodeAudio.Loop = shouldLoop;

			await _nodeAudioRepository.Update(nodeAudio);
        }

        public async Task SetAudioFileShouldAutoPlay(string nodeAudioId, bool autoPlay)
        {
            var nodeAudio = await _nodeAudioRepository.Read(nodeAudioId);

            nodeAudio.AutoPlay = autoPlay;

			await _nodeAudioRepository.Update(nodeAudio);
        }
    }
}
