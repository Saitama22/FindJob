using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace FindJob.Models.Interfaces.Handler.AccountHandlers
{
	public interface IAccountLoginHandler
	{
		HttpContext HttpContext { set; }

		Task<bool> TryLogin(LoginModel loginModel);

		Task<IEnumerable<string>> TryRegister(RegisterModel registerModel);

		Task LogOutAsync();
	}
}
