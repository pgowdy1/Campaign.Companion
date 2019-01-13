using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public interface IConnectedNodeEntityRepository
	{
		Task<ConnectedNodeEntity> Add(ConnectedNodeEntity entity);
		Task DeleteById(string id);
		Task<ConnectedNodeEntity[]> ReadAll();
	}
}
