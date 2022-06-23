using System.Collections;
using System.Collections.Generic;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IResumeRepo: IRepo<Resume>
	{
		public IEnumerable<Resume> Resumes { get; }
	}
}
