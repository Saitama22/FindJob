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
			var resume = _workerHandler.GetResumeById(resumeId);
			if (resume?.Image != null)
			{
				var base64 = Convert.ToBase64String(resume.Image.Image);
				ViewBag.imgSrc = string.Format("data:image/jpg;base64,{0}", base64);
			}
			return View(resume);
		}

		[HttpPost]
		public async Task<IActionResult> Save(Resume resume)
		{			
			await _workerHandler.AddToResumeRepo(resume, HttpContext.User.Identity.Name);
			return RedirectToAction(nameof(Resumes));
		}

		public IActionResult Resumes()
		{
			return View(GetUserResumes());
		}

		public async Task<IActionResult> DeleteAsync(Guid resumeId)
		{
			await _workerHandler.RemoveResume(resumeId);			
			return RedirectToAction(nameof(Resumes));
		}

		public IActionResult Vacancies()
		{
			return View(_workerHandler.GetVacancies());
		}

		public async Task<IActionResult> MakeMainAsync(Guid resumeId)
		{
			await _workerHandler.MakeMainResumeAsync(resumeId, HttpContext.User.Identity.Name);
			return RedirectToAction(nameof(Resumes));
		}

		public async Task<IActionResult> ResponseVacancy(Guid vacancyId)
		{
			await _workerHandler.AddResponseVacancyAsync(vacancyId, HttpContext.User.Identity.Name);
			return RedirectToAction(nameof(Vacancies));
		}

		private IEnumerable<Resume> GetUserResumes()
		{
			return _workerHandler.GetUserResumes(HttpContext.User.Identity.Name);
		}
	}
}
