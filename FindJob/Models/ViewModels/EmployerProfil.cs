using System.ComponentModel;
using FindJob.Models.Enums;

namespace FindJob.Models.ViewModels
{
	public class EmployerProfil
	{
		[DisplayName("Название организации")]
		public string Name { get; set; }

		[DisplayName("Логотип")]
		public byte[] Picture { get; set; }

		[DisplayName("Тип организации")]
		public EmployerType Type { get; set; }
	}
}
