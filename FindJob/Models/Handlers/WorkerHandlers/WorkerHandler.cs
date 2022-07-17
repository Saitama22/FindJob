using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.Handler.WorkerHandlers;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Handlers.WorkerHandlers
{
	public class WorkerHandler : IWorkerHandler
	{
		private readonly IResumeRepo _resumeRepo;
		private readonly IVacancyRepo _vacancyRepo;

		public WorkerHandler(IResumeRepo resumeRepo, IVacancyRepo vacancyRepo)
		{
			_resumeRepo = resumeRepo;
			_vacancyRepo = vacancyRepo;
		}

		public async Task AddToResumeRepo(Resume resume, string userName)
		{
			resume.UserName = userName;
			await _resumeRepo.CreateOrUpdateAsync(resume);
		}

		public Resume GetResumeById(Guid id)
		{
			return _resumeRepo.GetByGuid(id);
		}

		public IEnumerable<Resume> GetUserResumes(string userName)
		{
			return _resumeRepo.Resumes.Where(r => r.UserName == userName);
		}

		public IEnumerable<Vacancy> GetVacancies()
		{
			return _vacancyRepo.Vacancies;
		}

		public async Task RemoveResume(Guid resumeId)
		{
			await _resumeRepo.DeleteAsync(resumeId);
		}
	}
}
