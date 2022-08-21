using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.DBContext
{
	public class FjDbContext : DbContext
	{
		public DbSet<Resume> Resumes { get; set; }

		public DbSet<Vacancy> Vacancies { get; set; }

		public DbSet<FjImage> Images { get; set; }

		//public FjDbContext()
		//{
		//	Database.EnsureCreated();
		//}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb2;Username=postgres;Password=qwerty");
		}

	}
}
