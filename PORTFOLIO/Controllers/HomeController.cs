using Microsoft.AspNetCore.Mvc;

namespace PORTFOLIO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
