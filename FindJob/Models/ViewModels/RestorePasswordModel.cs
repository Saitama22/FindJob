using System.ComponentModel.DataAnnotations;

namespace FindJob.Models.ViewModels
{
	public class RestorePasswordModel
	{
		public string Email { get; set; }

		[Required(ErrorMessage = "Не указан пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Не совпадют данные")]
		public string ConfirmPassword { get; set; }
	}
}
