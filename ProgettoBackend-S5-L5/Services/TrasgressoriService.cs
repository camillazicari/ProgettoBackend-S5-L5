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
            var result = new TotVerbaliViewModel();
            result.TotVerbali = await _context.Anagraficas.Select(a => new TotVerbaliModel()
            {
                NomeTrasgressore = a.Nome,
                CognomeTrasgressore = a.Cognome,
                TotVerbali = a.Verbales.Count()
            }).ToListAsync();

            return result;
        }

        public async Task<TotPuntiViewModel> GetTotPuntiAsync()
        {
            var result = new TotPuntiViewModel();
            result.TotPunti = await _context.Anagraficas.Select(a => new TotPuntiModel()
            {
                NomeTrasgressore = a.Nome,
                CognomeTrasgressore = a.Cognome,
                Punt = a.Verbales.Sum(v => v.DecurtamentoPunti)
            }).ToListAsync();

            return result;
        }

        public async Task<Oltre10PtViewModel> GetOltre10PtAsync()
        {
            var result = new Oltre10PtViewModel();
            result.Oltre10Pt = await _context.Verbales.Include(v => v.IdanagraficaNavigation).Where(v => v.DecurtamentoPunti >= 10).Select(v => new Oltre10PtModel()
            {
                Nome = v.IdanagraficaNavigation.Nome,
                Cognome = v.IdanagraficaNavigation.Cognome,
                DataViolazione = v.DataViolazione,
                Importo = v.Importo,
                Punti = v.DecurtamentoPunti
            }).ToListAsync();

            return result;
        }

        public async Task<Oltre400EurViewModel> GetOltre400EurAsync()
        {
            var result = new Oltre400EurViewModel();
            result.Oltre400Eur = await _context.Verbales.Where(v => v.Importo >= 400).Select(v => new Oltre400EurModel()
            {
                DataTrascrizioneVerbale = v.DataTrascrizioneVerbale,
                IndirizzoViolazione = v.IndirizzoViolazione,
                DecurtamentoPunti = v.DecurtamentoPunti,
                DataViolazione = v.DataViolazione,
                Importo = v.Importo,
                NominativoAgente = v.NominativoAgente
            }).ToListAsync();

            return result;
        }
    }
}
