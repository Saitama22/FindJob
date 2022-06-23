using System;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using NUnit.Framework;


namespace FindJobTests.TestModels.TestSevices
{
	public class ResumeRepoTests : BaseInitTest
    {
        [Test]
        public async Task CreateTest()
        {
            var resumeRepo = _serviceProvider.GetService<IResumeRepo>();
            Assert.IsNotNull(resumeRepo);
            Random random = new Random();
            double oldSalary = random.Next(0, 10000);
            int oldExpirience = random.Next(0, 10000);

            await resumeRepo.CreateOrUpdateAsync(new Resume
            {
                Salary = oldSalary,
                Expirience = oldExpirience,
            });            
            var resume = resumeRepo.Resumes.FirstOrDefault(r => r.Salary == oldSalary && r.Expirience == oldExpirience);
            Assert.IsNotNull(resume);
            var oldResumeId = resume.Id;
            Assert.AreNotEqual(oldResumeId, Guid.Empty);

            double salary = random.Next(0, 10000);
            int expirience = random.Next(0, 10000);
            Assert.AreNotEqual(oldSalary, salary);
            Assert.AreNotEqual(oldExpirience, expirience);
            resume.Update(new Resume()
            {
                Salary = salary,
                Expirience = expirience,
            });
            await resumeRepo.CreateOrUpdateAsync(resume);
            Assert.AreEqual(resume.Id, oldResumeId);
            resume = resumeRepo.Resumes.FirstOrDefault(r => r.Salary == salary && r.Expirience == expirience);
            Assert.IsNotNull(resume);

            await resumeRepo.DeleteAsync(resume);
            resume = resumeRepo.Resumes.FirstOrDefault(r => r.Salary == salary && r.Expirience == expirience);
            Assert.IsNull(resume);

        }
    }
}