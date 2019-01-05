using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage
{
	public interface INodeRepository
	{
        Task<Node> Add(Node node);
		void Delete(string nodeId);
		void Update(Node node);
		Task<Node> Read(string nodeId);
	}
}
