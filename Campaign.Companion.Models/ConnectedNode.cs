namespace Campaign.Companion
{
	public class ConnectedNode
	{
		public string Id { get; set; }
        public string FirstNode { get; set; }
        public string SecondNode { get; set; }

        public ConnectedNode(string firstNodeId, string secondNodeId)
        {
            FirstNode = firstNodeId;
            SecondNode = secondNodeId;
        }
	}
}
