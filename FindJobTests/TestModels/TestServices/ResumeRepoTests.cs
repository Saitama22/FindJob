using System;
using System.Linq;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using NUnit.Framework;


namespace FindJobTests.TestModels.TestSevices
{
	public class ResumeRepoTests : BaseInitTest
    {
        [Test]
        public void CreateTest()
        {
            var resumeRepo = _serviceProvider.GetService<IResumeRepo>();
            Assert.IsNotNull(resumeRepo);
            var id = Guid.NewGuid();
            resumeRepo.Add(new Resume
            {
                Id = id,
            });
            Assert.IsNotNull(resumeRepo.Resumes.FirstOrDefault(r => r.Id == id));
        }
    }
}