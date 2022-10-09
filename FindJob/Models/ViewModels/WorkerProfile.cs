using System;
using System.Collections.Generic;
using System.ComponentModel;
using FindJob.Models.Interfaces.ViewModels;

namespace FindJob.Models.ViewModels
{
	public class WorkerProfile : IIdModel, IViewModelBase<WorkerProfile>
	{
		public Guid Id { get; set; }

		public string UserName { get; set; }

		[DisplayName("Имя")]
		public string Name { get; set; }

		[DisplayName("Фамилия")]
		public string Surname { get; set; }

		[DisplayName("Телефон")]
		public string Phone { get; set; }

		public string Email { get; set; }

		[DisplayName("Райно поиска работы")]
		public string Region { get; set; }

		[DisplayName("Фото")]
		public byte[] DefaultPicture { get; set; }

		public List<Resume> Resumes { get; set; }

		public void Update(WorkerProfile newModel)
		{
			UserName = newModel.UserName;
			Name = newModel.Name;
			Surname = newModel.Surname;
			Phone = newModel.Phone;
			Email = newModel.Email;
			Region = newModel.Region;
		}
	}
}
