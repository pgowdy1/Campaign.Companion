
namespace Campaign.Companion.Storage.Azure
{
    public class NodeEntity : UniversalEntityBase
    {
        public string Name { get; set; }
        public string ParentNodeId { get; set; }
        public string Description { get; set; }
		public string Type { get; set; }

		public NodeEntity() { }

        public NodeEntity(string universeId) : base(universeId)
        {
        }
    }
}
