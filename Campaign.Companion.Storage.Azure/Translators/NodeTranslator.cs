using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public class NodeTranslator : INodeRepository
	{
		private readonly INodeEntityRepository _nodeRepository;

		public NodeTranslator(INodeEntityRepository nodeRepository)
		{
			_nodeRepository = nodeRepository;
		}

		public async Task<Node> Add(Node node)
		{
			var entity = await _nodeRepository.Add(Convert(node));
			return Convert(entity);
		}

		public Task Delete(string nodeId)
		{
			string[] splitId = nodeId.Split(".");
			return _nodeRepository.Delete(splitId[0], splitId[1]);
		}

		public async Task<Node> Read(string nodeId)
		{
			/*
				Pattern for breaking apart nodeId
				"NodeType.Id"

				Ex. "Location.392837486"
			*/
			string[] splitId = nodeId.Split(".");
			NodeEntity entity = await _nodeRepository.Read(splitId[0], splitId[1]);
			return Convert(entity);
		}

		public async Task Update(Node node)
		{
			await _nodeRepository.Update(Convert(node));
		}

		private Node Convert(NodeEntity entity)
		{
			if (entity == null)
				return null;

			return new Node()
			{
				Id = entity.PartitionKey + "." + entity.RowKey,
				Name = entity.Name,
				ParentNodeId = entity.ParentNodeId,
				Description = entity.Description,
				Type = (NodeType)Enum.Parse(typeof(NodeType), entity.PartitionKey)
			};
		}
		private NodeEntity Convert(Node node)
		{
			if (string.IsNullOrWhiteSpace(node.Id))
			{// New
				return new NodeEntity(node.Type.ToString())
				{
					Name = node.Name,
					ParentNodeId = node.ParentNodeId,
					Description = node.Description,
				};
			}
			else
			{// Old

				string[] splitId = node.Id.Split(".");

				return new NodeEntity()
				{
					PartitionKey = splitId[0],
					RowKey = splitId[1],
					Name = node.Name,
					ParentNodeId = node.ParentNodeId,
					Description = node.Description,
				};
			}
		}
	}
}
