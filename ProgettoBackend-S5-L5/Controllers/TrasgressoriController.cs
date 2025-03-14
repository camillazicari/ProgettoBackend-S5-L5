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
            _trasgressoriService = trasgressoriService;
        }
        public async Task<IActionResult> Index()
        {
            var anagrafiche = await _trasgressoriService.GetAnagraficheAsync();

            return View(anagrafiche);
        }

        public IActionResult AddAnagrafiche()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAnagrafiche(AddAnagraficaViewModel addAnagraficaViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Error while saving entity to database";
                return RedirectToAction("Index");
            }

            var result = await _trasgressoriService.AddAnagraficaAsync(addAnagraficaViewModel);

            if (!result)
            {
                TempData["Error"] = "Error while saving entity to database";
            }

            return RedirectToAction("Index");
        }

    }
}
