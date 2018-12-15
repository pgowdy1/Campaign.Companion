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

		public void Add(Node node)
		{
			_nodeRepository.Add(node);
		}
	}
}
