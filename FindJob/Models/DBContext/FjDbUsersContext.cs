using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.DBContext
{
	public class FjDbUsersContext : IdentityDbContext<UserFj>
	{
	//	public DbSet<RolesFj> Roles { get; set; }
		public FjDbUsersContext(DbContextOptions<FjDbUsersContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
