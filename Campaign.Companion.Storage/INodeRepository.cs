using System;

namespace Campaign.Companion.Storage
{
	public interface INodeRepository
	{
		void Add(Node node);
		void Delete(int nodeId);
		void Update(int nodeId);
		Node Read(int nodeId);
	}
}
