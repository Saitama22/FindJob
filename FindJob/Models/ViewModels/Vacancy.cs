using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.ViewModels;

namespace FindJob.Models.ViewModels
{
	public class Vacancy : IViewModelBase<Vacancy>, IIdModel
	{
		public Guid Id { get; set; }

		[DisplayName("Должность")]
		public string Post { get; set; }

		[DisplayName("Опыт работы")]
		public int? Expirience { get; set; }

		[DisplayName("Зарплата")]
		public double? Salary { get; set; }

		[DisplayName("О вакансии")]
		public string Info { get; set; }

		public bool IsMain { get; set; }

		public EmployerProfile EmployerProfil { get; set; }

		public List<Resume> Resumes { get; set; } = new();

		public List<FjResponses> Responses { get; set; } = new();

		public void Update(Vacancy newModel)
		{
			throw new NotImplementedException();
		}
	}
}
