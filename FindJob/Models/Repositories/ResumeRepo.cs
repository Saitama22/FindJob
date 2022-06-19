using System.Collections.Generic;
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

		public void Add(Resume resume)
		{
			throw new System.NotImplementedException("Может быть не безопасно"); //todo 
			_context.Resumes.Add(resume);
			_context.SaveChanges();
		}

		public void Delete(Resume resume)
		{
			throw new System.NotImplementedException();
		}
	}
}
