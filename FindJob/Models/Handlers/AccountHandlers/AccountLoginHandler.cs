using System;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Enums;
using FindJob.Models.Interfaces.Handler.AccountHandlers;
using FindJob.Models.Interfaces.Services;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FindJob.Models.Handlers.AccountHandlers
{
	public class AccountLoginHandler : IAccountLoginHandler
	{
		private readonly SignInManager<UserFj> _signInManager;
		private readonly UserManager<UserFj> _userManager;
		private string _curUserName;
		private readonly IMailSender _mailSender;
		public AccountLoginHandler(SignInManager<UserFj> signInManager,
			UserManager<UserFj> userManager, IMailSender mailSender)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_mailSender = mailSender;
		}

		public async Task<Result> TryLogin(LoginModel loginModel)
		{
			SignInResult resultLogin;
			if (loginModel.UserName.Contains("@"))
			{
				var user = await _userManager.FindByEmailAsync(loginModel.UserName);
				if (user == null)
					return Result.OneError("Не найден пользователь по данному email");
				resultLogin = await _signInManager.PasswordSignInAsync(user.UserName, loginModel.Password, loginModel.RememberMe, false);
				loginModel.UserName = user.UserName;
			}
			else
				resultLogin = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);

			if (resultLogin.Succeeded)
			{
				_curUserName = loginModel.UserName;
				return Result.SuccessResult();
			}
			return Result.OneError("Неудачная попытка входа");
		}

		public async Task<Result> TryRegister(RegisterModel registerModel)
		{
			if (registerModel.UserName != null && registerModel.UserName.Contains("@"))
				return Result.OneError("UserName не должно содержать @");

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
				else if (registerModel.Role == Roles.Employer)
				{
					await _userManager.AddToRoleAsync(user, "Employer");
				}
				await _signInManager.SignInAsync(user, false);
				_curUserName = user.UserName;
				return Result.SuccessResult();
			}
			else
				return Result.ManyError(resultCreate.Errors.Select(e => e.Description));
		}

		public async Task LogOutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<Roles> GetRoleAsync()
		{
			var user = await _userManager.FindByNameAsync(_curUserName);
			var roles = await _userManager.GetRolesAsync(user);
			if (roles.Contains(Roles.Employer.ToString()))
				return Roles.Employer;
			if (roles.Contains(Roles.Worker.ToString()))
				return Roles.Worker;
			throw new NotSupportedException("Нет роли!");			
		}

		public async Task<Result> RememberAsync(string email)
		{
			if (await _userManager.FindByEmailAsync(email) == null)
				return Result.OneError("Не найден данный email");
			return await _mailSender.SendRestorePasswordAsync(email); 
			
		}

		public async Task<Result> RestoreAsync(RestorePasswordModel resetPasswordModel)
		{
			var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
			if (user == null)
				return Result.OneError("Не найден пользователь по данному email");
			var token = await _userManager.GeneratePasswordResetTokenAsync(user);
			var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordModel.Password);
			if (result.Succeeded)
			{
				_curUserName = user.UserName;
				return Result.SuccessResult();
			}
			return Result.OneError("Неудачная попытка входа");
		}
	}
}
