using Campaign.Companion.DomainServices;
using Campaign.Companion.Storage;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
		public void Add_ShouldCallRepository()
		{
			_subject.Add(new AudioFile());
			_audioFileRepo.Verify(m => m.Add(It.IsAny<AudioFile>()));
		}

		[Test]
		public void Delete_ShouldCallRepository()
		{
			_subject.Delete(1);
			_audioFileRepo.Verify(m => m.Delete(It.IsAny<int>()));
		}

		[Test]
		public void Update_ShouldCallRepository()
		{
            var expectedAudioFile = new AudioFile() { Id = 42 };

            _subject.Update(expectedAudioFile);
			_audioFileRepo.Verify(m => m.Update(expectedAudioFile));
		}

		[Test]
		public void Read_ShouldCallRepository()
		{
			_subject.Read(1);
			_audioFileRepo.Verify(m => m.Read(It.IsAny<int>()));
		}

	}
}
