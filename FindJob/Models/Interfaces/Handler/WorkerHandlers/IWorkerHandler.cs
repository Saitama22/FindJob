using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Handler.WorkerHandlers
{
	public interface IWorkerHandler
	{
		Resume GetResumeById(Guid id);

		Task AddToResumeRepo(Resume resume, string userName);

		IEnumerable<Resume> GetUserResumes(string userName);

		Task RemoveResume(Guid resumeId);

		IEnumerable<Vacancy> GetVacancies();
	}
}
