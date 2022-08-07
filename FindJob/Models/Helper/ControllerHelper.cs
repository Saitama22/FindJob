using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Models.Helper
{
	public static class ControllerHelper
	{
		public static string GetName(string name)
		{
			return name.Replace("Controller", "");
		}

		public static string GetName<T>()
		{
			return GetName(nameof(T));
		}

		public static string GetNameOfController(this string name)
		{
			return name.Replace(nameof(Controller), "");
		}
	}
}
