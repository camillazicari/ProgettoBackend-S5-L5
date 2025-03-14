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

        private async Task<bool> SaveAsync()
        {
            try
            {
                var rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
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


        public async Task<bool> AddAnagraficaAsync(AddAnagraficaViewModel addAnagraficaViewModel)
        {
            var anagrafica = new Anagrafica()
            {
                Nome = addAnagraficaViewModel.Nome,
                Cognome = addAnagraficaViewModel.Cognome,
                Indirizzo = addAnagraficaViewModel.Indirizzo,
                Cap = addAnagraficaViewModel.Cap,
                Citta = addAnagraficaViewModel.Citta,
                CodFisc = addAnagraficaViewModel.CodFisc
            };

            _context.Anagraficas.Add(anagrafica);

            return await SaveAsync();
        }

        public async Task<TotVerbaliViewModel> GetTotVerbaliAsync()
        {
            var totVerbali = new TotVerbaliViewModel();
            totVerbali.TotVerbali = await _context.
        }
    }
}
