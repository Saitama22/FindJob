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

		public DbSet<FjResponses> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Resume>()
                .HasMany(c => c.Vacancies)
                .WithMany(s => s.Resumes)
                .UsingEntity<FjResponses>(
                   j => j
                    .HasOne(pt => pt.Vacancy)
                    .WithMany(t => t.Responses)
                    .HasForeignKey(pt => pt.VacancyGuid),
                j => j
                    .HasOne(pt => pt.Resume)
                    .WithMany(p => p.Responses)
                    .HasForeignKey(pt => pt.ResumeGuid),
                j =>
                {
                    j.HasKey(t => new { t.ResumeGuid, t.VacancyGuid });
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb2;Username=postgres;Password=qwerty");
		}

	}
}
