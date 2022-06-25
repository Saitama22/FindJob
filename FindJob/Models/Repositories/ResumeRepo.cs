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
		private FjDbContext _context;

		public ResumeRepo(FjDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Resume> Resumes => _context.Resumes;

		public async Task CreateOrUpdateAsync(Resume resume)
		{
			if (resume.Id == Guid.Empty)
			{
				resume.Id = Guid.NewGuid();
				await _context.Resumes.AddAsync(resume);
			}
			else
			{
				var dbResume = _context.Resumes.FirstOrDefault(r => r.Id == resume.Id);
				dbResume.Update(resume);
			}
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid guid)
		{
			var resume = GetByGuid(guid);
			await DeleteAsync(resume);
		}

		public async Task DeleteAsync(Resume resume)
		{
			_context.Resumes.Remove(resume);
			await _context.SaveChangesAsync();
		}

		public Resume GetByGuid(Guid guid)
		{
			return Resumes.FirstOrDefault(r => r.Id == guid);
		}
	}
}
