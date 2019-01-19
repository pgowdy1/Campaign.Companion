using Campaign.Companion.Models;
using Campaign.Companion.Storage.Azure.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure.Tests
{
	public class UniverseTranslatorTests
	{
		private UniverseTranslator _subject;
		private Mock<IUniverseEntityRepository> universeRepository;

		[SetUp]
		public void Setup()
		{
			universeRepository = new Mock<IUniverseEntityRepository>();
			_subject = new UniverseTranslator(universeRepository.Object);
		}

		//[Test]
		//public async Task Add_ShouldForwardOnAllData()
		//{
		//	// Setup
		//	Universe newNode = new Universe()
		//	{
		//		Name = "ImANameForAUniverse",
		//		Creator = "ImACreator",
		//		Id = "ImAUniverseId"
		//	};

		//	universeRepository.Setup(m => m.Add(It.IsAny<UniverseEntity>()))
		//		.ReturnsAsync(new UniverseEntity()
		//		{
					
		//			PartitionKey = "Location",
		//			RowKey = "Row",
		//		});

		//	// Act
		//	Universe addedNode = await _subject.Add(newNode);

		//	// Assert
		//	universeRepository.Verify(m => m.Add(It.Is<NodeEntity>(n =>
		//		n.PartitionKey != null &&
		//		n.RowKey != null &&
		//		n.Name == "Test Node" &&
		//		n.ParentNodeId == "45" &&
		//		n.Description == "Test"
		//		)));

		//	addedNode.Name.Should().Be("New Man");
		//	addedNode.Description.Should().Be("I was saved.");
		//	addedNode.ParentNodeId.Should().Be("Unknown");
		//	addedNode.Id.Should().Be("Location.Row");
		//}

		//[Test]
		//public async Task Read_ShouldSuccessfullyReadTableEntity()
		//{
		//	universeRepository.Setup(m => m.Read("Location", "Myers"))
		//		.ReturnsAsync(new NodeEntity(NodeType.Location.ToString())
		//		{
		//			PartitionKey = "Location",
		//			RowKey = "Myers",
		//			Description = "Actor or Monster",
		//			Name = "Michael",
		//			ParentNodeId = "Orphan",
		//		});

		//	var result = await _subject.Read("Location.Myers");
		//	universeRepository.Verify(m => m.Read("Location", "Myers"));

		//	result.Should().BeEquivalentTo(new Node
		//	{
		//		Id = "Location.Myers",
		//		Name = "Michael",
		//		ParentNodeId = "Orphan",
		//		Description = "Actor or Monster",
		//		Type = NodeType.Location
		//	});
		//}


		//[Test]
		//public async Task Read_WhenNoRecordExists_ShouldReturnNull()
		//{
		//	universeRepository.Setup(m => m.Read("Location", "Meg"))
		//		.ReturnsAsync((NodeEntity)null);

		//	var result = await _subject.Read("Location.Myers");
		//	universeRepository.Verify(m => m.Read("Location", "Myers"));

		//	result.Should().BeNull();
		//}

		//[Test]
		//public async Task Delete_ShouldCallRepositoryDelete()
		//{
		//	await _subject.Delete("Entity.Die");

		//	universeRepository.Verify(m => m.Delete("Entity", "Die"));
		//}

		//[Test]
		//public async Task Update_ShouldForwardOnAllData()
		//{
		//	Node newNode = new Node()
		//	{
		//		Id = "Location.YourMama",
		//		Name = "[Insert Zip Code Here]",
		//		ParentNodeId = "45",
		//		Description = "Test",
		//		Type = NodeType.Location
		//	};

		//	await _subject.Update(newNode);

		//	universeRepository.Verify(m => m.Update(It.Is<NodeEntity>(n =>
		//		n.PartitionKey == "Location" &&
		//		n.RowKey == "YourMama" &&
		//		n.Name == "[Insert Zip Code Here]" &&
		//		n.ParentNodeId == "45" &&
		//		n.Description == "Test"
		//		)));
		//}
	}
}

