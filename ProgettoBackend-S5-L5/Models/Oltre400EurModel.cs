using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoBackend_S5_L5.Models
{
    public class Oltre400EurModel
    {
        public DateOnly DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; } = null!;
        public string NominativoAgente { get; set; } = null!;
        public DateOnly DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }
}
