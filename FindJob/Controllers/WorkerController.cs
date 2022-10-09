using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FindJob.Models.Enums;
using FindJob.Models.Helper;
using FindJob.Models.Interfaces.Handler;
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
			ViewBag.imgSrc = ControllerHelper.GetImageString(resume);
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

		public IActionResult Responses()
		{
			return View(_workerHandler.GetResponses(HttpContext.User.Identity.Name));
		}

		public IActionResult Vacancy(Guid vacancyId)
		{
			return View(_workerHandler.GetVacancy(vacancyId));
		}

		private IEnumerable<Resume> GetUserResumes()
		{
			return _workerHandler.GetUserResumes(HttpContext.User.Identity.Name);
		}

		public IActionResult Account()
		{
			return View(_workerHandler.GetProfile(HttpContext.User.Identity.Name));
		}

		public IActionResult RedactProfile(Guid id)
		{
			return View(_workerHandler.GetWorkerProfile(id));
		}

		public async Task<IActionResult> SaveProfile(WorkerProfile workerProfile)
		{
			await _workerHandler.SavePorfileAsync(workerProfile);
			return RedirectToAction(nameof(Account));
		}
	}
}
