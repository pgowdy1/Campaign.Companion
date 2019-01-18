using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public class ConnectedNodeTranslator : IConnectedNodeRepository
	{
		private readonly IConnectedNodeEntityRepository _connectedNodeRepository;

		public ConnectedNodeTranslator(IConnectedNodeEntityRepository connectedNodeRepository)
		{
			_connectedNodeRepository = connectedNodeRepository;
		}

		public async Task<ConnectedNode> Add(ConnectedNode node)
		{
			ConnectedNodeEntity addedNode = await _connectedNodeRepository.Add(new ConnectedNodeEntity(node.FirstNode, node.SecondNode));
			return Convert(addedNode);
		}

		public async Task Delete(string id)
		{
			await _connectedNodeRepository.DeleteById(id);
		}

		public async Task<ConnectedNode[]> ReadAll()
		{
			ConnectedNodeEntity[] nodes = await _connectedNodeRepository.ReadAll();
			return Convert(nodes);
		}

		private ConnectedNode Convert(ConnectedNodeEntity node)
		{
			ConnectedNode translatedNode = new ConnectedNode(node.FirstNode, node.SecondNode)
			{
				Id = node.Id,
			};

			return translatedNode;
		}

		private ConnectedNode[] Convert(ConnectedNodeEntity[] nodes)
		{
			ConnectedNode[] returnedNodes = new ConnectedNode[nodes.Length];

			for(int i = 0; i < returnedNodes.Length; i++)
			{
				returnedNodes[i] = new ConnectedNode(nodes[i].FirstNode, nodes[i].SecondNode)
				{
					Id = nodes[i].Id
				};
			}

			return returnedNodes;
		}
	}
}

