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
			NodeEntity entity = new NodeEntity(node.Type);

			node.Id = entity.RowKey;
			node.Name = entity.Name;
			node.ParentNodeId = entity.ParentNodeId;
			node.Description = entity.Description;
			node.Type = entity.Type;

			await _nodeRepository.Add(entity);
			return node;
		}

		public void Delete(string nodeId)
		{
			
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

			Node node = new Node()
			{
				Id = entity.RowKey,
				Name = entity.Name,
				ParentNodeId = entity.ParentNodeId,
				Description = entity.Description,
				Type = entity.Type
			};

			return node;
		}

		public void Update(Node node)
		{
			throw new NotImplementedException();
		}
	}
}
