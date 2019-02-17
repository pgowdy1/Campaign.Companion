using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage
{
    public interface IConnectedNodeRepository
    {
        Task<ConnectedNode> Add(ConnectedNode node);
        Task<ConnectedNode[]> ReadAll();
		Task Delete(string id);
    }
}
