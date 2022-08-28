using System.Threading.Tasks;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IImageRepo
	{
		Task AddToRepoAsync(FjImage image);
	}
}
