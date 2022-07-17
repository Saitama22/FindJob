using FindJob.Models.DBContext;
using FindJob.Models.Handlers.AccountHandlers;
using FindJob.Models.Handlers.WorkerHandlers;
using FindJob.Models.Interfaces.Handler.AccountHandlers;
using FindJob.Models.Interfaces.Handler.WorkerHandlers;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FindJob
{
	public static class DI
	{
		public static IServiceCollection Init(this IServiceCollection services)
		{
			services.AddMvc();
			services.AddControllersWithViews();
			services
				.AddDbContexts()
				.AddAutorisation()
				.AddRepositories()
				.AddHandlers();

			return services;
		}

		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<IResumeRepo, ResumeRepo>();
			services.AddTransient<IUsersRepo, UsersRepo>();
			return services;
		}

		private static IServiceCollection AddAutorisation(this IServiceCollection services)
		{
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = new PathString("/Account/Login");
				});
			return services;
		}

		private static IServiceCollection AddHandlers(this IServiceCollection services)
		{
			services.AddScoped<IAccountLoginHandler, AccountLoginHandler>();
			services.AddScoped<IWorkerHandler, WorkerHandler>();
			return services;
		}

		private static IServiceCollection AddDbContexts(this IServiceCollection services)
		{
			services.AddDbContext<FjDbContext>();

			string IdentityConnection = "Server=(localdb)\\mssqllocaldb;Database=usersFjdb;Trusted_Connection=True;";
			services.AddDbContext<FjDbUsersContext>(options => options.UseSqlServer(IdentityConnection));
			services.AddIdentity<UserFj, IdentityRole>
				(opt =>
				{
					opt.User.RequireUniqueEmail = true;
					opt.Password.RequiredLength = 3;
					opt.Password.RequireDigit = false;
					opt.Password.RequireLowercase = false;
					opt.Password.RequireUppercase = false;
					opt.Password.RequireNonAlphanumeric = false;
				})
			.AddEntityFrameworkStores<FjDbUsersContext>();

			return services;
		}
			
	}
}
