using System;

namespace Campaign.Companion
{
	public class Node 
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string ParentNodeId { get; set; }
		public string Description { get; set; }
		public NodeType Type { get; set; }
	}
}
