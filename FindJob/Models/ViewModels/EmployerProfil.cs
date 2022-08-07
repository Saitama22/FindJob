using FindJob.Models.Enums;

namespace FindJob.Models.ViewModels
{
	public class EmployerProfil
	{
		public string Name { get; set; }

		public byte[] Picture { get; set; }

		public EmployerType Type { get; set; }
	}
}
