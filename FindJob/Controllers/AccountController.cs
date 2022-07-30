using System;
using System.Collections.Generic;
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

			var result = await _accountLoginHandler.TryRegister(registerModel);
			if (result.Succeeded)
				return await GetViewByRoleAsync();

			AddErrors(result.Errors);
			return View("Register");
		}

		[HttpPost]
		public async Task<IActionResult> Enter(LoginModel login)
		{
			if (!ModelState.IsValid)
				return View("Login");

			var result = await _accountLoginHandler.TryLogin(login);
			if (result.Succeeded)
				return await GetViewByRoleAsync();

			AddErrors(result.Errors);
			return View("Login");

		}

		private void AddErrors(IEnumerable<string> errors)
		{
			foreach (var error in errors)
			{
				ModelState.AddModelError("", error);
			}
		}

		public async Task<IActionResult> Logout()
		{
			// удаляем аутентификационные куки
			await _accountLoginHandler.LogOutAsync();
			return RedirectToAction(nameof(MainController.StartPage), nameof(MainController).GetNameOfController());
		}

		[HttpGet]
		public IActionResult Remember()
		{			
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Remember(OneEmail oneEmail)
		{
			var result = await _accountLoginHandler.RememberAsync(oneEmail.Email);
			if (result.Succeeded)
				return View(nameof(Login));			
			AddErrors(result.Errors);
			return View();
		}

		public async Task<RedirectToActionResult> GetViewByRoleAsync()
		{
			var role = await _accountLoginHandler.GetRoleAsync();

			if (role == Roles.Worker)
				return RedirectToAction(nameof(WorkerController.Create), nameof(WorkerController).GetNameOfController());

			if (role == Roles.Employer)
				return RedirectToAction(nameof(EmployerController.Create), nameof(EmployerController).GetNameOfController());

			throw new NotSupportedException($"Не реализовано для роли {role}");
		}
	}
}
