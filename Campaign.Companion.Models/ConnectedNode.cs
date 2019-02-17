namespace Campaign.Companion
{
	public class ConnectedNode
	{
		public string UniverseId { get; set; }
		public string FirstNode { get; set; }
        public string SecondNode { get; set; }

		public string Id
		{
			get
			{
				return FirstNode + "." + SecondNode;
			}
		}

		public ConnectedNode(string universeId, string firstNodeId, string secondNodeId)
        {
			UniverseId = universeId;
			FirstNode = firstNodeId;
            SecondNode = secondNodeId;
        }
	}
}
