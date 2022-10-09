using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FindJob.Models.ViewModels
{
	public class RestorePasswordModel
	{
		[Required(ErrorMessage = "Не указан старый пароль")]
		[DataType(DataType.Password)]
		[DisplayName("Старый пароль")]
		public string OldPassword { get; set; }

		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		[DisplayName("Новый пароль")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Не совпадют данные")]
		[DisplayName("Повторите новый пароль")]
		public string ConfirmPassword { get; set; }
	}
}
