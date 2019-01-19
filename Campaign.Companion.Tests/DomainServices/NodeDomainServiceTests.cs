using NUnit.Framework;
using Campaign.Companion.DomainServices;
using System;
using Moq;
using Campaign.Companion.Storage;
using FluentAssertions;
using Campaign.Companion.Models;
using System.Threading.Tasks;

namespace Campaign.Companion.Tests
{
	[TestFixture]
	public class NodeDomainServiceTests
	{
		private NodeDomainService _subject;
		private Mock<INodeRepository> _nodeRepository;
		private Mock<IConnectedNodeRepository> _connectedNodeRepository;
		private Mock<INodeAudioRepository> _nodeAudioRepository;

		[SetUp]
		public void Setup()
		{
			_nodeRepository = new Mock<INodeRepository>();
			_connectedNodeRepository = new Mock<IConnectedNodeRepository>();
			_nodeAudioRepository = new Mock<INodeAudioRepository>();

			_subject = new NodeDomainService(_nodeRepository.Object, _connectedNodeRepository.Object, _nodeAudioRepository.Object);
		}

		[Test]
		public async Task Add_ShouldCallRepository()
		{
			await _subject.Add(new Node());
			_nodeRepository.Verify(m => m.Add(It.IsAny<Node>()));
		}

		[Test]
		public async Task Delete_ShouldCallRepository()
		{
			await _subject.Delete("1");
			_nodeRepository.Verify(m => m.Delete(It.IsAny<string>()));
		}

		[Test]
		public async Task Update_ShouldCallRepository()
		{
			// Setup
			var expectedNode = new Node() { Id = "42" };

			// Act
			await _subject.Update(expectedNode);

			// Assert
			_nodeRepository.Verify(m => m.Update(expectedNode));
		}

		[Test]
		public async Task Read_ShouldCallRepositoryAndReturnNode()
		{
			// Setup
			var expectedNode = new Node() { Id = "42", Type = NodeType.Entity };
			_nodeRepository.Setup(m => m.Read($"42")).ReturnsAsync(expectedNode);

			// Act
			var result = await _subject.Read("42");

			// Assert
			_nodeRepository.Verify(m => m.Read($"42"));
			result.Should().Be(expectedNode);
		}

		[Test]
		public async Task ParentNode_ShouldAssignParentId()
		{
			// Setup
			string parentId = "666";
			Node childNode = new Node() { Id = "42", Type = NodeType.Entity };
			_nodeRepository.Setup(m => m.Read("42")).ReturnsAsync(childNode);

			// Act
			await _subject.ParentNode(parentId, childNode.Id);

			// Assert
			_nodeRepository.Verify(m => m.Update(It.Is<Node>(n => n.ParentNodeId == parentId && n.Id == "42")));
		}

		[Test]
		public async Task ConnectNodes_ShouldCreateNewConnectedNode()
		{
			// Setup
			string firstId = "666";
			string secondId = "333";

			ConnectedNode expectedConnectedNode = new ConnectedNode(firstId, secondId);
			_connectedNodeRepository.Setup(m => m.Add(It.IsAny<ConnectedNode>())).ReturnsAsync(expectedConnectedNode);

			// Act
			ConnectedNode newNode = await _subject.ConnectNodes(firstId, secondId);

			// Assert
			_connectedNodeRepository.Verify(m => m.Add(It.Is<ConnectedNode>(n =>
				n.FirstNode == firstId && n.SecondNode == secondId)));

			newNode.Should().Be(expectedConnectedNode);
		}

		[Test]
		public async Task RemoveConnection_ShouldCallRepoDelete()
		{
			await _subject.RemoveConnection("id");

			_connectedNodeRepository.Verify(m => m.Delete("id"));
		}

		[Test]
		public async Task AddAudioFile_ShouldLinkAudioFileToNode()
		{
			// Setup
			int audioId = 666;
			int nodeId = 333;

			NodeAudio expectedNodeAudio = new NodeAudio(666, 333);
			_nodeAudioRepository.Setup(m => m.Add(It.IsAny<NodeAudio>())).ReturnsAsync(expectedNodeAudio);

			// Act
			NodeAudio newNode = await _subject.AddAudioFile(nodeId, audioId);

			// Assert
			_nodeAudioRepository.Verify(m => m.Add(It.Is<NodeAudio>(n =>
				n.AudioId == audioId && n.NodeId == nodeId)));

			newNode.Should().Be(expectedNodeAudio);
		}

		[Test]
		public async Task SetAudioFileShouldLoop_ShouldUpdateAudioFileLoop()
		{
			// Setup
			string nodeAudioId = "666";

			NodeAudio expectedNodeAudio = new NodeAudio(666, 333) { Id = nodeAudioId, Loop = false };
			_nodeAudioRepository.Setup(m => m.Read(It.IsAny<string>())).ReturnsAsync(expectedNodeAudio);

			// Act
			await _subject.SetAudioFileShouldLoop(nodeAudioId, true);

			// Assert
			_nodeAudioRepository.Verify(m => m.Update(It.Is<NodeAudio>(n => n.Loop == true)));
		}

		[Test]
		public async Task SetAudioFileShouldLoop_ShouldUpdateAudioFileAutoPlay()
		{
			// Setup
			string nodeAudioId = "666";

			NodeAudio expectedNodeAudio = new NodeAudio(666, 333) { Id = nodeAudioId, AutoPlay = false };
			_nodeAudioRepository.Setup(m => m.Read(It.IsAny<string>())).ReturnsAsync(expectedNodeAudio);

			// Act
			await _subject.SetAudioFileShouldAutoPlay(nodeAudioId, true);

			// Assert
			_nodeAudioRepository.Verify(m => m.Update(It.Is<NodeAudio>(n => n.AutoPlay == true)));
		}

		[Test]
		public async Task GetConnections_ShouldCallRepository()
		{
			// Setup
			var expectedConnections = new[] { new ConnectedNode("1", "2"), new ConnectedNode("3", "2")};
			_connectedNodeRepository.Setup(m => m.ReadAll()).ReturnsAsync(expectedConnections);

			// Act
			var result = await _subject.GetConnections();

			// Assert
			_connectedNodeRepository.Verify(m => m.ReadAll());
			result.Should().BeEquivalentTo(expectedConnections);
		}
	}
}
