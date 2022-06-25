using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IGuidTable<T> 
	{
		T GetByGuid(Guid guid);

		Task DeleteAsync(Guid guid);
	}
}
