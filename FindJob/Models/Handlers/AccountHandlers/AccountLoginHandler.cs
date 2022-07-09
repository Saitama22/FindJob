using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
			var resultLogin = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);

			if (resultLogin.Succeeded)
			{
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
				await _signInManager.SignInAsync(user, false);
				return null;
			}
			else
				return resultCreate.Errors.Select(e => e.Description);
		}
	}
}
