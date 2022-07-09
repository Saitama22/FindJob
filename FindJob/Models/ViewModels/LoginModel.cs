using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJob.Models.ViewModels
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Не указан Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberMe { get; set; } = false;
	}
}
