using Microsoft.AspNetCore.Mvc;

namespace FindJob.Controllers
{
	public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
