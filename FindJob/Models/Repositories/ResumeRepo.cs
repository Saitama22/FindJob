using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.Repositories
{
	internal class ResumeRepo : BaseRepo<Resume>, IResumeRepo
	{
		public ResumeRepo(FjDbContext context) : base(context)
		{
		}

		public IEnumerable<Resume> Resumes => Context.Resumes.Include(r => r.WorkerProfil);

		protected override DbSet<Resume> MainDbSet => Context.Resumes;

		public override Resume GetByGuid(Guid guid)
		{
			return MainDbSet.Include(r => r.Image).FirstOrDefault(r => r.Id == guid);
		}
	}
}
