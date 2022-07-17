using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Enums;
using FindJob.Models.Interfaces.Handler.WorkerHandlers;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Controllers
{
	[Authorize(Roles = nameof(Roles.Worker))]
	public class WorkerController : Controller
	{
		private readonly IWorkerHandler _workerHandler;

		public WorkerController(IWorkerHandler workerHandler)
		{
			_workerHandler = workerHandler;
		}
		public IActionResult Create(Guid resumeId)
		{
			return View(_workerHandler.GetResumeById(resumeId));
		}

		[HttpPost]
		public async Task<IActionResult> Save(Resume resume)
		{
			await _workerHandler.AddToResumeRepo(resume, HttpContext.User.Identity.Name);
			return RedirectToAction(nameof(Resumes));
		}

		public IActionResult Resumes()
		{
			return View(_workerHandler.GetUserResumes(HttpContext.User.Identity.Name));
		}

		public async Task<IActionResult> DeleteAsync(Guid resumeId)
		{
			await _workerHandler.RemoveResume(resumeId);			
			return RedirectToAction(nameof(Resumes));
		}
	}
}
