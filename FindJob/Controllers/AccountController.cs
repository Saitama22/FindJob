using System;
using System.Threading.Tasks;
using FindJob.Models.Enums;
using FindJob.Models.Helper;
using FindJob.Models.Interfaces.Handler.AccountHandlers;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountLoginHandler _accountLoginHandler;

		public AccountController(IAccountLoginHandler accountLoginHandler)
		{
			_accountLoginHandler = accountLoginHandler;
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel registerModel)
		{
			if (!ModelState.IsValid)
				return View("Register");

			var errorsRegister = await _accountLoginHandler.TryRegister(registerModel);

			if (await _accountLoginHandler.GetRoleAsync(HttpContext) == Roles.Worker)
				return RedirectToAction(nameof(WorkerController.Create), nameof(WorkerController).GetNameOfController());

			if (await _accountLoginHandler.GetRoleAsync(HttpContext) == Roles.Employer)
				return RedirectToAction(nameof(EmployerController.Create), nameof(EmployerController).GetNameOfController());

			foreach (var error in errorsRegister)
			{
				ModelState.AddModelError("", error);
			}
			return View("Register");
		}

		[HttpPost]
		public async Task<IActionResult> Enter(LoginModel login)
		{
			if (!ModelState.IsValid)
				return View("Login");

			
			if (await _accountLoginHandler.TryLogin(login))
			{
				if (await _accountLoginHandler.GetRoleAsync(HttpContext) == Roles.Worker)
					return RedirectToAction(nameof(WorkerController.Create), nameof(WorkerController).GetNameOfController());

				if (await _accountLoginHandler.GetRoleAsync(HttpContext) == Roles.Employer)
					return RedirectToAction(nameof(EmployerController.Create), nameof(EmployerController).GetNameOfController());
			}

			ModelState.AddModelError("", "Неправильный логин и (или) пароль");
			return View("Login");

		}
		
		public async Task<IActionResult> Logout()
		{
			// удаляем аутентификационные куки
			await _accountLoginHandler.LogOutAsync();
			return RedirectToAction(nameof(MainController.StartPage), nameof(MainController).GetNameOfController());
		}
	}
}
