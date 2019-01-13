using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure
{
	public class ConnectedNodeTranslator : IConnectedNodeRepository
	{


		public Task<ConnectedNode> Add(ConnectedNode node)
		{
			throw new NotImplementedException();
		}

		public Task Delete(string id)
		{
			throw new NotImplementedException();
		}

		public Task<ConnectedNode[]> ReadAll()
		{
			throw new NotImplementedException();
		}
	}



	public class ConnectedNodeEntity : TableEntity
	{
		public string FirstNode { get; set; }
		public string SecondNode { get; set; }

		public ConnectedNodeEntity()
		{
			PartitionKey = FirstNode;
			RowKey = SecondNode;
		}
	}
}
