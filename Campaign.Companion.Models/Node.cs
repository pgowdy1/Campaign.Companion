﻿using System;

namespace Campaign.Companion
{
	public class Node 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ParentNodeId { get; set; }
		public string Description { get; set; }
		public NodeType Type { get; set; }
	}
}
