using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.ViewModels;

namespace FindJob.Models.ViewModels
{
	public class Vacancy : IViewModelBase<Vacancy>, IIdModel
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		public string Post { get; set; }

		public int? Expirience { get; set; }

		public double? Salary { get; set; }

		public string Info { get; set; }

		public void Update(Vacancy newModel)
		{
			throw new NotImplementedException();
		}
	}
}
