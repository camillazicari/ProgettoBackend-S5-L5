using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoBackend_S5_L5.ViewModels
{
    public class AddVerbaleViewModel
    {
        [Required(ErrorMessage = "La data della violazione è obbligatoria")]
        [Display(Name = "DataViolazione")]
        public DateOnly DataViolazione { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "L'indirizzo della violazione è obbligatorio")]
        [Display(Name = "IndirizzoViolazione")]
        public string IndirizzoViolazione { get; set; } = null!;

        [StringLength(20)]
        [Required(ErrorMessage = "Il nome dell'agente è obbligatorio")]
        [Display(Name = "NominativoAgente")]
        public string NominativoAgente { get; set; } = null!;

        [Required(ErrorMessage = "La data di trascrizione della violazione è obbligatorio")]
        [Display(Name = "DataTrascrizioneVerbale")]
        public DateOnly DataTrascrizioneVerbale { get; set; }

        [Required(ErrorMessage = "L'importo è obbligatorio")]
        [Display(Name = "Importo")]
        public decimal Importo { get; set; }

        [Required(ErrorMessage = "Il decurtamento punti è obbligatorio")]
        [Display(Name = "DecurtamentoPunti")]
        public int DecurtamentoPunti { get; set; }

        [Required(ErrorMessage = "L'id dell'anagrafica è obbligatorio")]
        [Display(Name = "Idanagrafica")]
        public int Idanagrafica { get; set; }
    }
}
