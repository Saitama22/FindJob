using System;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Enums;
using FindJob.Models.Interfaces.Handler;
using FindJob.Models.Interfaces.Services;
using FindJob.Models.ParamModels;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace FindJob.Models.Handlers
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
			try
			{
				SignInResult resultLogin;
				var user = await GetUserFjAsync(loginModel.UserName);
				resultLogin = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, false);

				if (resultLogin.Succeeded)
				{
					_curUserName = loginModel.UserName;
					return Result.SuccessResult();
				}
				return Result.ErrorResult("Неудачная попытка входа");
			}
			catch (Exception ex)
			{
				return Result.ErrorResult(ex.Message);
			}
		}

		public async Task<Result> TryRegister(RegisterModel registerModel)
		{
			try
			{
				if (registerModel.UserName != null && registerModel.UserName.Contains("@"))
					return Result.ErrorResult("UserName не должно содержать @");

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
					return Result.ErrorResult(resultCreate.Errors.Select(e => e.Description));
			}
			catch (Exception ex)
			{
				return Result.ErrorResult(ex.Message);
			}
		}

		public async Task LogOutAsync()
		{
			await _signInManager.SignOutAsync();
		}

		public async Task<Roles> GetRoleAsync(string curUserName = null)
		{
			curUserName ??= _curUserName; 
			var user = await GetUserFjAsync(curUserName);
			var roles = await _userManager.GetRolesAsync(user);
			if (roles.Contains(Roles.Employer.ToString()))
				return Roles.Employer;
			if (roles.Contains(Roles.Worker.ToString()))
				return Roles.Worker;
			throw new NotSupportedException("Нет роли!");			
		}

		public async Task<Result> RememberAsync(string email)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user == null)
				return Result.ErrorResult("Не найден пользователь по данному email");
			var token = await _userManager.GeneratePasswordResetTokenAsync(user);

			var newPasword = Guid.NewGuid().ToString().Substring(0, 6);
			var result = await _userManager.ResetPasswordAsync(user, token, newPasword);

			if (!result.Succeeded)
				Result.ErrorResult(result.Errors.Select(r => r.Description));

			return await _mailSender.SendRestorePasswordAsync(email, newPasword); 			
		}

		public async Task<Result> RestoreAsync(RestorePasswordModel resetPasswordModel, string userName)
		{
			var user = await GetUserFjAsync(userName);
			if (user == null)
				return Result.ErrorResult("Не найден пользователь по данному email");
			if (!await _userManager.CheckPasswordAsync(user, resetPasswordModel.OldPassword))
				return Result.ErrorResult("Неверный пароль");
			var token = await _userManager.GeneratePasswordResetTokenAsync(user);
			var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordModel.Password);
			if (result.Succeeded)
			{
				_curUserName = user.UserName;
				return Result.SuccessResult();
			}
			return Result.ErrorResult("Неудачная попытка входа");
		}

		public async Task<UserFj> GetUserFjAsync(string userNameOrEmail)
		{
			UserFj user;
			if (userNameOrEmail.Contains("@"))
				user = await _userManager.FindByEmailAsync(userNameOrEmail);
			else
				user = await _userManager.FindByNameAsync(userNameOrEmail);

			if (user == null)
				throw new Exception("Не найден пользователь по данному email");
			return user;
		}
	}
}
