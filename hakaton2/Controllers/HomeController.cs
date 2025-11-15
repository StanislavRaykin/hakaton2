using System.Diagnostics;
using hakaton2.Models;
using Microsoft.AspNetCore.Mvc;

namespace hakaton2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Use default view resolution (Views/Home/Index.cshtml)
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View("/Views/About/About.cshtml");
        }

        public IActionResult Leaderboard()
        {
            return View("/Views/Leaderboard/Leaderboard.cshtml");
        }

        public IActionResult Events()
        {
            return View("/Views/Events/Events.cshtml");
        }

        public IActionResult Login()
        {
            return View("/Views/User/Registration.cshtml");
        }

        public IActionResult Registration()
        {
            return View("/Views/User/Registration.cshtml");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
