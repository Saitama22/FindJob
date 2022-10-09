using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Repositories
{
	public interface IWorkerProfileRepo : IGuidTable<WorkerProfile>
	{
		public IEnumerable<WorkerProfile> WorkerProfils { get; }
	}
}
