using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
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

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SaveAsync(Resume resume)
		{
			await _resumeRepo.CreateOrUpdateAsync(resume);
			return RedirectToAction(nameof(Resumes));
		}

		public IActionResult Resumes()
		{
			return View(_resumeRepo.Resumes);
		}
	}
}
