using System;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using NUnit.Framework;


namespace FindJobTests.TestModels.TestSevices.Repo
{
	public class ResumeRepoTests : BaseInitTest
    {
		private IResumeRepo _resumeRepo;
        Random _random = new Random();

        [Test]
        public async Task FullTest()
        {
            _resumeRepo = _serviceProvider.GetService<IResumeRepo>();
            var resume = await CreateTest();
            resume = await UpdateTest(resume);
            GetByIdTest(resume);
            await DeleteTest(resume);
        }

        public async Task<Resume> CreateTest()
        {
            Assert.IsNotNull(_resumeRepo);
            double salary = _random.Next(0, 10000);
            int expirience = _random.Next(0, 10000);
            Assert.IsNull(_resumeRepo.Resumes.FirstOrDefault(r => r.Salary == salary && r.Expirience == expirience)
                , "Неудачная генерация");
            await _resumeRepo.CreateOrUpdateAsync(new Resume
            {
                Salary = salary,
                Expirience = expirience,
            });
            var resume = _resumeRepo.Resumes.FirstOrDefault(r => r.Salary == salary && r.Expirience == expirience);
            Assert.IsNotNull(resume);
            var oldResumeId = resume.Id;
            Assert.AreNotEqual(oldResumeId, Guid.Empty);
            return resume;
        }

        public async Task<Resume> UpdateTest(Resume resume)
        {
            double? oldSalary = resume.Salary;
            int? oldExpirience = resume.Expirience;
            Guid oldResumeId = resume.Id;

            double salary = _random.Next(0, 10000);
            int expirience = _random.Next(0, 10000);
            Assert.AreNotEqual(oldSalary, salary, "Неудачная генерация");
            Assert.AreNotEqual(oldExpirience, expirience, "Неудачная генерация");
            resume.Update(new Resume()
            {
                Salary = salary,
                Expirience = expirience,
            });
            await _resumeRepo.CreateOrUpdateAsync(resume);
            Assert.AreEqual(resume.Id, oldResumeId);
            resume = _resumeRepo.Resumes.FirstOrDefault(r => r.Salary == salary && r.Expirience == expirience);
            Assert.IsNotNull(resume);
            return resume;
        }

        public void GetByIdTest(Resume resume)
        {
            var resumeById = _resumeRepo.GetByGuid(resume.Id);
            Assert.AreEqual(resume.Id, resumeById.Id);
            Assert.AreEqual(resume.Info, resumeById.Info);
            Assert.AreEqual(resume.Name, resumeById.Name);
            Assert.AreEqual(resume.Salary, resumeById.Salary);
            Assert.AreEqual(resume.Surname, resumeById.Surname);
		}

        public async Task DeleteTest(Resume resume)
        { 
			double? salary = resume.Salary;
			int? expirience = resume.Expirience;
            await _resumeRepo.DeleteAsync(resume);
			resume = _resumeRepo.Resumes.FirstOrDefault(r => r.Salary == salary && r.Expirience == expirience);
            Assert.IsNull(resume);
        }
    }
}