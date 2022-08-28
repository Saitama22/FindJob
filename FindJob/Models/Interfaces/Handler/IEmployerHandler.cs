using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Handler
{
	public interface IEmployerHandler
	{
		Task AddToVacancyRepo(Vacancy vacancy, string userName);
		IEnumerable<FjResponses> GetResponses(string name);
		IEnumerable<Resume> GetResumes();

		IEnumerable<Vacancy> GetUserVacancies(string userName);

		Vacancy GetVacancyById(Guid id);

		Task RemoveVacancy(Guid vacancyId);
		Resume GetResume(Guid resumeId);
	}
}
