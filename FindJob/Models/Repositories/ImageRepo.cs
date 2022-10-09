using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.Repositories
{
	public class ImageRepo : BaseRepo<FjImage>, IImageRepo
	{
		public ImageRepo(FjDbContext context)
			: base(context)
		{
		}

		public IEnumerable<FjImage> Images => Context.Images;

		protected override DbSet<FjImage> MainDbSet => Context.Images;

		public async Task AddToRepoAsync(FjImage image)
		{
			await MainDbSet.AddAsync(image);
		}
	}
}
