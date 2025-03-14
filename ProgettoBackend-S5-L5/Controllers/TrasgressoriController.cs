using Microsoft.AspNetCore.Mvc;
using ProgettoBackend_S5_L5.ViewModels;
using ProgettoBackend_S5_L5.Services;

namespace ProgettoBackend_S5_L5.Controllers
{
    public class TrasgressoriController : Controller
    {
        private readonly TrasgressoriService _trasgressoriService;

        public TrasgressoriController(TrasgressoriService trasgressoriService)
        {
            this._trasgressoriService = trasgressoriService;
        }
        public async Task<IActionResult> Index()
        {
            var anagrafiche = await _trasgressoriService.GetAnagraficheAsync();

            return View(anagrafiche);
        }
    }
}
