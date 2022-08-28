using System.Threading.Tasks;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.Repositories
{
	public class ImageRepo : IImageRepo
	{
		protected FjDbContext Context { get; private set; }

		public ImageRepo(FjDbContext context)
		{
			Context = context;
		}

		private DbSet<FjImage> MainDbSet => Context.Images;

		public async Task AddToRepoAsync(FjImage image)
		{
			await MainDbSet.AddAsync(image);
		}
	}
}
