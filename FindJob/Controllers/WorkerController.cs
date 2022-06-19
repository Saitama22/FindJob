using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Controllers
{
	public class WorkerController : Controller
	{
		private readonly IResumeRepo _resumeRepo;

		public WorkerController(IResumeRepo resumeRepo)
		{
			_resumeRepo = resumeRepo;
		}

		public IActionResult Vacancies()
		{
			return View(_resumeRepo.Resumes);
		}

		public IActionResult Create()
		{
			return View();
		}
	}
}
