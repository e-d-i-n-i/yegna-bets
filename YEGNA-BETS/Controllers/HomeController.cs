using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Diagnostics;
using YEGNA_BETS.Models;

namespace YEGNA_BETS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHtmlLocalizer<HomeController> localizer;

        public HomeController(ILogger<HomeController> logger, IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            this.localizer = localizer;
        }

        //Landing Page
        public IActionResult Index()
        {
            if (User.IsInRole("Administrator"))
            {
                Response.Redirect("/Admin/Index");
            }
            else if (User.IsInRole("User"))
            {
                Response.Redirect("/Bet/Index");
            }
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Packages()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}