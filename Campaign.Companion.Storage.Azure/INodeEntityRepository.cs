using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public interface INodeEntityRepository
	{
		Task Add(NodeEntity node);
		Task<NodeEntity> Read(string type, string nodeId);
	}
}