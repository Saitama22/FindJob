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

		public WorkerHandler(IResumeRepo resumeRepo)
		{
			_resumeRepo = resumeRepo;
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

		public async Task RemoveResume(Guid resumeId)
		{
			await _resumeRepo.DeleteAsync(resumeId);
		}
	}
}
