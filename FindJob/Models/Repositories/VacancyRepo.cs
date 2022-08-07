using System;
using System.Collections.Generic;
using System.Linq;
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

		public IEnumerable<Vacancy> Vacancies => Context.Vacancies;

		protected override DbSet<Vacancy> MainDbSet => Context.Vacancies;

		public override Vacancy GetByGuid(Guid guid)
		{
			return Vacancies.FirstOrDefault(r => r.Id == guid);
		}
	}
}
