using System;
using FindJob.Models.Enums;

namespace FindJob.Models.Helper
{
	public static class EnumHelper
	{
		public static string ToRussianString(this EmployerType employerType) 
		{
			return employerType switch
			{
				EmployerType.Company => "Частная компания",
				EmployerType.IP => "Индивидуальный предприниматель",
				_ => employerType.ToString()
			};
		}

		public static string ToRussianString(this FjResponsesTypes responsesTypes) 
		{
			return responsesTypes switch
			{
				FjResponsesTypes.None => "Не просмотрено",
				FjResponsesTypes.Сonsideration => "На рассмотрении",
				FjResponsesTypes.Rejection => "Отказ",
				FjResponsesTypes.Invitation => "Согласие",
				_ => responsesTypes.ToString()
			};
		}

		public static string ToRussianString(this Roles roles) 
		{
			return roles switch
			{
				Roles.Worker => "Работник",
				Roles.Employer => "Работотдатель",
				_ => roles.ToString()
			};
		}
	}
}
