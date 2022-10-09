using System;
using System.Threading.Tasks;
using FindJob.Models.Enums;
using FindJob.Models.Helper;
using FindJob.Models.Interfaces.Handler;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Controllers
{
	[Authorize(Roles = nameof(Roles.Employer))]
	public class EmployerController : Controller
	{
		private readonly IEmployerHandler _employerHandler;

		public EmployerController(IEmployerHandler employerHandler)
		{
			_employerHandler = employerHandler;
		}
		public IActionResult Create(Guid vacancyId)
		{
			return View(_employerHandler.GetVacancyById(vacancyId));
		}

		[HttpPost]
		public async Task<IActionResult> Save(Vacancy vacancy)
		{
			await _employerHandler.AddToVacancyRepo(vacancy, HttpContext.User.Identity.Name);
			return RedirectToAction(nameof(Vacancies));
		}

		public IActionResult Vacancies()
		{
			return View(_employerHandler.GetUserVacancies(HttpContext.User.Identity.Name));
		}

		public async Task<IActionResult> DeleteAsync(Guid vacancyId)
		{
			await _employerHandler.RemoveVacancy(vacancyId);
			return RedirectToAction(nameof(Vacancies));
		}

		public IActionResult Resumes()
		{
			return View(_employerHandler.GetResumes());
		}

		public IActionResult Account()
		{
			return View();
		}

		public IActionResult Resume(Guid resumeId)
		{
			var resume = _employerHandler.GetResume(resumeId);
			ViewBag.imgSrc = ControllerHelper.GetImageString(resume);
			return View(resume);
		}

		public IActionResult Responses()
		{
			return View(_employerHandler.GetResponses(HttpContext.User.Identity.Name));
		}
	}
}
