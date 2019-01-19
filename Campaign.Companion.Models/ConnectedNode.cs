namespace Campaign.Companion
{
	public class ConnectedNode
	{
        public string FirstNode { get; set; }
        public string SecondNode { get; set; }

		public string Id
		{
			get
			{
				return FirstNode + "." + SecondNode;
			}
		}

		public ConnectedNode(string firstNodeId, string secondNodeId)
        {
            FirstNode = firstNodeId;
            SecondNode = secondNodeId;
        }
	}
}
