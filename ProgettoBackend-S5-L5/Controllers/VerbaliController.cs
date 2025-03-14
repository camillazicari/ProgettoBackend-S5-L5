using Microsoft.AspNetCore.Mvc;
using ProgettoBackend_S5_L5.Services;
using ProgettoBackend_S5_L5.ViewModels;

namespace ProgettoBackend_S5_L5.Controllers
{
    public class VerbaliController : Controller
    {
        private readonly TrasgressoriService _trasgressoriService;
        private readonly VerbaliService _verbaliService;

        public VerbaliController(VerbaliService verbaliService, TrasgressoriService trasgressoriService)
        {
            _verbaliService = verbaliService;
            _trasgressoriService = trasgressoriService;
        }
        public async Task<IActionResult> Index()
        {
            var verbali = await _verbaliService.GetVerbaliAsync();

            return View(verbali);
        }

        [HttpGet("verbali/violazioni/{id:int}")]
        public async Task<IActionResult> Violazioni(int id)
        {
            var violazioni = await _verbaliService.GetViolazioniAsync(id);
            ViewData["idVerbale"] = id;

            return View(violazioni);
        }


        public async Task<IActionResult> AddViolaziones(int id)
        {
            var violazioni = await _verbaliService.GetAllViolazioniAsync();
            ViewData["idVerbale"] = id;
            return View(violazioni);
        }

        [HttpPost("verbali/violazioni/{id:int}")]
        public async Task<IActionResult> AddViolazione(int id, ViolazioneViewModel violazioneViewModel)
        {
            int idViolazione = violazioneViewModel.IdViolazione;
            int idVerbale = id;

            var nuovaViolazione = await _verbaliService.AddViolazioneAsync(idVerbale, idViolazione);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddVerbale()
        {
            ViewBag.Anagrafiche = await _trasgressoriService.GetAnagraficheAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVerbale(AddVerbaleViewModel addVerbaleViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Error while saving entity to database";
                return RedirectToAction("Index");
            }

            var result = await _verbaliService.AddVerbaleAsync(addVerbaleViewModel);

            if (!result)
            {
                TempData["Error"] = "Error while saving entity to database";
            }

            return RedirectToAction("Index");
        }
    }
}
