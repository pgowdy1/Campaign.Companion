using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Campaign.Companion.Models;
using System.Linq;

namespace Campaign.Companion.Storage.Azure.Translators
{
	public class UserTranslator : IUserRepository
	{
		private IUserEntityRepository _userRepository;

		public UserTranslator(IUserEntityRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<User> Add(User user)
		{
			var entity = Convert(user);
			var addedUser = await _userRepository.Add(entity);
			return Convert(addedUser);
		}

		private User Convert(UserEntity entity)
		{
			return new User()
			{
				Email = entity.Email,
				Name = entity.Name,
				Password = entity.Password
			};
		}

		private User[] Convert(UserEntity[] entities)
		{
			return entities.Select(Convert).ToArray();
		}

		private UserEntity Convert(User entity)
		{
			return new UserEntity()
			{
				Email = entity.Email,
				Name = entity.Name,
				Password = entity.Password
			};
		}

		public async Task<User[]> GetUsers()
		{
			var entity = await _userRepository.ReadAll();
			return Convert(entity);
		}

		public async Task<User> Read(string emailAddress, string password)
		{
			var entity = await _userRepository.Read(emailAddress, password);
			return Convert(entity);
		}

		public async Task Update(User user)
		{
			await _userRepository.Update(Convert(user));
		}
	}
}
