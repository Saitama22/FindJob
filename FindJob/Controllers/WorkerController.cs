using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Enums;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Controllers
{
	[Authorize(Roles = nameof(Roles.Worker))]
	public class WorkerController : Controller
	{
		private readonly IResumeRepo _resumeRepo;
			
		public WorkerController(IResumeRepo resumeRepo)
		{
			_resumeRepo = resumeRepo;
		}
		public IActionResult Create(Guid resumeId)
		{
			return View(_resumeRepo.GetByGuid(resumeId));
		}

		[HttpPost]
		public async Task<IActionResult> Save(Resume resume)
		{
			await _resumeRepo.CreateOrUpdateAsync(resume);
			return RedirectToAction(nameof(Resumes));
		}

		public IActionResult Resumes()
		{
			return View(_resumeRepo.Resumes);
		}

		public IActionResult Delete(Guid resumeId)
		{
			_resumeRepo.DeleteAsync(resumeId);
			return RedirectToAction(nameof(Resumes));
		}
	}
}
