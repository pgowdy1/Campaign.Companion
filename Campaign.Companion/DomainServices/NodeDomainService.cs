using Campaign.Companion.Models;
using Campaign.Companion.Storage;
using System;
using System.Collections.Generic;
using System.Text;

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

		public Node Add(Node node)
		{
			return _nodeRepository.Add(node);
		}

		public void Delete(int nodeId)
		{
			_nodeRepository.Delete(nodeId);
		}

		public void Update(Node node)
		{
			_nodeRepository.Update(node);
		}

		public Node Read(int nodeId)
		{
			return _nodeRepository.Read(nodeId);
		}

        public void ParentNode(int parentId, int childId)
        {
            var child = _nodeRepository.Read(childId);

            child.ParentNodeId = parentId;

            _nodeRepository.Update(child);
        }

        public ConnectedNode[] GetConnections()
        {
            return _connectedNodeRepository.ReadAll();
        }

        public ConnectedNode ConnectNodes(int firstNode, int secondNode)
        {
            ConnectedNode newNode = new ConnectedNode(firstNode, secondNode);

            return _connectedNodeRepository.Add(newNode);
        }

        public NodeAudio AddAudioFile(int nodeId, int audioId)
        {
            NodeAudio nodeAudio = new NodeAudio(nodeId, audioId);

            return _nodeAudioRepository.Add(nodeAudio);
        }

        public void SetAudioFileShouldLoop(int nodeAudioId, bool shouldLoop)
        {
            var nodeAudio = _nodeAudioRepository.Read(nodeAudioId);

            nodeAudio.Loop = shouldLoop;

            _nodeAudioRepository.Update(nodeAudio);
        }

        public void SetAudioFileShouldAutoPlay(int nodeAudioId, bool autoPlay)
        {
            var nodeAudio = _nodeAudioRepository.Read(nodeAudioId);

            nodeAudio.AutoPlay = autoPlay;

            _nodeAudioRepository.Update(nodeAudio);
        }
    }
}
