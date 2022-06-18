using Microsoft.AspNetCore.Mvc;

namespace FindJob.Controllers
{
	public class MainController : Controller
    {
        public IActionResult StartPage()
        {
            return View();
        }
    }
}
