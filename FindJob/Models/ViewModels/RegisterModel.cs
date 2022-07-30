using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Enums;

namespace FindJob.Models.ViewModels
{
	public class RegisterModel
	{
		[Required(ErrorMessage = "Не указан Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		public string UserName { get; set; }

		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		public string  Password { get; set; } 

		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Не совпадют данные")]
		public string ConfirmPassword { get; set; } 

		public Roles Role { get; set; } 
	}
}
