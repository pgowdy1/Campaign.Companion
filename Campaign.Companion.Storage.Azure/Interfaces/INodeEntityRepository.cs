using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public interface INodeEntityRepository
	{
		Task<NodeEntity> Add(NodeEntity node);
		Task<NodeEntity> Read(string partitionKey, string rowKey);
		Task Update(NodeEntity node);
		Task Delete(string partitionKey, string rowKey);
	}
}