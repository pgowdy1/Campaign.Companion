using NUnit.Framework;
using Campaign.Companion.DomainServices;
using System;
using Moq;
using Campaign.Companion.Storage;

namespace Campaign.Companion.Tests
{
	[TestFixture]
	public class NodeDomainServiceTests
	{
		private NodeDomainService _subject;
		Mock<INodeRepository> _nodeRepository;

		[SetUp]
		public void Setup()
		{
			_nodeRepository = new Mock<INodeRepository>();
			_subject = new NodeDomainService(_nodeRepository.Object);
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
			_subject.Delete(1);
			_nodeRepository.Verify(m => m.Delete(It.IsAny<int>()));
		}

		[Test]
		public void Update_ShouldCallRepository()
		{
			_subject.Update(1);
			_nodeRepository.Verify(m => m.Update(It.IsAny<int>()));
		}

		[Test]
		public void Read_ShouldCallRepository()
		{
			_subject.Read(1);
			_nodeRepository.Verify(m => m.Read(It.IsAny<int>()));
		}

		//I think this test might be unnecessary? If the repository is called, we're certain we'll get a Node back as it is statically typed. 
		//I guess it might also return null? Also I feel like the point of testing nodeRepository is just to ensure the methods are getting called.
		[Test]
		public void Read_CalledRepository_ShouldReturnNode()
		{
			_nodeRepository.Setup(m => m.Read(1)).Returns(It.IsAny<Node>);
		}
	}
}
