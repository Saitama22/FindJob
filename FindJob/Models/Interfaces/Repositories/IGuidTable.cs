using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IGuidTable<T> : IRepo<T> where T : IIdModel
	{
		T GetByGuid(Guid guid);

		Task DeleteAsync(Guid guid);
	}
}
