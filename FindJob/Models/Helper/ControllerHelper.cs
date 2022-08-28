using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;
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

		public static string GetImageString(byte[] bytes)
		{
			var base64 = Convert.ToBase64String(bytes);
			return string.Format("data:image/jpg;base64,{0}", base64);
		}

		public static string GetImageString(Resume resume)
		{
			if (resume?.Image != null)
			{
				var base64 = Convert.ToBase64String(resume.Image.Image);
				return string.Format("data:image/jpg;base64,{0}", base64);
			}
			return "";
		}
	}
}
