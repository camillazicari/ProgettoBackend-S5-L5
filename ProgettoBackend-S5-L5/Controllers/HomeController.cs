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

        public HomeController(ILogger<HomeController> logger, TrasgressoriService trasgressoriService)
        {
            _logger = logger;
            _trasgressoriService = trasgressoriService;

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
            var totVerbali = await _trasgressoriService.GetTotVerbaliAsync();

            return View(totVerbali);
        }

        public async Task<IActionResult> TotPunti()
        {
            var totPunti = await _trasgressoriService.GetTotPuntiAsync();

            return View(totPunti);
        }

        public async Task<IActionResult> Oltre10Pt()
        {
            var oltre10Pt = await _trasgressoriService.GetOltre10PtAsync();

            return View(oltre10Pt);
        }

        public async Task<IActionResult> Oltre400Eur()
        {
            var oltre400Eur = await _trasgressoriService.GetOltre400EurAsync();

            return View(oltre400Eur);
        }
    }
}
