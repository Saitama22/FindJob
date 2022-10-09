using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IImageRepo : IGuidTable<FjImage>
	{
		Task AddToRepoAsync(FjImage image);

		IEnumerable<FjImage> Images { get; }
	}
}
