using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindJob.Models.Interfaces.Repositories;
using FindJob.Models.ViewModels;
using FindJobTests.TestModels.TestSevices;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace FindJobTests.TestModels.TestServices.Repo
{
	//[Ignore("Не тест")]
	class Deleter : BaseInitTest
	{
		private IResumeRepo _resumeRepo;
		private IWorkerProfileRepo _workerProfileRepo;
		private IVacancyRepo _vacancyRepo;
		private IEmployerProfileRepo _employerProfileRepo;
		private IImageRepo _imageRepo;
		private IResponseRepo _responseRepo;
		private UserManager<UserFj> _userManager;

		[SetUp]
		public void InitRepos()
		{
			_workerProfileRepo = _serviceProvider.GetService<IWorkerProfileRepo>();
			_resumeRepo = _serviceProvider.GetService<IResumeRepo>();
			_employerProfileRepo = _serviceProvider.GetService<IEmployerProfileRepo>();
			_vacancyRepo = _serviceProvider.GetService<IVacancyRepo>();
			_imageRepo = _serviceProvider.GetService<IImageRepo>();
			_responseRepo = _serviceProvider.GetService<IResponseRepo>();
			_userManager = _serviceProvider.GetService<UserManager<UserFj>>();
		}

		[Test]
		public async Task DeleteWorkerProfilesAsync()
		{
			var workerProfiles = _workerProfileRepo.WorkerProfils.ToList();
			foreach (var workerProfile in workerProfiles)
			{
				await _workerProfileRepo.DeleteAsync(workerProfile.Id);
			}
			CheckCount(_workerProfileRepo.WorkerProfils.ToList());
		}

		private static void CheckCount<T>(List<T> records)
		{
			if (records.Count != 0)
				Assert.Warn("Больше 0 записей после очистки");
		}

		[Test]
		public async Task DeleteResumesAsync()
		{
			var resumes = _resumeRepo.Resumes.ToList();
			foreach (var resume in resumes)
			{
				await _resumeRepo.DeleteAsync(resume.Id);
			}
			CheckCount(_resumeRepo.Resumes.ToList());
		}

		[Test]
		public async Task DeleteEmployerProfilesAsync()
		{
			var employerProfiles = _employerProfileRepo.EmployerProfiles.ToList();
			foreach (var employerProfile in employerProfiles)
			{
				await _employerProfileRepo.DeleteAsync(employerProfile.Id);
			}
			CheckCount(_employerProfileRepo.EmployerProfiles.ToList());
		}

		[Test]
		public async Task DeleteVacancyAsync()
		{
			var vacancies = _vacancyRepo.Vacancies.ToList();
			foreach (var vacancy in vacancies)
			{
				await _vacancyRepo.DeleteAsync(vacancy.Id);
			}
			CheckCount(_vacancyRepo.Vacancies.ToList());
		}

		[Test]
		public async Task DeleteResponsesAsync()
		{
			var responses = _responseRepo.Responses.ToList();
			foreach (var response in responses)
			{
				await _responseRepo.DeleteAsync(response);
			}
			CheckCount(_responseRepo.Responses.ToList());
		}

		[Test]
		public async Task DeleteImagesAsync()
		{
			var images = _imageRepo.Images.ToList();
			foreach (var image in images)
			{
				await _imageRepo.DeleteAsync(image.Id);
			}
			CheckCount(_imageRepo.Images.ToList());
		}

		[Test]
		[Ignore("Не тест")]
		public async Task DeleteUsers()
		{
			var users = _userManager.Users.ToList();
			foreach (var user in users)
			{
				await _userManager.DeleteAsync(user);
			}
			CheckCount(_userManager.Users.ToList());
		}
	}
}
