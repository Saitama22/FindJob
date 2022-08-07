using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Handlers.EmployerHandlers;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Handler.EmployerHandlers
{
	public interface IEmployerHandler
	{
		Task AddToVacancyRepo(Vacancy vacancy, string userName);

		IEnumerable<Resume> GetResumes();

		IEnumerable<Vacancy> GetUserVacancies(string userName);

		Vacancy GetVacancyById(Guid id);

		Task RemoveVacancy(Guid vacancyId);
	}
}
