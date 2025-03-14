using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProgettoBackend_S5_L5.Models;
using ProgettoBackend_S5_L5.Services;

namespace ProgettoBackend_S5_L5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TrasgressoriService _trasgressoriService;

        public HomeController(TrasgressoriService trasgressoriService)
        {
            _trasgressoriService = trasgressoriService;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> TotVerbali()
        {

        }
    }
}
