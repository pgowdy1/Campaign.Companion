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
	}
}
