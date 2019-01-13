using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Campaign.Companion.Storage.Azure.Tests.Integration
{
	[TestFixture]
	public class NodeEntityRepositoryTests
	{
		private NodeEntityRepository _subject;
		private Mock<IConfigurationProvider> _config;

		[SetUp]
		public void Setup()
		{
			_config = new Mock<IConfigurationProvider>();
			_config.SetupGet(m => m.StorageConnectionString)
				.Returns("UseDevelopmentStorage=true");

			_subject = new NodeEntityRepository(_config.Object);
		}

		[Test]
		public async Task Add_ShouldAdd()
		{
			var entityToSave = new NodeEntity(NodeType.Location)
			{
				Description = "UnitTest.Add",
				Name = "Name",
				ParentNodeId = "Parent",
			};

			var savedEntity = await _subject.Add(entityToSave);

			savedEntity.Id.Should().Be(entityToSave.Id);
			savedEntity.Description.Should().Be(entityToSave.Description);
			savedEntity.Name.Should().Be(entityToSave.Name);
			savedEntity.ParentNodeId.Should().Be(entityToSave.ParentNodeId); 
		}

		[Test]
		public async Task Read_ShouldRead()
		{
			var entityToSave = new NodeEntity(NodeType.Location)
			{
				Description = "UnitTest.Read",
				Name = "Name",
				ParentNodeId = "Parent",
			};

			var savedEntity = await _subject.Add(entityToSave);

			var fetchedEntity = await _subject.Read("Location", entityToSave.RowKey);

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
			var entityToSave = new NodeEntity(NodeType.Location)
			{
				Description = "UnitTest.Delete",
				Name = "Name",
				ParentNodeId = "Parent",
			};

			var savedEntity = await _subject.Add(entityToSave);

			await _subject.Delete("Location", savedEntity.RowKey);

			var fetchedEntity = await _subject.Read("Location", savedEntity.RowKey);

			fetchedEntity.Should().BeNull();
		}

		[Test]
		public async Task Update_ShouldUpdate()
		{
			var entityToSave = new NodeEntity(NodeType.Location)
			{
				Description = "UnitTest.Update",
				Name = "BeforeName",
				ParentNodeId = "BeforeParent",
			};

			var savedEntity = await _subject.Add(entityToSave);

			savedEntity.Description = "UnitTest.Update.Success";
			savedEntity.Name = "AfterName";
			savedEntity.ParentNodeId = "AfterParent";

			await _subject.Update(savedEntity);

			var fetchedEntity = await _subject.Read("Location", savedEntity.RowKey);

			fetchedEntity.Description.Should().Be("UnitTest.Update.Success");
			fetchedEntity.Name.Should().Be("AfterName");
			fetchedEntity.ParentNodeId.Should().Be("AfterParent");
		}
	}
}
