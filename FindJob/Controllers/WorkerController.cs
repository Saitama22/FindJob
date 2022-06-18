using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Controllers
{
	public class WorkerController : Controller
	{
		public IActionResult Vacancies()
		{
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
	}
}
