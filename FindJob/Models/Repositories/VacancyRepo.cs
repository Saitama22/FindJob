using System.Collections.Generic;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.Repositories
{
	public class VacancyRepo : BaseRepo<Vacancy>, IVacancyRepo
	{
		public VacancyRepo(FjDbContext context) : base(context)
		{
		}

		public IEnumerable<Vacancy> Vacancies => Context.Vacancies.Include(r => r.EmployerProfil);

		protected override DbSet<Vacancy> MainDbSet => Context.Vacancies;
	}
}
