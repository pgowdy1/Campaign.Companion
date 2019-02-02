using System.Threading.Tasks;
using Campaign.Companion.Models;

namespace Campaign.Companion.Storage.Azure
{
	public interface IUserEntityRepository
	{
		Task<UserEntity> Add(UserEntity user);
		Task<UserEntity[]> ReadAll();
		Task<UserEntity> Read(string emailAddress, string password);
		Task Update(UserEntity user);
	}
}