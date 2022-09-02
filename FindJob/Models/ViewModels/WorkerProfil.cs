using System.ComponentModel;

namespace FindJob.Models.ViewModels
{
	public class WorkerProfil
	{
		[DisplayName("Имя")]
		public string Name { get; set; }

		[DisplayName("Фамилия")]
		public string Surname { get; set; }

		public string Email{ get; set; }

		[DisplayName("Фото")]
		public byte[] Picture { get; set; }
	}
}
