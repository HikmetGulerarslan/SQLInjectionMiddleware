using Microsoft.AspNetCore.Mvc;

namespace SQlInjectionMiddleware.Controllers
{
    public class HomeController : Controller
    {
        [Route("/Deneme/{ad}")]
        public IActionResult Index(string ad)
        {
            return View();
        }
        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
