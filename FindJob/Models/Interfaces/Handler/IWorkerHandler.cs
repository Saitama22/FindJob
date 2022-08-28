using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Models.Interfaces.Handler
{
	public interface IWorkerHandler
	{
		Resume GetResumeById(Guid id);

		Task AddToResumeRepo(Resume resume, string userName);

		IEnumerable<Resume> GetUserResumes(string userName);

		Task RemoveResume(Guid resumeId);

		IEnumerable<Vacancy> GetVacancies();

		Task MakeMainResumeAsync(Guid resumeId, string userName);
		Task AddResponseVacancyAsync(Guid vacancyId, string name);
		IEnumerable<FjResponses> GetResponses(string name);
		Vacancy GetVacancy(Guid vacancyId);
	}
}
