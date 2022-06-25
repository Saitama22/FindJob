using System.Collections;
using System.Collections.Generic;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IResumeRepo: IRepo<Resume>, IGuidTable<Resume>
	{
		public IEnumerable<Resume> Resumes { get; }		
	}
}
