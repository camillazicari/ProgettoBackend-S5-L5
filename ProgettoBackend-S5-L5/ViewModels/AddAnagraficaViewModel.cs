using Microsoft.EntityFrameworkCore;
using ProgettoBackend_S5_L5.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoBackend_S5_L5.ViewModels
{
    public class AddAnagraficaViewModel
    {
        [StringLength(20)]
        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [Display(Name = "Cognome")]
        public string Cognome { get; set; } = null!;

        [StringLength(20)]
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = null!;

        [StringLength(100)]
        [Required(ErrorMessage = "L'indirizzo è obbligatorio")]
        [Display(Name = "Indirizzo")]
        public string Indirizzo { get; set; } = null!;

        [StringLength(20)]
        [Required(ErrorMessage = "La città è obbligatoria")]
        [Display(Name = "Citta")]
        public string Citta { get; set; } = null!;

        [StringLength(5)]
        [Required(ErrorMessage = "Il CAP è obbligatorio")]
        [Display(Name = "Cap")]
        public string Cap { get; set; } = null!;

        [StringLength(16)]
        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [Display(Name = "CodFisc")]
        public string CodFisc { get; set; } = null!;
    }
}
