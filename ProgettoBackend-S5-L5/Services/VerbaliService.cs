using Microsoft.EntityFrameworkCore;
using ProgettoBackend_S5_L5.Data;
using ProgettoBackend_S5_L5.Models;
using ProgettoBackend_S5_L5.ViewModels;

namespace ProgettoBackend_S5_L5.Services
{
    public class VerbaliService
    {
        private readonly ApplicationDbContext _context;

        public VerbaliService(ApplicationDbContext context)
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

        public async Task<VerbaleViewModel> GetVerbaliAsync()
        {
            var verbale = new VerbaleViewModel();

            try
            {
                verbale.Verbali = await _context.Verbales.ToListAsync();
            }
            catch
            {
                verbale.Verbali = null;
            }

            return verbale;
        }

        public async Task<VerbaleViolazioneViewModel> GetViolazioniAsync(int idVerbale)
        {
            var violazioni = new VerbaleViolazioneViewModel();

            violazioni.VerbaliViolazioni = await _context.VerbaleViolaziones.Where(vv => vv.Idverbale == idVerbale).Include(vv => vv.IdviolazioneNavigation).ToListAsync();

            return violazioni;
        }

        public async Task<ViolazioneViewModel> GetAllViolazioniAsync()
        {
            try
            {
                var violazioni = new ViolazioneViewModel();
                violazioni.Violazioni = await _context.TipoViolaziones.ToListAsync();
                return violazioni;
            }
            catch
            {
                return new ViolazioneViewModel() { Violazioni = new List<TipoViolazione>() }; 
            }

        }

        public async Task<bool> AddViolazioneAsync(int idVerbale, int idViolazione)
        {
            var verbaleViolazione = new VerbaleViolazione()
            {
                Idverbale = idVerbale,
                Idviolazione = idViolazione,
            };

            _context.VerbaleViolaziones.Add(verbaleViolazione);
            return await SaveAsync();
        }

        public async Task<bool> AddVerbaleAsync(AddVerbaleViewModel addVerbaleViewModel)
        {
            var verbale = new Verbale()
            {
                DataViolazione = addVerbaleViewModel.DataViolazione,
                DataTrascrizioneVerbale = addVerbaleViewModel.DataTrascrizioneVerbale,
                IndirizzoViolazione = addVerbaleViewModel.IndirizzoViolazione,
                DecurtamentoPunti = addVerbaleViewModel.DecurtamentoPunti,
                Idanagrafica = addVerbaleViewModel.Idanagrafica,
                NominativoAgente = addVerbaleViewModel.NominativoAgente,
                Importo = addVerbaleViewModel.Importo,
            };

            _context.Verbales.Add(verbale);

            return await SaveAsync();
        }
    }
}
