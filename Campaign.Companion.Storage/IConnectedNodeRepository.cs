using System;
using System.Collections.Generic;
using System.Text;

namespace Campaign.Companion.Storage
{
    public interface IConnectedNodeRepository
    {
        ConnectedNode Add(ConnectedNode node);
        ConnectedNode[] ReadAll();
    }
}
