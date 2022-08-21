using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Helper;
using FindJob.Models.Interfaces.Handler.WorkerHandlers;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Handlers.WorkerHandlers
{
	public class WorkerHandler : IWorkerHandler
	{
		private readonly IResumeRepo _resumeRepo;
		private readonly IVacancyRepo _vacancyRepo;
		private readonly IImageRepo _imageRepo;

		public WorkerHandler(IResumeRepo resumeRepo, IVacancyRepo vacancyRepo, IImageRepo imageRepo)
		{
			_resumeRepo = resumeRepo;
			_vacancyRepo = vacancyRepo;
			_imageRepo = imageRepo;
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
				
			resume.UserName = userName;
			await _resumeRepo.CreateOrUpdateAsync(resume);
		}

		public Resume GetResumeById(Guid id)
		{
			Resume resume = _resumeRepo.GetByGuid(id);
			//if (resume?.Image != null)
			//{
			//	var tempStream = new MemoryStream(resume.Image.Image);
			//	resume.FormFile = new FormFile(tempStream, 0, tempStream.Length, null, null);
			//}
			return resume;
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
