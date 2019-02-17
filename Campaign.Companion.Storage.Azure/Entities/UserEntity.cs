using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage.Azure
{
	public class UserEntity : TableEntity
	{
		public string Password { get { return PartitionKey; } set { PartitionKey = value; } }
		public string Email { get { return RowKey; } set { RowKey = value; } }
		public string Name { get; set; }

		public UserEntity()
		{
		}

		public UserEntity(string email, string password)
		{
			Email = email;
			Password = password;
		}
	}
}
