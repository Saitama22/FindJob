using System.Collections.Generic;
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

			await MainDbSet.AddAsync(fjResponses);
			await Context.SaveChangesAsync();
		}
	}
}
