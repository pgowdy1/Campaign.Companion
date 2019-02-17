using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage
{
	public interface INodeRepository
	{
        Task<Node> Add(Node node);
		Task Delete(string nodeId);
		Task Update(Node node);
		Task<Node> Read(string nodeId);
	}
}
