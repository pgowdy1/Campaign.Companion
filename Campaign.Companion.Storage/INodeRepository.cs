using System;

namespace Campaign.Companion.Storage
{
	public interface INodeRepository
	{
        Node Add(Node node);
		void Delete(int nodeId);
		void Update(Node node);
		Node Read(int nodeId);
	}
}
