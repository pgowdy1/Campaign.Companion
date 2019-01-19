using Campaign.Companion.Storage.Azure.Repositories;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure.Tests.Integration
{
	public class ConnectedConnectedNodeEntityRepositoryTests
	{
		ConnectedNodeEntityRepository _subject;
		Mock<IConfigurationProvider> _config; 

		[SetUp]
		public void Setup()
		{
			_config = new Mock<IConfigurationProvider>();
			_config.SetupGet(m => m.StorageConnectionString).Returns("UseDevelopmentStorage=true");

			_subject = new ConnectedNodeEntityRepository(_config.Object);
		}

		[TearDown]
		public async Task After()
		{
			await _subject.TruncateTable();
		}

		[Test]
		public async Task Add_ShouldAddToTable()
		{
			// Act
			ConnectedNodeEntity addedNode = await _subject.Add(new ConnectedNodeEntity("ImTheFirstNodeId", "ImTheSecondNodeId"));

			//Assert
			addedNode.FirstNode.Should().Be("ImTheFirstNodeId");
			addedNode.SecondNode.Should().Be("ImTheSecondNodeId");
		}

		[Test]
		public async Task Read_ShouldRead()
		{
			ConnectedNodeEntity entityToSave = new ConnectedNodeEntity("ImTheFirstNodeId", "ImTheSecondNodeId");

			var savedEntity = await _subject.Add(entityToSave);

			var fetchedEntity = await _subject.Read(savedEntity.FirstNode, savedEntity.SecondNode);

			savedEntity.Should().BeEquivalentTo(fetchedEntity);
		}

		[Test]
		public async Task Read_WhenNoRecordExists_ShouldReturnNull()
		{
			var fetchedEntity = await _subject.Read("Location", "I don't exist.");
			fetchedEntity.Should().BeNull();
		}

		[Test]
		public async Task Delete_ShouldDelete()
		{
			var entityToSave = new ConnectedNodeEntity("ImTheFirstNodeId", "ImTheSecondNodeId");
		
			var savedEntity = await _subject.Add(entityToSave);

			await _subject.Delete(savedEntity.FirstNode, savedEntity.SecondNode);

			var fetchedEntity = await _subject.Read(entityToSave.FirstNode, entityToSave.SecondNode);

			fetchedEntity.Should().BeNull();
		}

		[Test]
		public async Task Update_ShouldUpdate()
		{
			var entityToSave = new ConnectedNodeEntity("ImTheFirstNodeId", "ImTheSecondNodeId");

			var savedEntity = await _subject.Add(entityToSave);

			await _subject.Update(savedEntity);

			var fetchedEntity = await _subject.Read(savedEntity.FirstNode, savedEntity.SecondNode);

			fetchedEntity.Timestamp.Should().NotBe(savedEntity.Timestamp);
		}

		[Test]
		public async Task TruncateTable_ShouldEmptyOutTable()
		{
			var record = await _subject.Add(new ConnectedNodeEntity("ImTheFirstNodeId", "ImTheSecondNodeId"));
			var recordPulled = await _subject.Read(record.PartitionKey, record.RowKey);
			recordPulled.Should().NotBeNull();

			// Act
			await _subject.TruncateTable();

			// Assert
			recordPulled = await _subject.Read(record.PartitionKey, record.RowKey);
			recordPulled.Should().BeNull();
		}

		[Test]
		public async Task TruncateTable_ShouldAllowSubsequentAdds()
		{
			var record = await _subject.Add(new ConnectedNodeEntity("ImTheFirstNodeId", "ImTheSecondNodeId"));
			var recordPulled = await _subject.Read(record.PartitionKey, record.RowKey);
			recordPulled.Should().NotBeNull();

			// Act
			await _subject.TruncateTable();
			record = await _subject.Add(new ConnectedNodeEntity("ImTheFirstNodeId", "ImTheSecondNodeId"));

			// Assert
			recordPulled = await _subject.Read(record.PartitionKey, record.RowKey);
			recordPulled.Should().NotBeNull();
		}
	}
}
