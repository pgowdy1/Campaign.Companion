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
        public void Add_ShouldCallRepository()
        {
            _subject.Add(new Node());
            _nodeRepository.Verify(m => m.Add(It.IsAny<Node>()));
        }

        [Test]
        public void Delete_ShouldCallRepository()
        {
            _subject.Delete("1");
            _nodeRepository.Verify(m => m.Delete(It.IsAny<string>()));
        }

        [Test]
        public void Update_ShouldCallRepository()
        {
            // Setup
            var expectedNode = new Node() { Id = "42" };

            // Act
            _subject.Update(expectedNode);

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
        public void ConnectNodes_ShouldCreateNewConnectedNode()
        {
            // Setup
            int firstId = 666;
            int secondId = 333;

            ConnectedNode expectedConnectedNode = new ConnectedNode(666, 333);
            _connectedNodeRepository.Setup(m => m.Add(It.IsAny<ConnectedNode>())).Returns(expectedConnectedNode);

            // Act
            ConnectedNode newNode = _subject.ConnectNodes(firstId, secondId);

            // Assert
            _connectedNodeRepository.Verify(m => m.Add(It.Is<ConnectedNode>(n =>
                n.FirstNode == firstId && n.SecondNode == secondId)));

            newNode.Should().Be(expectedConnectedNode);
        }

        [Test]
        public void AddAudioFile_ShouldLinkAudioFileToNode()
        {
            // Setup
            int audioId = 666;
            int nodeId = 333;

            NodeAudio expectedNodeAudio = new NodeAudio(666, 333);
            _nodeAudioRepository.Setup(m => m.Add(It.IsAny<NodeAudio>())).Returns(expectedNodeAudio);

            // Act
            NodeAudio newNode = _subject.AddAudioFile(nodeId, audioId);

            // Assert
            _nodeAudioRepository.Verify(m => m.Add(It.Is<NodeAudio>(n =>
                n.AudioId == audioId && n.NodeId == nodeId)));

            newNode.Should().Be(expectedNodeAudio);
        }

        [Test]
        public void SetAudioFileShouldLoop_ShouldUpdateAudioFileLoop()
        {
            // Setup
            int nodeAudioId = 666;

            NodeAudio expectedNodeAudio = new NodeAudio(666, 333) { Id = nodeAudioId, Loop = false };
            _nodeAudioRepository.Setup(m => m.Read(It.IsAny<int>())).Returns(expectedNodeAudio);

            // Act
            _subject.SetAudioFileShouldLoop(nodeAudioId, true);

            // Assert
            _nodeAudioRepository.Verify(m => m.Update(It.Is<NodeAudio>(n => n.Loop == true)));
        }

        [Test]
        public void SetAudioFileShouldLoop_ShouldUpdateAudioFileAutoPlay()
        {
            // Setup
            int nodeAudioId = 666;

            NodeAudio expectedNodeAudio = new NodeAudio(666, 333) { Id = nodeAudioId, AutoPlay = false };
            _nodeAudioRepository.Setup(m => m.Read(It.IsAny<int>())).Returns(expectedNodeAudio);

            // Act
            _subject.SetAudioFileShouldAutoPlay(nodeAudioId, true);

            // Assert
            _nodeAudioRepository.Verify(m => m.Update(It.Is<NodeAudio>(n => n.AutoPlay == true)));
        }

        [Test]
        public void GetConnections_ShouldCallRepository()
        {
            // Setup
            var expectedConnections = new[] { new ConnectedNode(1, 2) { Id = 42 }, new ConnectedNode(3, 2) { Id = 43 } };
            _connectedNodeRepository.Setup(m => m.ReadAll()).Returns(expectedConnections);

            // Act
            var result = _subject.GetConnections();

            // Assert
            _connectedNodeRepository.Verify(m => m.ReadAll());
            result.Should().BeEquivalentTo(expectedConnections);
        }
    }
}
