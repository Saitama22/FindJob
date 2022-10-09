using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FindJob.Models.ViewModels
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Не указан Email")]
		[DisplayName("Логин")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		[DisplayName("Пароль")]
		public string Password { get; set; }

		[DisplayName("Сохранить вход")]
		public bool RememberMe { get; set; } = false;
	}
}
