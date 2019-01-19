﻿using System;
using System.Threading.Tasks;
using System.Linq;

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
			return nodes.Select(Convert).ToArray();
		}

		private ConnectedNode Convert(ConnectedNodeEntity node)
		{
			return new ConnectedNode(node.FirstNode, node.SecondNode);
		}
	}
}

