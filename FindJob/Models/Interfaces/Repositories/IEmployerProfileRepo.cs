using System.Collections.Generic;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IEmployerProfileRepo : IGuidTable<EmployerProfile>
	{
		public IEnumerable<EmployerProfile> EmployerProfiles { get; }
	}
}
