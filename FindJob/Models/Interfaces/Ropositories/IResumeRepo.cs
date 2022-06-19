using System.Collections;
using System.Collections.Generic;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IResumeRepo
	{
		public IEnumerable<Resume> Resumes { get; }

		public void Add(Resume resume);

		public void Delete(Resume resume);
	}
}
