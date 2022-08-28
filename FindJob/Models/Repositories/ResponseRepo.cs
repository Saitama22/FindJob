using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.Repositories
{
	public class ResponseRepo : IResponseRepo
	{
		public ResponseRepo(FjDbContext context)
		{
			Context = context;
		}

		private FjDbContext Context { get; set; }
		private DbSet<FjResponses> MainDbSet => Context.Responses;
		public IEnumerable<FjResponses> Responses => Context.Responses;

		public async Task AddResponseAsync(Resume resume, Vacancy vacancy)
		{			
			FjResponses fjResponses = new()
			{
				Resume = resume,
				ResumeGuid = resume.Id,
				Vacancy = vacancy,
				VacancyGuid = vacancy.Id,
				FjResponsesTypes = Enums.FjResponsesTypes.None,
				IsRead = false,
			};

			try
			{
				await MainDbSet.AddAsync(fjResponses);
				await Context.SaveChangesAsync();
			}
			catch (Exception)
			{
				return;
			}
		}

		public IEnumerable<FjResponses> GetResumeResponses(string userName)
		{
			return MainDbSet.Include(r => r.Resume).Include(r => r.Vacancy).Where(r => r.Resume.UserName == userName);
		}

		public IEnumerable<FjResponses> GetVacancyResponses(string userName)
		{
			return MainDbSet.Include(r => r.Resume).Include(r => r.Vacancy).Where(r => r.Vacancy.UserName == userName);
		}
	}
}
