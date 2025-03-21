using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BasketballPlayers.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Home page visited at {time}", DateTime.Now);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Basketball Players Management System";
            ViewData["Description"] = "A comprehensive system for managing basketball players and their statistics.";

            return View();
        }

        public IActionResult ContactUs()
        {
            ViewData["Address"] = "123 Basketball Avenue";
            ViewData["Email"] = "contact@basketballplayers.com";
            ViewData["Phone"] = "+1 (555) 123-4567";

            return View();
        }
    }
}

