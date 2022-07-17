using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Enums;
using FindJob.Models.Interfaces.Handler.AccountHandlers;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FindJob.Models.Handlers.AccountHandlers
{
	public class AccountLoginHandler : IAccountLoginHandler
	{
		private readonly SignInManager<UserFj> _signInManager;
		private readonly UserManager<UserFj> _userManager;
		private HttpContext _httpContext;
		private string _curUserName;

		public HttpContext HttpContext
		{
			get => _httpContext;
			set
			{
				if (_httpContext != null)
					throw new Exception("Уже инициализировано");
				_httpContext = value;
			}
		}

		public AccountLoginHandler(SignInManager<UserFj> signInManager,
			UserManager<UserFj> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public async Task<bool> TryLogin(LoginModel loginModel)
		{
			var resultLogin = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);

			if (resultLogin.Succeeded)
			{
				_curUserName = loginModel.UserName;
				return true;				
			}

			return false;
		}

		public async Task<IEnumerable<string>> TryRegister(RegisterModel registerModel)
		{
			UserFj user = new() 
			{ 
				Email = registerModel.Email, 
				UserName = registerModel.UserName ?? registerModel.Email,
			};
			var resultCreate = await _userManager.CreateAsync(user, registerModel.Password);
			if (resultCreate.Succeeded)
			{
				if (registerModel.Role == Roles.Worker)
				{
					await _userManager.AddToRoleAsync(user, "Worker");
				}
				else if(registerModel.Role == Roles.Employer)
				{
					await _userManager.AddToRoleAsync(user, "Employer");
				}
				await _signInManager.SignInAsync(user, false);
				_curUserName = user.UserName;
				return null;
			}
			else
				return resultCreate.Errors.Select(e => e.Description);
		}

		public async Task LogOutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<Roles> GetRoleAsync(HttpContext httpContext)
		{
			var user = _userManager.Users.FirstOrDefault(r => r.UserName == _curUserName);
			var roles = await _userManager.GetRolesAsync(user);
			if (roles.Contains(Roles.Employer.ToString()))
				return Roles.Employer;
			if (roles.Contains(Roles.Worker.ToString()))
				return Roles.Worker;
			throw new NotSupportedException("Нет роли! Штаааааа?!?!?");			
		}
	}
}
