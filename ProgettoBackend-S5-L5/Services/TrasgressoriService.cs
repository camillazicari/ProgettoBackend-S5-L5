using Microsoft.EntityFrameworkCore;
using ProgettoBackend_S5_L5.Data;
using ProgettoBackend_S5_L5.Models;
using ProgettoBackend_S5_L5.ViewModels;

namespace ProgettoBackend_S5_L5.Services
{
    public class TrasgressoriService
    {
        private readonly ApplicationDbContext _context;

        public TrasgressoriService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AnagraficaViewModel> GetAnagraficheAsync()
        {
            var anagrafica = new AnagraficaViewModel();

            try
            {
                anagrafica.Anagrafiche = await _context.Anagraficas.ToListAsync();
            }
            catch
            {
                anagrafica.Anagrafiche = null;
            }

            return anagrafica;
        }
    }
}
