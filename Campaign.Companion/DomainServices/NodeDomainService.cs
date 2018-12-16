using Campaign.Companion.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.DomainServices
{
	public class NodeDomainService
	{
		private INodeRepository _nodeRepository;
		public NodeDomainService(INodeRepository nodeRepository)
		{
			_nodeRepository = nodeRepository;
		}

		//Maybe this returns the Node we added? Talk to Trey about why or why not. 
		public void Add(Node node)
		{
			_nodeRepository.Add(node);
		}

		public void Delete(int nodeId)
		{
			_nodeRepository.Delete(nodeId);
		}

		public void Update(int nodeId)
		{
			_nodeRepository.Update(nodeId);
		}

		public Node Read(int nodeId)
		{
			return _nodeRepository.Read(nodeId);
		}
	}
}
