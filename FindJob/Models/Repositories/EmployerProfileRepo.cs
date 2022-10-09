using System.Collections.Generic;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.Repositories
{
	public class EmployerProfileRepo : BaseRepo<EmployerProfile>, IEmployerProfileRepo
	{
		public EmployerProfileRepo(FjDbContext context) : base(context)
		{
		}

		public IEnumerable<EmployerProfile> EmployerProfiles => Context.EmployerProfil;

		protected override DbSet<EmployerProfile> MainDbSet => Context.EmployerProfil;
	}
}
