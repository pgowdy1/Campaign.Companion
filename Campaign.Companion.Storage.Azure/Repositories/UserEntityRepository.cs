using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Campaign.Companion.Models;

namespace Campaign.Companion.Storage.Azure.Repositories
{
	public class UserEntityRepository : TableStorageRepository<UserEntity>, IUserEntityRepository
	{
		public UserEntityRepository(IConfigurationProvider configurationProvider) : base(configurationProvider)
		{
		}
	}
}
