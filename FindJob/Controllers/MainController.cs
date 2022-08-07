using FindJob.Models.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FindJob.Controllers
{
	public class MainController : Controller
    {
        public IActionResult StartPage()
        {
            return RedirectToAction(nameof(WorkerController.Create), nameof(WorkerController).GetNameOfController());
        }
    }
}
