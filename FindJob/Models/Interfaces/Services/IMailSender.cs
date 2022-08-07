using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.ParamModels;
using FindJob.Models.ViewModels;

namespace FindJob.Models.Interfaces.Services
{
	public interface IMailSender
	{
		Task<Result> SendEmailAsync(string email, string subject, string message);
		Task<Result> SendRestorePasswordAsync(string email, string newPasword);
	}
}
