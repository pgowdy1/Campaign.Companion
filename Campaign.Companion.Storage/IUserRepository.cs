using Campaign.Companion.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage
{
	public interface IUserRepository
	{
		Task<User> Add(User user);
		Task Delete(string emailAddress);
		Task Update(User user);
		Task<User[]> GetUsers();
		Task<User> Read(string emailAddress);
	}
}
