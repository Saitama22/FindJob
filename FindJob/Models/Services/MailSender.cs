using System;
using System.IO;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.Services;
using FindJob.Models.ParamModels;
using FindJob.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using MimeKit;
namespace FindJob.Models.Services
{
	public class MailSender : IMailSender
	{
		private IConfigurationRoot _config;

		public MailSender()
		{
			InitConfig();
		}

		private void InitConfig()
		{
			var jsonPath = $@"{Directory.GetCurrentDirectory()}\MailConfig.json";
			if (!File.Exists(jsonPath))
				throw new Exception($"Не найден файл {jsonPath}");
			var builder = new ConfigurationBuilder().AddJsonFile(jsonPath);
			_config = builder.Build();
		}

		public async Task<Result> SendRestorePasswordAsync(string email, string newPassword)
		{
			return await SendEmailAsync(email, "Восстановление пароля", $"Ваш новй пароль: {newPassword}");
		}

		public async Task<Result> SendEmailAsync(string email, string subject, string message)
		{
			try
			{
				var emailMessage = new MimeMessage();
				emailMessage.From.Add(new MailboxAddress("FindJob", _config["Username"]));
				emailMessage.To.Add(new MailboxAddress("", email));
				emailMessage.Subject = subject;
				emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
				{
					Text = message,
				};

				using var client = new MailKit.Net.Smtp.SmtpClient();
				await client.ConnectAsync(_config["Host"], int.Parse(_config["Port"]), false);
				await client.AuthenticateAsync(_config["Username"], _config["Password"]);
				await client.SendAsync(emailMessage);
				await client.DisconnectAsync(true);
			}
			catch (Exception ex)
			{
				return Result.ErrorResult(ex.Message);
			}
			return Result.SuccessResult();
		}
	}
}
