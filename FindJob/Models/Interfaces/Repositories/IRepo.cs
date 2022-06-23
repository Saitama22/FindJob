using System.Threading.Tasks;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IRepo<T>
	{
		Task CreateOrUpdateAsync(T model);

		Task DeleteAsync(T model);
	}
}
