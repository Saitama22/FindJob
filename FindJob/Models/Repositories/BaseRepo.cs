using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.DBContext;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.Interfaces.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FindJob.Models.Repositories
{
	public abstract class BaseRepo<T> : IGuidTable<T> where T: class, IViewModelBase<T>, IIdModel
	{
		protected FjDbContext Context { get; private set; }

		public BaseRepo(FjDbContext context)
		{
			Context = context;
		}

		protected abstract DbSet<T> MainDbSet { get; }

		public async Task CreateOrUpdateAsync(T model)
		{
			if (model.Id == Guid.Empty)
			{
				model.Id = Guid.NewGuid();
				await MainDbSet.AddAsync(model);
			}
			else
			{
				var dbModel = GetByGuid(model.Id);
				dbModel.Update(model);
				MainDbSet.Update(dbModel);
			}
			await Context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Guid guid)
		{
			T model = GetByGuid(guid);
			await DeleteAsync(model);
		}

		public async Task DeleteAsync(T model)
		{
			MainDbSet.Remove(model);
			await Context.SaveChangesAsync();
		}

		public virtual T GetByGuid(Guid guid)
		{
			return MainDbSet.FirstOrDefault(r => r.Id == guid);
		}
	}
}
