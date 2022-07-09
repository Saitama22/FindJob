using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IUsersRepo 
	{
		public IEnumerable<UserFj> Users { get; }

		public Task<bool> TryAddAsync(UserFj userFj);

		public bool Check(UserFj userFj);
	}
}
