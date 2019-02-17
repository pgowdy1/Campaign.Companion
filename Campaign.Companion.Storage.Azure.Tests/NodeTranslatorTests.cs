using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure.Tests
{
	[TestFixture]
	public class NodeTranslatorTests
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
		public async Task Add_ShouldForwardOnAllData()
		{
			// Setup
			Node newNode = new Node()
			{
				Name = "Test Node",
				ParentNodeId = "45",
				Description = "Test",
				Type = NodeType.Entity
			};

			_nodeRepository.Setup(m => m.Add(It.IsAny<NodeEntity>()))
				.ReturnsAsync(new NodeEntity()
				{
					Name = "New Man",
					Description = "I was saved.",
					ParentNodeId = "Unknown",
					PartitionKey = "Location",
					RowKey = "Row",
				});

			// Act
			Node addedNode = await _subject.Add(newNode);

			// Assert
			_nodeRepository.Verify(m => m.Add(It.Is<NodeEntity>(n =>
				n.PartitionKey != null &&
				n.RowKey != null &&
				n.Name == "Test Node" &&
				n.ParentNodeId == "45" &&
				n.Description == "Test"
				)));

			addedNode.Name.Should().Be("New Man");
			addedNode.Description.Should().Be("I was saved.");
			addedNode.ParentNodeId.Should().Be("Unknown");
			addedNode.Id.Should().Be("Location.Row");
		}

		[Test]
		public async Task Read_ShouldSuccessfullyReadTableEntity()
		{
			_nodeRepository.Setup(m => m.Read("Location", "Myers"))
				.ReturnsAsync(new NodeEntity(NodeType.Location.ToString())
				{
					PartitionKey = "Location",
					RowKey = "Myers",
					Description = "Actor or Monster",
					Name = "Michael",
					ParentNodeId = "Orphan",
				});

			var result = await _subject.Read("Location.Myers");
			_nodeRepository.Verify(m => m.Read("Location", "Myers"));

			result.Should().BeEquivalentTo(new Node
			{
				Id = "Location.Myers",
				Name = "Michael",
				ParentNodeId = "Orphan",
				Description = "Actor or Monster",
				Type = NodeType.Location
			});
		}


		[Test]
		public async Task Read_WhenNoRecordExists_ShouldReturnNull()
		{
			_nodeRepository.Setup(m => m.Read("Location", "Meg"))
				.ReturnsAsync((NodeEntity)null);

			var result = await _subject.Read("Location.Myers");
			_nodeRepository.Verify(m => m.Read("Location", "Myers"));

			result.Should().BeNull();
		}

		[Test]
		public async Task Delete_ShouldCallRepositoryDelete()
		{
			await _subject.Delete("Entity.Die");

			_nodeRepository.Verify(m => m.Delete("Entity", "Die"));
		}

		[Test]
		public async Task Update_ShouldForwardOnAllData()
		{
			Node newNode = new Node()
			{
				Id = "Location.YourMama",
				Name = "[Insert Zip Code Here]",
				ParentNodeId = "45",
				Description = "Test",
				Type = NodeType.Location
			};

			await _subject.Update(newNode);

			_nodeRepository.Verify(m => m.Update(It.Is<NodeEntity>(n =>
				n.PartitionKey == "Location" &&
				n.RowKey == "YourMama" &&
				n.Name == "[Insert Zip Code Here]" &&
				n.ParentNodeId == "45" &&
				n.Description == "Test"
				)));
		}
	}
}
