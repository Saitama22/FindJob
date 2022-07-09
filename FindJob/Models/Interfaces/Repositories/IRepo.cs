using System.Threading.Tasks;
using FindJob.Models.DBContext;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IRepo<T>
	{
		Task CreateOrUpdateAsync(T model);

		Task DeleteAsync(T model);
	}
}
