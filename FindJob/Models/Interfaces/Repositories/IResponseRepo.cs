using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IResponseRepo
	{
		IEnumerable<FjResponses> Responses { get; }

		Task AddResponseAsync(Resume resume, Vacancy vacancy);
		IEnumerable<FjResponses> GetResumeResponses(string userName);
		IEnumerable<FjResponses> GetVacancyResponses(string userName);
	}
}
