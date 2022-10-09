using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Helper;
using FindJob.Models.Interfaces.Handler;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Models.Handlers
{
	public class WorkerHandler : IWorkerHandler
	{
		private readonly IResumeRepo _resumeRepo;
		private readonly IVacancyRepo _vacancyRepo;
		private readonly IImageRepo _imageRepo;
		private readonly IResponseRepo _responseRepo;
		private readonly IWorkerProfileRepo _workerProfileRepo;

		public WorkerHandler(IResumeRepo resumeRepo, IVacancyRepo vacancyRepo,
			IImageRepo imageRepo, IResponseRepo responseRepo, IWorkerProfileRepo workerProfileRepo)
		{
			_resumeRepo = resumeRepo;
			_vacancyRepo = vacancyRepo;
			_imageRepo = imageRepo;
			_responseRepo = responseRepo;
			_workerProfileRepo = workerProfileRepo;
		}

		public async Task AddResponseVacancyAsync(Guid vacancyId, string userName)
		{
			var resume = _resumeRepo.Resumes.FirstOrDefault(r => r.WorkerProfil.UserName == userName && r.IsMain);
			if (resume == null)
				return;
			var vacancy = _vacancyRepo.GetByGuid(vacancyId);
			await _responseRepo.AddResponseAsync(resume, vacancy);
		}

		public async Task AddToResumeRepo(Resume resume, string userName)
		{
			if (resume.FormFile != null)
			{
				var image = new FjImage
				{
					Id = Guid.NewGuid(),
					Image = resume.FormFile.OpenReadStream().GetBytes(),
				};
				await _imageRepo.AddToRepoAsync(image);
				resume.Image = image;
			}

			var workerProfile = _workerProfileRepo.WorkerProfils.FirstOrDefault(r => r.UserName == userName);
			resume.WorkerProfil = workerProfile;
			await _resumeRepo.CreateOrUpdateAsync(resume);
		}

		public WorkerProfile GetProfile(string name)
		{
			return _workerProfileRepo.WorkerProfils.FirstOrDefault(r => r.UserName == name);
		}

		public IEnumerable<FjResponses> GetResponses(string name)
		{
			return _responseRepo.GetResumeResponses(name);
		}

		public Resume GetResumeById(Guid id)
		{
			Resume resume = _resumeRepo.GetByGuid(id);
			return resume;
		}

		public IEnumerable<Resume> GetUserResumes(string userName)
		{
			return _resumeRepo.Resumes.Where(r => r.WorkerProfil.UserName == userName);
		}

		public IEnumerable<Vacancy> GetVacancies()
		{
			return _vacancyRepo.Vacancies;
		}

		public Vacancy GetVacancy(Guid vacancyId)
		{
			return  _vacancyRepo.Vacancies.FirstOrDefault(r => r.Id == vacancyId);
		}

		public WorkerProfile GetWorkerProfile(Guid id)
		{
			return _workerProfileRepo.GetByGuid(id);
		}

		public async Task MakeMainResumeAsync(Guid resumeId, string userName)
		{
			var mainResume = _resumeRepo.Resumes.FirstOrDefault(r => r.IsMain && r.WorkerProfil.UserName == userName);
			if (mainResume != null)
				mainResume.IsMain = false;
			var resume = _resumeRepo.GetByGuid(resumeId);
			resume.IsMain = true;
			await _resumeRepo.Save();
		}

		public async Task RemoveResume(Guid resumeId)
		{
			await _resumeRepo.DeleteAsync(resumeId);
		}

		public async Task SavePorfileAsync(WorkerProfile workerProfile)
		{
			await _workerProfileRepo.CreateOrUpdateAsync(workerProfile);
		}
	}
}
