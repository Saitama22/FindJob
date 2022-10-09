using System;
using System.Collections.Generic;
using System.ComponentModel;
using FindJob.Models.Enums;
using FindJob.Models.Interfaces.ViewModels;

namespace FindJob.Models.ViewModels
{
	public class EmployerProfile : IIdModel, IViewModelBase<EmployerProfile>
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		[DisplayName("Название организации")]
		public string Name { get; set; }

		[DisplayName("Логотип")]
		public byte[] Picture { get; set; }

		[DisplayName("Тип организации")]
		public EmployerType Type { get; set; }

		[DisplayName("Название организации")]
		public string Phone { get; set; }

		public string Email { get; set; }

		public List<Vacancy> Vacancies { get; set; }

		public void Update(EmployerProfile newModel)
		{
			throw new NotImplementedException();
		}
	}
}
