using FindJob.Models.Interfaces.Repositories;
using NUnit.Framework;


namespace FindJobTests.TestModels.TestSevices
{
	public class ResumeRepoTests : BaseInitTest
    {
        [Test]
        public void GetRepoTest()
        {
            var resumeRepo = _serviceProvider.GetService<IResumeRepo>();
            Assert.IsNotNull(resumeRepo);
        }
    }
}