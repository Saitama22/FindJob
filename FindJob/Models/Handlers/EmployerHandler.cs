﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.Handler;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Handlers
{
	public class EmployerHandler : IEmployerHandler
	{
		private readonly IResumeRepo _resumeRepo;
		private readonly IVacancyRepo _vacancyRepo;
		private readonly IResponseRepo _responseRepo;

		public EmployerHandler(IResumeRepo resumeRepo, IVacancyRepo vacancyRepo, IResponseRepo responseRepo)
		{
			_resumeRepo = resumeRepo;
			_vacancyRepo = vacancyRepo;
			_responseRepo = responseRepo;
		}

		public async Task AddToVacancyRepo(Vacancy vacancy, string userName)
		{
			vacancy.UserName = userName;
			await _vacancyRepo.CreateOrUpdateAsync(vacancy);
		}

		public Vacancy GetVacancyById(Guid id)
		{
			return _vacancyRepo.GetByGuid(id);
		}

		public IEnumerable<Vacancy> GetUserVacancies(string userName)
		{
			return _vacancyRepo.Vacancies.Where(r => r.UserName == userName);
		}

		public IEnumerable<Resume> GetResumes()
		{
			return _resumeRepo.Resumes;
		}

		public async Task RemoveVacancy(Guid vacancyId)
		{
			await _vacancyRepo.DeleteAsync(vacancyId);
		}

		public IEnumerable<FjResponses> GetResponses(string name)
		{
			return _responseRepo.GetVacancyResponses(name);
		}

		public Resume GetResume(Guid resumeId)
		{
			return _resumeRepo.GetByGuid(resumeId);
		}
	}
}