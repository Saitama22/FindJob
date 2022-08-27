using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IResponseRepo
	{
		IEnumerable<FjResponses> Responses { get; }

		Task AddResponseAsync(Resume resume, Vacancy vacancy);
	}
}
