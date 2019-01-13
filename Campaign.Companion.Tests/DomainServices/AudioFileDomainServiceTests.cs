using Campaign.Companion.DomainServices;
using Campaign.Companion.Storage;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Companion.Tests.DomainServices
{
	[TestFixture]
	public class AudioFileDomainServiceTests
	{
		private Mock<IAudioFileRepository> _audioFileRepo;
		private AudioFileDomainService _subject;

		[SetUp]
		public void Setup()
		{
			_audioFileRepo = new Mock<IAudioFileRepository>();
			_subject = new AudioFileDomainService(_audioFileRepo.Object);
		}

		[Test]
		public async Task Add_ShouldCallRepository()
		{
			await _subject.Add(new AudioFile());
			_audioFileRepo.Verify(m => m.Add(It.IsAny<AudioFile>()));
		}

		[Test]
		public async Task Delete_ShouldCallRepository()
		{
			await _subject.Delete("1");
			_audioFileRepo.Verify(m => m.Delete("1"));
		}

		[Test]
		public async Task Update_ShouldCallRepository()
		{
			var expectedAudioFile = new AudioFile() { Id = 42 };

			await _subject.Update(expectedAudioFile);
			_audioFileRepo.Verify(m => m.Update(expectedAudioFile));
		}

		[Test]
		public async Task Read_ShouldCallRepository()
		{
			await _subject.Read("1");
			_audioFileRepo.Verify(m => m.Read("1"));
		}

	}
}
