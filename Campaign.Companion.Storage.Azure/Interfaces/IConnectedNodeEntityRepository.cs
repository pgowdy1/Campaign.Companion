using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public interface IConnectedNodeEntityRepository
	{
		Task<ConnectedNodeEntity> Add(ConnectedNodeEntity entity);
		Task Delete(string partitionKey, string rowKey);
		Task<ConnectedNodeEntity[]> ReadAll();
	}
}
