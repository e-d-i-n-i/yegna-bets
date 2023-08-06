using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YEGNA_BETS.Controllers
{
    public class NewsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Feed()
        {
            return View();
        }
        [Authorize]
        public IActionResult News()
        {
            return View();
        }
        [Authorize]
        public IActionResult UpComingMatches()
        {
            return View();
        }
        [Authorize]
        public IActionResult AddNews()
        {
            return View();
        }
        [Authorize]
        public IActionResult AddUpComingMatches()
        {
            return View();
        }
        [Authorize]
        public IActionResult ManageNews()
        {
            return View();
        }
        [Authorize]
        public IActionResult ManageUpComingMatches()
        {
            return View();
        }

    }
}
