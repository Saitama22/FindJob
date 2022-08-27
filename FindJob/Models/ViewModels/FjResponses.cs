using System;
using FindJob.Models.Enums;

namespace FindJob.Models.ViewModels
{
	public class FjResponses
	{
		public Guid VacancyGuid { get; set; }
		public Vacancy Vacancy { get; set; }
		public Guid ResumeGuid { get; set; }
		public Resume Resume { get; set; }
		public bool IsRead { get; set; }
		public FjResponsesTypes FjResponsesTypes { get; set; }
	}
}
