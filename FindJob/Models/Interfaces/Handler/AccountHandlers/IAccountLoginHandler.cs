﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FindJob.Models.Enums;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Models.Interfaces.Handler.AccountHandlers
{
	public interface IAccountLoginHandler
	{
		Task LogOutAsync();
		Task<Result> TryRegister(RegisterModel registerModel);
		Task<Result> TryLogin(LoginModel loginModel);
		Task<Roles> GetRoleAsync();
	//	Result RememberAsync(string email);
		Task<Result> RememberAsync(string email);
		Task<Result> RestoreAsync(RestorePasswordModel resetPasswordModel);
	}
}
