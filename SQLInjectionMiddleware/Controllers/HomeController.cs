using Microsoft.AspNetCore.Mvc;

namespace IpControl.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ErrorPage()
        {
            return View();
        }
        [Route("Deneme/{qwe}")]
        public IActionResult Index(string qwe)
        {
            return View();
        }
    }
}
