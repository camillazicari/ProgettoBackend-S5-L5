using System.ComponentModel.DataAnnotations;
using ProgettoBackend_S5_L5.Models;

namespace ProgettoBackend_S5_L5.ViewModels
{
    public class ViolazioneViewModel
    {
        public List<TipoViolazione> Violazioni { get; set; }
        public int IdViolazione { get; set; }

    }
}
