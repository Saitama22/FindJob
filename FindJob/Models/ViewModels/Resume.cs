using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindJob.Models.ViewModels
{
	public class Resume
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public int? Expirience { get; set; }

		public double Salary { get; set; }

		public string Info { get; set; }
		
	}
}
