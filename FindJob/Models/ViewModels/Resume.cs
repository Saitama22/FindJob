﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using FindJob.Models.Interfaces.ViewModels;
using Microsoft.AspNetCore.Http;

namespace FindJob.Models.ViewModels
{
	public class Resume : IViewModelBase<Resume>, IIdModel
	{
		public Guid Id { get; set; }

		[NotMapped]
		[DisplayName("Имя")]
		public string Name { get; set; }

		[NotMapped]
		[DisplayName("Фамилия")]
		public string Surname { get; set; }

		public string UserName { get; set; }

		[DisplayName("Желаемая должность")]
		public string Post { get; set; }

		[DisplayName("Опыт работы")]
		public int? Expirience { get; set; }

		[DisplayName("Зарплата")]
		public double? Salary { get; set; }

		[DisplayName("О себе")]
		public string Info { get; set; }

		[NotMapped]
		[DisplayName("Загрузить фото")]
		public IFormFile FormFile { get; set; }

		public FjImage Image { get; set; }

		public bool IsMain { get; set; }

		public List<Vacancy> Vacancies { get; set; } = new();

		public List<FjResponses> Responses { get; set; } = new();

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
