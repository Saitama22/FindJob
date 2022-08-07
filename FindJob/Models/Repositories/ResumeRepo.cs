using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Repositories
{
	internal class ResumeRepo : IResumeRepo
	{		
		private FjDbContext Context { get ; set ; }

		public ResumeRepo(FjDbContext context)
		{
			Context = context;
		}

		public IEnumerable<Resume> Resumes => Context.Resumes;

		public async Task CreateOrUpdateAsync(Resume resume)
		{
			if (resume.Id == Guid.Empty)
			{
				resume.Id = Guid.NewGuid();
				await Context.Resumes.AddAsync(resume);
			}
			else
			{
				var dbResume = Context.Resumes.FirstOrDefault(r => r.Id == resume.Id);
				dbResume.Update(resume);
			}
			await Context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid guid)
		{
			var resume = GetByGuid(guid);
			await DeleteAsync(resume);
		}

		public async Task DeleteAsync(Resume resume)
		{
			Context.Resumes.Remove(resume);
			await Context.SaveChangesAsync();
		}

		public Resume GetByGuid(Guid guid)
		{
			return Resumes.FirstOrDefault(r => r.Id == guid);
		}

	}
}
