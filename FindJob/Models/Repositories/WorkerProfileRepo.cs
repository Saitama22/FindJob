using System.Collections.Generic;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.Repositories
{
	public class WorkerProfileRepo : BaseRepo<WorkerProfile>, IWorkerProfileRepo
	{
		public WorkerProfileRepo(FjDbContext context) : base(context)
		{
		}

		public IEnumerable<WorkerProfile> WorkerProfils => Context.WorkerProfil;

		protected override DbSet<WorkerProfile> MainDbSet => Context.WorkerProfil;
	}
}
