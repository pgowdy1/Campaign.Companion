using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure.Tests
{
	[TestFixture]
	public class ConnectedNodeTranslatorTests
	{
		private Mock<IConnectedNodeEntityRepository> _connectedNodeRepo;
		private ConnectedNodeTranslator _subject;

		[SetUp]
		public void Setup()
		{
			_connectedNodeRepo = new Mock<IConnectedNodeEntityRepository>();
			_subject = new ConnectedNodeTranslator(_connectedNodeRepo.Object);
		}

		[Test]
		public async Task Add_ShouldAddToRepo()
		{
			//Setup
			ConnectedNode newConNode = new ConnectedNode("Verse", "FirstNodeId", "SecondNodeId");

			_connectedNodeRepo.Setup(m => m.Add(It.IsAny<ConnectedNodeEntity>()))
				.ReturnsAsync(new ConnectedNodeEntity("Verse", "ImTheFirstIdOfTheReturnFromTheRepo", "ImTheSecondIdOfTheReturnFromTheRepo"));

			//Act
			var returnedNode = await _subject.Add(newConNode);

			//Assert
			_connectedNodeRepo.Verify(m => m.Add(It.Is<ConnectedNodeEntity>(n => 
				n.UniverseId == "Verse" &&
				n.FirstNodeId == "FirstNodeId" &&
				n.SecondNodeId == "SecondNodeId")));

			returnedNode.Id.Should().Be("ImTheFirstIdOfTheReturnFromTheRepo.ImTheSecondIdOfTheReturnFromTheRepo");
			returnedNode.FirstNode.Should().Be("ImTheFirstIdOfTheReturnFromTheRepo");
			returnedNode.SecondNode.Should().Be("ImTheSecondIdOfTheReturnFromTheRepo");
		}
		
		[Test]
		public async Task ReadAll_ShouldSuccessfullyReadTableEntity()
		{
			//Setup
			_connectedNodeRepo.Setup(repo => repo.ReadAll()).ReturnsAsync(SetupArrayOfConnectedNodeEntities());

			//Act
			ConnectedNode[] allNodes = await _subject.ReadAll();

			//Assert
			_connectedNodeRepo.Verify(repo => repo.ReadAll(), Times.Once);

			allNodes[0].Id.Should().Be("1stIdInTheFirstElement.2ndIdInTheFirstElement");
			allNodes[0].FirstNode.Should().Be("1stIdInTheFirstElement");
			allNodes[0].SecondNode.Should().Be("2ndIdInTheFirstElement");

			allNodes[1].Id.Should().Be("1stIdInTheSecondElement.2ndIdInTheSecondElement");
			allNodes[1].FirstNode.Should().Be("1stIdInTheSecondElement");
			allNodes[1].SecondNode.Should().Be("2ndIdInTheSecondElement");
		}

		[Test]
		public async Task ReadAll_WhenNoRecordExists_ShouldReturnEmpty()
		{
			//Setup
			_connectedNodeRepo.Setup(repo => repo.ReadAll()).ReturnsAsync(new ConnectedNodeEntity[0]);

			//Act
			ConnectedNode[] nodes = await _subject.ReadAll();

			//Assert
			_connectedNodeRepo.Verify(repo => repo.ReadAll(), Times.Once);

			nodes.Should().BeEmpty();
		}

		[Test]
		public async Task Delete_ShouldDeleteFromTable()
		{
			//Action
			await _subject.Delete("ImGoingToBeDeleted.FarewellCruelWorld");

			//Assert
			_connectedNodeRepo.Verify(repo => repo.Delete("ImGoingToBeDeleted", "FarewellCruelWorld"), Times.Once);
		}

		#region HelperMethods

		private ConnectedNodeEntity[] SetupArrayOfConnectedNodeEntities()
		{
			ConnectedNodeEntity[] nodes = new ConnectedNodeEntity[]
			{
				new ConnectedNodeEntity("Verse", "1stIdInTheFirstElement", "2ndIdInTheFirstElement"),
				new ConnectedNodeEntity("Verse", "1stIdInTheSecondElement", "2ndIdInTheSecondElement")
			};

			return nodes;
		}

		#endregion HelperMethods
	}
}
