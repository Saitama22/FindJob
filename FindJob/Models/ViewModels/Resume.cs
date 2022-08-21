using System;
using System.ComponentModel.DataAnnotations.Schema;
using FindJob.Models.Interfaces.ViewModels;
using Microsoft.AspNetCore.Http;

namespace FindJob.Models.ViewModels
{
	public class Resume : IViewModelBase<Resume>, IIdModel
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string UserName { get; set; }

		public string Post { get; set; }

		public string Surname { get; set; }

		public int? Expirience { get; set; }

		public double? Salary { get; set; }

		public string Info { get; set; }

		[NotMapped]
		public IFormFile FormFile { get; set; }

		public FjImage Image { get; set; }

//		public Guid ImageId { get; set; }

		public void Update(Resume newModel) 
		{
			Name = newModel.Name;
			Post = newModel.Post;
			Surname = newModel.Surname;
			Expirience = newModel.Expirience;
			Salary = newModel.Salary;
			Info = newModel.Info;
			Image = newModel.Image;
		}
	}
}
