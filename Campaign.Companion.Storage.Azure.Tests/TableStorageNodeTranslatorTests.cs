using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure.Tests
{
	[TestFixture]
	public class TableStorageNodeTranslatorTests
	{
		private NodeTranslator _subject;
		private Mock<INodeEntityRepository> _nodeRepository;

		[SetUp]
		public void Setup()
		{
			_nodeRepository = new Mock<INodeEntityRepository>();
			_subject = new NodeTranslator(_nodeRepository.Object);
		}

		[Test]
		public async Task Add_ShouldSuccessfullyStoreTableEntity()
		{
			Node newNode = new Node()
			{
				Name = "Test Node",
				Id = "42",
				Description = "Test",
				ParentNodeId = "45",
				Type = NodeType.Entity
			};

			Node addedNode = await _subject.Add(newNode);

			_nodeRepository.Verify(m => m.Add(It.Is<NodeEntity>(n => n.Name == newNode.Name && n.RowKey == newNode.Id && n.ParentNodeId == newNode.ParentNodeId 
			&& n.Description == newNode.Description && n.Type == newNode.Type)));
		}

		[Test]
		public async Task Read_ShouldSuccessfullyReadTableEntity()
		{
			Node newNode = new Node()
			{
				Name = "Test Node",
				Id = "42",
				Description = "Test",
				ParentNodeId = "45",
				Type = NodeType.Entity
			};

			Node addedNode = await _subject.Add(newNode);

			_nodeRepository.Verify(m => m.Add(It.Is<NodeEntity>(n => n.Name == newNode.Name && n.RowKey == newNode.Id && n.ParentNodeId == newNode.ParentNodeId
			&& n.Description == newNode.Description && n.Type == newNode.Type)));
		}
	}
}
