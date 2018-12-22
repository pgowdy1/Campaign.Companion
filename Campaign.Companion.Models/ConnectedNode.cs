namespace Campaign.Companion
{
	public class ConnectedNode
	{
		public int Id { get; set; }
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }

        public ConnectedNode(int firstNodeId, int secondNodeId)
        {
            FirstNode = firstNodeId;
            SecondNode = secondNodeId;
        }
	}
}
