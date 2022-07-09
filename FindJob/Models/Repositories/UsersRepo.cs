using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Repositories
{
	public class UsersRepo : IUsersRepo
	{
		public IEnumerable<UserFj> Users => Context.Users;

		private FjDbContext Context { get; set; }

		public bool Check(UserFj userFj)
		{
			if (Users.FirstOrDefault(r => r.Email == userFj.Email && r.PasswordHash == userFj.PasswordHash) != null)
			{
				return true;
			}
			return false;
		}

		public async Task<bool> TryAddAsync(UserFj userFj)
		{
			if (Users.FirstOrDefault(r => r.Email == userFj.Email) == null)
			{
				await Context.Users.AddAsync(userFj);
				await Context.SaveChangesAsync();
				return true;
			}
			return false;
		}
	}
}
